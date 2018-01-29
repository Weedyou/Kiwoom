using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiwoomCode;



namespace new_hts {
    public partial class Form1 : Form {
        static int MAXROWS = 30;

        Control control = new Control();
        public StockInfo[] ViewList = new StockInfo[MAXROWS];
        Calculator calculator = new Calculator();
        List<bool> isBuyOrdered = new List<bool>();

        Thread thread1 = null; //생성된 스레드 객체를 담을 변수

        public Form1() {
            InitializeComponent();
            Initialize_Handler();
            API.getInstance.setup_(this);

        }

        public AxKHOpenAPILib.AxKHOpenAPI open() {
            return axKHOpenAPI1;
        }

        private void Initialize_Handler() {
            this.axKHOpenAPI1.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.axKHOpenAPI_OnReceiveTrData);
            this.axKHOpenAPI1.OnReceiveRealData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEventHandler(this.axKHOpenAPI_OnReceiveRealData);

            this.stockInfoView.Columns["현재가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.stockInfoView.Columns["등락률"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.stockInfoView.Columns["거래량"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.stockInfoView.ColumnHeadersDefaultCellStyle.Font = new Font("돋움", 10, FontStyle.Bold);
            this.stockInfoView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            this.stockInfoView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        //클릭함수/////////////////////////
        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e) {

            Login.connectServer(this.toolStripStatusLabel1);

            //Group Box 설정
            control.setUserInfo(this);

        }

        private void btn종목추가_Click(object sender, EventArgs e) {
            if (Istxt종목코드valid()) {
                string l_jongmok_cd = txt종목코드.Text.Trim();
                string l_jongmok_nm = API.getInstance.getAPI().GetMasterCodeName(l_jongmok_cd).Trim();

                ViewList[stockInfoView.RowCount - 1] = new StockInfo(l_jongmok_cd, l_jongmok_nm, DataGridView.getRowCount());
                axKHOpenAPI1.SetInputValue("종목코드", l_jongmok_cd);
                axKHOpenAPI1.CommRqData("주식기본정보", "OPT10001", 0, Stock_Initialize.getInstance.GetScrNum());
            }
        }
        private bool Istxt종목코드valid() {
            if (txt종목코드.TextLength == 6) {
                return true;
            }
            else {
                return false;
            }
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e) {
            Stock_Initialize.getInstance.DisconnectAllRealData();
            API.getInstance.getAPI().CommTerminate();
            Utility.getInstance.Logger(this, Log.일반, "로그아웃");
        }



        //이벤트함수//////////////////////
        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e) {
            // OPT1001 : 주식기본정보
            if (e.sRQName == "주식기본정보") {
                //종목정보 셋팅
                ViewList[DataGridView.getRowCount()].setCurrentData(Utility.getInstance.separateStringWithComma(API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim().ToString())
                    , API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim().ToString()
                    , Utility.getInstance.separateStringWithComma(API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim().ToString()));

                //Data목록 삽입
                stockInfoView.Rows.Add(ViewList[DataGridView.getRowCount()].getStockName()
                                                , ViewList[DataGridView.getRowCount()].getCurrentPrice()
                                                , ViewList[DataGridView.getRowCount()].getRateOfUpDown()
                                                , ViewList[DataGridView.getRowCount()].getAmountOfVolume());
                setStockInfoViewStringColor();
                DataGridView.increaseRowCount();
                isBuyOrdered.Add(false);

                //실시간요청
                int lRet = API.getInstance.getAPI().SetRealReg(Stock_Initialize.getInstance.GetScrNum(),              // 화면번호
                                ViewList[DataGridView.getRowCount()].getStockCode(),    // 종콕코드 리스트
                                "9001;10",  // FID번호
                                "1");       // 0 : 마지막에 등록한 종목만 실시간
                msgRealSearchState(lRet);

            }

            else if (e.sRQName == "주식분봉차트조회") {

                int rowcount = getRowIndex(API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim());

                int[] l_price = new int[5];
                string temp = null;
                //5봉 이동평균 계산
                for (int i = 0; i < 5; i++) {
                    temp = API.getInstance.getAPI().GetCommData(e.sTrCode, "", i, "현재가").Trim();
                    if (temp.Substring(0, 1) == "-") {
                        l_price[i] = int.Parse(temp.Substring(1).Trim());
                    }
                    else {
                        l_price[i] = int.Parse(temp.Trim());
                    }
                }
                int c = 10; //주문수량
                Console.WriteLine(calculator.calculate5Average(l_price));
                Console.WriteLine(int.Parse(API.getInstance.getAPI().GetCommData(e.sTrCode, "", 0, "현재가").Trim()));
                Console.WriteLine(isBuyOrdered[rowcount]);


                if (calculator.calculate5Average(l_price) > int.Parse(API.getInstance.getAPI().GetCommData(e.sTrCode, "", 0, "현재가").Trim())/*현재가*/ && isBuyOrdered[rowcount] == false) {
                    //풀매수 떡상 가즈아~~~~~~~~~~~~!!!!!!!!!!!!찍
                    int lRet;
                    lRet = API.getInstance.getAPI().SendOrder("주식주문", Stock_Initialize.getInstance.GetScrNum(), cbo계좌번호.Text.Trim(),
                                KOACode.orderType[0].code, ViewList[rowcount].getStockCode().Trim(), c,
                                0, KOACode.hogaGb[1].code, "");

                    isBuyOrdered[rowcount] = true;
                    Console.WriteLine(isBuyOrdered[rowcount]);
                    if (lRet == 0) {
                        Console.WriteLine("주문성공!");
                    }
                    else {
                        Console.WriteLine("주문실패!");
                    }
                }






            }

            else if (e.sRQName == "관심종목정보") {
            }
        }

        private void setStockInfoViewStringColor() {
            for (int i = 0; i < stockInfoView.RowCount - 1; i++) {
                if (ViewList[i].getCurrentPrice()[0] == '-') {
                    stockInfoView["현재가", i].Style.ForeColor = Color.Blue;
                }
                else if (ViewList[i].getCurrentPrice()[0] == '+') {
                    stockInfoView["현재가", i].Style.ForeColor = Color.Red;
                }
                else {
                    stockInfoView["현재가", i].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < stockInfoView.RowCount - 1; i++) {
                if (ViewList[i].getRateOfUpDown()[0] == '-') {
                    stockInfoView["등락률", i].Style.ForeColor = Color.Blue;
                }
                else if (ViewList[i].getRateOfUpDown()[0] == '+') {
                    stockInfoView["등락률", i].Style.ForeColor = Color.Red;
                }
                else {
                    stockInfoView["등락률", i].Style.ForeColor = Color.Black;
                }
            }
        }
        private void msgRealSearchState(int lRet) {
            if (lRet == 0) {
                Utility.getInstance.Logger(this, Log.일반, "실시간 등록이 실행되었습니다");
            }
            else {
                Utility.getInstance.Logger(this, Log.에러, "실시간 등록이 실패하였습니다");
            }
        }


        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e) {
            if (e.sRealType == "주식체결") {
                int rowCount = getRowIndex(e.sRealKey);
                //종목데이터 수정
                ViewList[rowCount].setCurrentData(Utility.getInstance.separateStringWithComma(API.getInstance.getAPI().GetCommRealData(e.sRealType, 10).Trim().ToString())
                    , API.getInstance.getAPI().GetCommRealData(e.sRealType, 12).Trim().ToString()
                    , Utility.getInstance.separateStringWithComma(API.getInstance.getAPI().GetCommRealData(e.sRealType, 13).Trim().ToString()));

                Utility.getInstance.Logger(this, Log.실시간, "종목코드 : {0} | RealType : {1} | RealData : {2}",
e.sRealKey, e.sRealType, e.sRealData);

                //Data목록 수정
                stockInfoView.Rows[rowCount].SetValues(ViewList[rowCount].getStockName()
                                                       , ViewList[rowCount].getCurrentPrice()
                                                       , ViewList[rowCount].getRateOfUpDown()
                                                          , ViewList[rowCount].getAmountOfVolume());
            }
        }
        private int getRowIndex(string code) {
            for (int i = 0; i < stockInfoView.RowCount - 1; i++) {
                if (stockInfoView["종목명", i].Value.ToString().Trim() == API.getInstance.getAPI().GetMasterCodeName(code).Trim()) {
                    return i;
                }
            }
            return -1;
        }




        private void btn실시간_Click(object sender, EventArgs e) {
            if (Stock_Initialize.getInstance.isThreadRunning()) //스레드가 이미 생성된 상태라면 중복 스레드 생성을 방지함
           {
                Console.WriteLine("자동매매가 이미 시작되었습니다.\n", 0);
                return; //이벤트 매서드 종료
            }

            Stock_Initialize.getInstance.setThreadRunning(); //스레드 생성으로 값 세팅
            thread1 = new Thread(new ThreadStart(m_thread1)); //스레드 생성
            thread1.Start(); //스레드 시작
        }



        public void m_thread1() //스레드 매서드
        {
            string l_cur_tm = null;

            if (!Stock_Initialize.getInstance.isThreadRunning()) //최초 스레드 생성
            {
                Stock_Initialize.getInstance.setThreadRunning(); //중복 스레드 생성방지
                Console.WriteLine("자동매매가 시작되었습니다.\n", 0);
            }

            for (; ; )
            {
                l_cur_tm = Utility.getInstance.getCurrentTime(); //현재시간을 조회
                if (l_cur_tm.CompareTo("235959") >= 0) //15시 30분 이후라면 //테스트용시간 : 235959 장운영시간 : 153001
                {
                    break;
                }

                /* 로직검사
                1초마다 stockInfoView 의 모든 행을 검사한다
                현재가와 5일선이 크로스하면 매수주문을 실시한다 */

                for (int i = 0; i < DataGridView.getRowCount(); i++) { //쓰레드라서 문제가 생긴다면 여기
                    requestMinuteInquire(i); //조회event로 가줘야함 제발 안가면 분봉조회에서 주문넣는수밖에 //결국 분봉조회에서 주문넣었다.
                }
                Utility.getInstance.Delay(3000); //1초 딜레이
                Console.WriteLine("스레드 초기화");
            }
        }

        private void requestMinuteInquire(int rowCount) {
            //5분 단순이동평균 계산
            API.getInstance.getAPI().SetInputValue("종목코드", ViewList[rowCount].getStockCode());
            API.getInstance.getAPI().SetInputValue("틱범위", "5");
            API.getInstance.getAPI().SetInputValue("수정주가구분", "1");

            int nRet = API.getInstance.getAPI().CommRqData("주식분봉차트조회", "OPT10080", 0, Stock_Initialize.getInstance.GetScrNum());

            /* 현재가가 5일선을 데드크로스시 1회만 주문 
             아마 CommRqData 를 호출했기에 주식분봉차트로 이동할것이다.
             */
        }


        private bool isBuyTime(int rowNumber) {
            if (int.Parse(ViewList[rowNumber].getCurrentPrice()) < calculator.calculate5MovingAverage(rowNumber) && isBuyOrdered[rowNumber] == false) {
                return true;
            }
            else {
                return false;
            }
        }

        private void btn스레드중지_Click(object sender, EventArgs e) {
            Console.WriteLine("\n자동매매중지 시작\n");

            try {
                thread1.Abort(); //스레드 중지
            }
            catch (Exception ex) {
                Console.WriteLine("자동매매중지 ex.Message : " + ex.Message + "\n", 0);
            }

            this.Invoke(new MethodInvoker(() => {
                if (thread1 != null) {
                    thread1.Interrupt();
                    thread1 = null;
                }
            }));

            Stock_Initialize.getInstance.setThreadStop(); //스레드 미실행으로 세팅

            Console.WriteLine("\n자동매매중지 완료\n", 0);
        }
    }
}

