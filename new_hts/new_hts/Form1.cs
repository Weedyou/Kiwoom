using System;
using System.Collections.Generic;
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



        string g_code_list;
        int g_code_list_cnt = 0;



        protected List<StockInfo> g_stock_info;

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
            Control.setUserInfo(this);

        }

        private void btn종목추가_Click(object sender, EventArgs e) {
            if (Istxt종목코드valid()) {
                string l_jongmok_cd = txt종목코드.Text.Trim();
                g_code_list_cnt++;
                g_code_list += l_jongmok_cd + ';';

                int lRet = axKHOpenAPI1.SetRealReg(Stock_Initialize.getInstance.GetScrNum(),              // 화면번호
                                                l_jongmok_cd,    // 종콕코드 리스트
                                                "9001;10",  // FID번호
                                                "1");       // 0 : 마지막에 등록한 종목만 실시간
                msgRealSearchState(lRet);

                //axKHOpenAPI1.SetInputValue("종목코드", l_jongmok_cd);
                //axKHOpenAPI1.CommRqData("주식기본정보", "OPT10001", 0, Stock_Initialize.getInstance.GetScrNum());
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
                Utility.getInstance.Logger(Log.일반, "실시간 등록이 실행되었습니다");
            }
            else {
                Utility.getInstance.Logger(Log.에러, "실시간 등록이 실패하였습니다");
            }
        }

        //이벤트함수//////////////////////
        private void axKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e) {
            // OPT1001 : 주식기본정보
            if (e.sRQName == "주식기본정보") {
                string 종목명_ = axKHOpenAPI1.GetMasterCodeName(txt종목코드.Text);
                string 현재가_ = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가");
                string 등락률_ = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락율");
                string 거래량_ = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량");

                stockInfoView.Rows.Add(종목명_, 현재가_, 등락률_, 거래량_);
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

            Utility.getInstance.Logger(Log.실시간, e.sRealData);



            if (e.sRealType == "주식시세") {

            }

        }

        public void m_thread() {
            axKHOpenAPI1.CommKwRqData(g_code_list, 0, g_code_list_cnt, 0, "관심종목정보", Stock_Initialize.getInstance.GetScrNum());
        }

    }

    public class StockInfo {
        public String 종목명 { get; set; }
        public String 현재가 { get; set; }
        public String 등락률 { get; set; }
        public String 거래량 { get; set; }
    }
}

