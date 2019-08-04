﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace plasma_seek.DateConvertor {
    
    class LengthDubTwo : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return double.Parse(value as string) / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (double)value * 2;
        }
    }
}
