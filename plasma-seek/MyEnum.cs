using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plasma_seek {
    /// <summary>
    /// 制上一曲,下一曲
    /// </summary>
    public enum AudioControlSign {
        /// <summary>
        /// 上一曲
        /// </summary>
        Previous=0,
        /// <summary>
        /// 下一曲
        /// </summary>
        Next=1
    }
    public enum ButtonFunction {
        Default=0,
        Love=1,
        Random=2,
        Recycle=3,
        SingleRecycle=4
    }
}
