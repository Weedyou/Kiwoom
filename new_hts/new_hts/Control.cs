using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_hts {
    class Control {

        
        string g_user_id;
        string g_accnt_no;


        public  void setUserInfo(Form1 form) {
            g_user_id = API.getInstance.getAPI().GetLoginInfo("USER_ID").Trim();
            form.txt아이디.Text = g_user_id;

            string l_accno_count = API.getInstance.getAPI().GetLoginInfo("ACCOUNT_CNT").Trim();
            string[] l_accno_arr = new string[int.Parse(l_accno_count)];

            string l_accno = API.getInstance.getAPI().GetLoginInfo("ACCNO").Trim();

            l_accno_arr = l_accno.Split(';');

            form.cbo계좌번호.Items.Clear();
            form.cbo계좌번호.Items.AddRange(l_accno_arr); //N개의 증권계좌번호를 콤보박스에 저장
            form.cbo계좌번호.SelectedIndex = 0; //첫 번째 계좌번호를 콤보박스 초기 선택으로 설정
            g_accnt_no = form.cbo계좌번호.SelectedItem.ToString().Trim(); //설정된 증권계좌 번호를 클래스 변수에 저장

        }
    }

    class Combobox : Control {

    }

    class TextBox : Control {

    }

    class DataGridView : Control {
        private static int rowCount = 0;

        public static int  getRowCount() {
            return rowCount;
        }
        public static void increaseRowCount() {
            rowCount++;
        }
        public static void decreaseRowCount() {
            rowCount--;
        }


        public static int getRowIndex(Form1 form, string jongmok_name) {
            for (int i = 0; i < form.stockInfoView.RowCount - 1; i++) {
                if (form.stockInfoView["종목명", i].Value.ToString() == jongmok_name) {
                    return i;
                }
            }

            return -1;
        }

        public static bool isStockInfoViewInclude(Form1 form, string jongmok_name) {
            for (int i = 0; i < form.stockInfoView.RowCount - 1; i++) {
                if (form.stockInfoView["종목명", i].Value.ToString() == jongmok_name) {
                    return true;
                }
            }
            return false;
        }
    }
}
