using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace plasma_seek.DateConvertor {
    [ValueConversion(typeof(TimeSpan), typeof(double))]
    class TimeSpanToDoubleConvertor : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is TimeSpan) {
                TimeSpan span = (TimeSpan)value;
                return span.TotalSeconds;
            } else {
                throw new Exception("value isnot TimeSpan");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is double) {
                double secs = (double)value;
                TimeSpan span = new TimeSpan(0,0,0,(int)secs);
                return span;
            } else {
                throw new Exception("value isnot double");
            }
        }
    }
}
