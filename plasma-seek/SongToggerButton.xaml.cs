using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using plasma_seek;

namespace plasma_seek {
    partial class SongToggerButton {
        public static readonly DependencyProperty FunctionProperty;

        static SongToggerButton() {
            FunctionProperty = DependencyProperty.Register(
                "ButtonFunction", typeof(int), typeof(SongToggerButton),
                new PropertyMetadata(1));
        }

        public int ButtonFunction {
            get => (int)GetValue(FunctionProperty); set {
                SetValue(FunctionProperty, value);
            }
        }
        public SongToggerButton() {
            InitializeComponent();
        }
    }
}
