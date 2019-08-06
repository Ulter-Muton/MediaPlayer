using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plasma_seek.MyExceptions {
    /// <summary>
    /// 转化失败
    /// </summary>
    class CannotConverterException:Exception {
        public CannotConverterException():base("Convert fail") {           
        }
        public CannotConverterException(string details):base(details) {

        }
    }
}
