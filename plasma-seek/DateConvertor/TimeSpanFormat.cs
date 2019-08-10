using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using plasma_seek.MyExceptions;

namespace plasma_seek.DateConvertor {
    /// <summary>
    /// 数据绑定将timespan转化成格式化的字符串
    /// </summary>
    class TimeSpanFormat : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is TimeSpan) {
                TimeSpan span = (TimeSpan)value;

                return string.Format($"{span.Minutes:00}:{span.Seconds:00}");

            } else {
                throw new CannotConverterException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;//不回转,单向绑定
        }
    }
}
