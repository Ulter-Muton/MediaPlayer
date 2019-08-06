using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using plasma_seek.MyExceptions;

namespace plasma_seek.DateConvertor {
    [ValueConversion(typeof(string),typeof(int))]
    class StringtoSecondConvertor : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is string) {
                var tmp= value.ToString().Split(':');
                int sec = int.Parse(tmp[0].ToString()) * 60 + int.Parse(tmp[1].ToString());
                return sec;
            } else if (value ==null) {
                return 0;
            }else {
                throw new CannotConverterException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;//单向模式
        }
    }
}
