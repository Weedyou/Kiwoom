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
using System.Runtime.ExceptionServices;
using System.Security;

namespace new_hts {
    class Utility : SingleTon<Utility> {
        Form1 utilform = new Form1();



        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public DateTime Delay(int MS) {
            DateTime thisMoment = DateTime.Now;
            TimeSpan Duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = thisMoment.Add(Duration);

            while (AfterWards >= thisMoment) {
                try {
                    unsafe
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                catch (AccessViolationException ex) {
                    Console.WriteLine("Delay Error : " + ex.Message);
                }
                thisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        public void Logger(Log type, string format, params Object[] args) {
            string message = String.Format(format, args);

            switch (type) {
                case Log.조회:
                    this.utilform.lst조회.Items.Add(message);
                    this.utilform.lst조회.SelectedIndex = this.utilform.lst조회.Items.Count - 1;
                    break;
                case Log.에러:
                    this.utilform.lst에러.Items.Add(message);
                    this.utilform.lst에러.SelectedIndex = this.utilform.lst에러.Items.Count - 1;
                    break;
                case Log.일반:
                    this.utilform.lst일반.Items.Add(message);
                    this.utilform.lst일반.SelectedIndex = this.utilform.lst일반.Items.Count - 1;
                    break;
                case Log.실시간:
                    this.utilform.lst실시간.Items.Add(message);
                    this.utilform.lst실시간.SelectedIndex = this.utilform.lst실시간.Items.Count - 1;
                    break;
                default:
                    break;
            }
        }

    }
}
