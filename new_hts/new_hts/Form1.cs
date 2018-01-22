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

                ViewList[DataGridView.getRowCount()].setCurrentData(API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "현재가")
                    , API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "등락율")
                    , API.getInstance.getAPI().GetCommData(e.sTrCode, e.sRQName, 0, "거래량"));

                stockInfoView.Rows.Add(ViewList[DataGridView.getRowCount()].getStockName()
                                                , ViewList[DataGridView.getRowCount()].getCurrentPrice()
                                                , ViewList[DataGridView.getRowCount()].getRateOfUpDown()
                                                , ViewList[DataGridView.getRowCount()].getAmountOfVolume());
                DataGridView.increaseRowCount();

                int lRet = axKHOpenAPI1.SetRealReg(Stock_Initialize.getInstance.GetScrNum(),              // 화면번호
                                ViewList[DataGridView.getRowCount()].getStockCode(),    // 종콕코드 리스트
                                "9001;10",  // FID번호
                                "1");       // 0 : 마지막에 등록한 종목만 실시간
                msgRealSearchState(lRet);

            }

            if (e.sRQName == "관심종목정보") {

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

                ViewList[rowCount].setCurrentData(API.getInstance.getAPI().GetCommRealData(e.sRealType, 10).Trim()
                    , API.getInstance.getAPI().GetCommRealData(e.sRealType, 12).Trim()
                    , API.getInstance.getAPI().GetCommRealData(e.sRealType, 13).Trim());

                Utility.getInstance.Logger(this, Log.실시간, "종목코드 : {0} | RealType : {1} | RealData : {2}",
    e.sRealKey, e.sRealType, e.sRealData);
                Utility.getInstance.Logger(this, Log.일반,  ViewList[rowCount].getCurrentPrice());


                stockInfoView.Rows[rowCount].SetValues(ViewList[rowCount].getStockName()
                                                       , ViewList[rowCount].getCurrentPrice()
                                                       , ViewList[rowCount].getRateOfUpDown()
                                                       , ViewList[rowCount].getAmountOfVolume());
            }
        }

        private int getRowIndex(string code) {
            for (int i = 0; i < stockInfoView.RowCount-1; i++) {
                if(stockInfoView["종목명", i].Value.ToString() == API.getInstance.getAPI().GetMasterCodeName(code)) {
                    return i;
                }
            }
            return -1;
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
        //가져오기함수
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


        //설정함수
        public void setCurrentData(String price, String rate, String tradingAmount) {
            setCurrentPrice(price);
            setRateOfUpDown(rate);
            setAmountOfVolume(tradingAmount);
        }
        public void setCurrentPrice(String price) {
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

