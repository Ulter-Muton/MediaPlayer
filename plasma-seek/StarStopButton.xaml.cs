using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace plasma_seek {
    partial class StarStopButton {

        public static readonly DependencyProperty IsPlayingProperty;
        public static readonly DependencyProperty IsStartStopButtonProperty;
        public static readonly DependencyProperty IsNextProperty;


        static StarStopButton() {
            IsPlayingProperty = DependencyProperty.Register("IsPlaying", typeof(bool), typeof(StarStopButton),new PropertyMetadata(false));
            IsStartStopButtonProperty= DependencyProperty.Register("IsStartStopButton", typeof(bool), typeof(StarStopButton), new PropertyMetadata(false));
            IsNextProperty= DependencyProperty.Register("IsNext", typeof(bool), typeof(StarStopButton), new PropertyMetadata(false));
        }
        public bool IsPlaying {
            get {
                return (bool)GetValue(IsPlayingProperty);
            }
            set {
                SetValue(IsPlayingProperty, value);
            }
        }
        /// <summary>
        /// 设置这个按钮是不是开始暂停按钮
        /// </summary>
        public bool IsStartStopButton { get=>(bool) GetValue(IsStartStopButtonProperty); set=>SetValue(IsStartStopButtonProperty, value);
    }
        public bool IsNext { get=> (bool)GetValue(IsNextProperty); set=> SetValue(IsNextProperty, value); }

        public StarStopButton() {
            InitializeComponent();   
            
        }
    }
}
