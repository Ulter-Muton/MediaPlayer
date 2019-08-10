using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace plasma_seek.PersionalClass {
    public  class MediaNotSetException:Exception {
    }
    /// <summary>
    /// 使用一个计时器获取音乐的当前时间轴,此类作为中间人控制音乐的播放时间轴
    /// </summary>
    public class AudioPositionWatcher : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private TimeSpan _position;
        private TimeSpan _totalTime;
        private MediaElement _media;
        private bool isTimerStart;//计时器是否开始
        DispatcherTimer timer;
        /// <summary>
        /// 获取media的当前位置
        /// </summary>
        public TimeSpan Position {
            get => _position; set {
                _position = value;
                if (Media!=null) {
                    Media.Position = value;//设置音频播放位置
                }               
                OnPropertyChange("Position");
            }
        }
        /// <summary>
        /// 获取media的播放位置
        /// </summary>
        public TimeSpan TotalTime {
            get => _totalTime; set {
                _totalTime = value;
                OnPropertyChange("TotalTime");
            }
        }

        public MediaElement Media {
            get => _media; set {
                _media = value;
                if (_media.NaturalDuration.HasTimeSpan) {
                    TotalTime = _media.NaturalDuration.TimeSpan;//获取总时间
                }
                
                if (isTimerStart) {
                    //donmothing
                } else {
                    timer.Start();
                    isTimerStart = true;
                }
                
                OnPropertyChange("Media");
            }
        }
        public AudioPositionWatcher() {
            _position = new TimeSpan();
            _totalTime = new TimeSpan();
            _media = null;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(1000);
            timer.Tick += Timer_Tick;
            isTimerStart = false;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            Position = Media.Position;
        }

        private void OnPropertyChange(string propertyName) {
            //利用task异步调用所有订阅的方法,防止线程阻塞
            if (PropertyChanged != null) {
                var invockers = PropertyChanged.GetInvocationList();
                foreach (var item in invockers) {
                    //laumda表达式为执行订阅的方法
                    Task task = new Task(() => item.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName)));
                    task.Start(); 
                }
            }
        }
    }
}
