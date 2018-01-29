using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_hts {
    class Stock_Initialize : SingleTon<Stock_Initialize> {
        int _scrNum = 5000;

        private Boolean g_is_thread = false; //false이면 스레드 미생성, true이면 스레드 생성


        public string GetScrNum() {
            if (_scrNum < 9999)
                _scrNum++;
            else
                _scrNum = 1000;

            return _scrNum.ToString();
        }

        public void DisconnectAllRealData() {
            for (int i = _scrNum; i > 5000; i--) {
                API.getInstance.getAPI().DisconnectRealData(i.ToString());
            }

            _scrNum = 5000;
        }

        public bool isThreadRunning() {
            if (g_is_thread == true) {
                return true;
            }
            else {
                return false;
            }
        }
        public void setThreadRunning() {
            g_is_thread = true;
        }
        public void setThreadStop() {
            g_is_thread = false;
        }
    }
}
