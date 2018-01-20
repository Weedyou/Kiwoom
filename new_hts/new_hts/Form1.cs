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
        static int MAXROWS = 40;

        Control control = new Control();
        StockInfo[] ViewList = new StockInfo[MAXROWS];

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
                //int l_currentRowCount = stockInfoView.RowCount - 1;



                if (DataGridView.isStockInfoViewInclude(this, l_jongmok_nm)) {
                }
                else {
                    ViewList[stockInfoView.RowCount - 1] = new StockInfo(l_jongmok_cd, l_jongmok_nm, DataGridView.getRowCount());
                    axKHOpenAPI1.SetInputValue("종목코드", l_jongmok_cd);
                    axKHOpenAPI1.CommRqData("주식기본정보", "OPT10001", 0, Stock_Initialize.getInstance.GetScrNum());


                    stockInfoView.Rows.Add(ViewList[DataGridView.getRowCount()].getStockName()
                        , ViewList[DataGridView.getRowCount()].getCurrentPrice()
                        , ViewList[DataGridView.getRowCount()].getRateOfUpDown()
                        , ViewList[DataGridView.getRowCount()].getAmountOfVolume());
                    DataGridView.increaseRowCount();

                    int lRet = axKHOpenAPI1.SetRealReg(Stock_Initialize.getInstance.GetScrNum(),              // 화면번호
                                    l_jongmok_cd,    // 종콕코드 리스트
                                    "9001;10",  // FID번호
                                    "1");       // 0 : 마지막에 등록한 종목만 실시간
                    msgRealSearchState(lRet);

                }
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
        private void msgRealSearchState(int lRet) {
            if (lRet == 0) {
                Utility.getInstance.Logger(this, Log.일반, "실시간 등록이 실행되었습니다");
            }
            else {
                Utility.getInstance.Logger(this, Log.에러, "실시간 등록이 실패하였습니다");
            }
        }

        //이벤트함수//////////////////////
        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e) {
            // OPT1001 : 주식기본정보
            if (e.sRQName == "주식기본정보") {
                ViewList[DataGridView.getRowCount()].setCurrntPrice(API.getInstance.getAPI().GetCommData(ViewList[DataGridView.getRowCount()].getStockCode()
                    , ViewList[DataGridView.getRowCount()].getStockName()
                    , 0
                    , "현재가").Trim());
                ViewList[DataGridView.getRowCount()].setRateOfUpDown(API.getInstance.getAPI().GetCommData(ViewList[DataGridView.getRowCount()].getStockCode()
                    , ViewList[DataGridView.getRowCount()].getStockName()
                    , 0
                    , "현재가").Trim());
                ViewList[DataGridView.getRowCount()].setAmountOfVolume(API.getInstance.getAPI().GetCommData(ViewList[DataGridView.getRowCount()].getStockCode()
                    , ViewList[DataGridView.getRowCount()].getStockName()
                    , 0
                    , "현재가").Trim());

            }

            if (e.sRQName == "관심종목정보") {

            }
        }



        /*버튼클릭 - SetRealReg 호출 - RealTrData호출 - 여기서 gridview 조작

realdataevent 에서
서버로부터 호출이오면 호출받은 종목명을 그리드뷰에서 검색

존재한다면 수정해주면되고

존재하지않는다면 행추가해주면됨

*/
        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e) {
            Utility.getInstance.Delay(200);



            if (e.sRealType == "주식시세") {

            }

        }
    }

    public class StockInfo {
        private String stockCode;
        private String stockName;
        private int rowIndex;
        private String currentPrice;
        private String rateOfUpDown;
        private String amountOfVolume;

        public StockInfo(string jongmok_cd, string jongmok_nm, int index) {
            stockCode = jongmok_cd;
            stockName = jongmok_nm;
            rowIndex = index;
        }

        public String getStockCode() {
            return stockCode;
        }
        public String getStockName() {
            return stockName;
        }
        public int getRowIndex() {
            return rowIndex;
        }
        public String getCurrentPrice() {
            return currentPrice;
        }
        public String getRateOfUpDown() {
            return rateOfUpDown;
        }
        public String getAmountOfVolume() {
            return amountOfVolume;
        }


        public void setCurrntPrice(String price) {
            currentPrice = price;
        }
        public void setRateOfUpDown(String rate) {
            rateOfUpDown = rate;
        }
        public void setAmountOfVolume(String tradingAmount) {
            amountOfVolume = tradingAmount;
        }

    }
}

