using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using plasma_seek.MyExceptions;

namespace plasma_seek.DateConvertor {
    /// <summary>
    /// 根据属性的是否为真控制wpf元素是否可见
    /// </summary>
    public class ToggleButtonCheckedVisibilityConvertor : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool) {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            } else if (value==null) {
                return Visibility.Collapsed;
            } else {
                throw new CannotConverterException("isn't a bool type");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;//singal way mode
        }
    }
}
