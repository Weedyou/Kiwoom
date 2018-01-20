using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_hts {
    class Login {
        public static void connectServer(ToolStripStatusLabel Label) {
            int result = API.getInstance.getAPI().CommConnect();

            if (result == 0) {
                Label.Text = "로그인 중...";
                for (; ; ) {
                    int state = API.getInstance.getAPI().GetConnectState(); //로그인 완료 여부를 가져옴
                    if (state == 1) //로그인이 완료되면
                    {
                        break; //반복문을 벗어남
                    }
                    else //그렇지 않으면
                    {
                        Utility.getInstance.Delay(1000);
                    }
                }
            }
            Label.Text = "로그인 완료"; //화면 하단 상태란에 메시지 출력
        }

    }
}
