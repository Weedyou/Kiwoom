using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_hts {
    class Stock_Initialize : SingleTon<Stock_Initialize> {
        Form1 form = new Form1();
        int _scrNum = 5000;


        public string GetScrNum() {
            if (_scrNum < 9999)
                _scrNum++;
            else
                _scrNum = 5000;

            return _scrNum.ToString();
        }

        private void DisconnectAllRealData() {
            for (int i = _scrNum; i > 5000; i--) {
                API.getInstance.getAPI().DisconnectRealData(i.ToString());
            }

            _scrNum = 5000;
        }
    }


}
