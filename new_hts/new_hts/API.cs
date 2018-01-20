using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_hts {
    public class API : SingleTon<API> {
        public AxKHOpenAPILib.AxKHOpenAPI openAPI = null;

        public AxKHOpenAPILib.AxKHOpenAPI getAPI() {
            return openAPI;
        }

        public void setup_(Form1 form) {
            openAPI = form.open();
        }


    }
}
