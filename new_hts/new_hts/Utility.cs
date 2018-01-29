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

        public void Logger (Form1 utilform, Log type, String format, params Object[] args) {
            string message = String.Format(format, args);

            switch (type) {
                case Log.조회:
                    utilform.lst조회.Items.Add(message);
                    utilform.lst조회.SelectedIndex = utilform.lst조회.Items.Count - 1;
                    break;
                case Log.에러:
                    utilform.lst에러.Items.Add(message);
                    utilform.lst에러.SelectedIndex = utilform.lst에러.Items.Count - 1;
                    break;
                case Log.일반:
                    utilform.lst일반.Items.Add(message);
                    utilform.lst일반.SelectedIndex = utilform.lst일반.Items.Count - 1;
                    break;
                case Log.실시간:
                    utilform.lst실시간.Items.Add(message);
                    utilform.lst실시간.SelectedIndex = utilform.lst실시간.Items.Count - 1;
                    break;
                default:
                    break;
            }
        }

        public String getCurrentDate() {
            DateTime date = new DateTime();
            date = DateTime.Now;
            String result = date.ToString("yyyyMMdd");
            return result.Trim();
        }

        public String getCurrentTime() {
            DateTime time = new DateTime();
            time = DateTime.Now;
            String result = time.ToString("HHmmss");
            return result.Trim();
        }

        public  String separateStringWithComma(String tradingAmount) {
            int length = tradingAmount.Length;
            string result = null;

            if (length > 0 && length <= 3) {
                return tradingAmount;
            }
            else if (length > 3 && length <= 6) {
                result = tradingAmount.Substring(length - 3);
                result = result.Insert(0, ",");
                result = result.Insert(0, tradingAmount.Substring(0, length - 3));
                return result;
            }
            else if (length > 6 && length <= 9) {
                result = tradingAmount.Substring(length - 3);
                result = result.Insert(0, ",");
                result = result.Insert(0, tradingAmount.Substring(length - 6, 3));
                result = result.Insert(0, ",");
                result = result.Insert(0, tradingAmount.Substring(0, length - 6));
                return result;
            }
            return "a";
        }


    }
}
