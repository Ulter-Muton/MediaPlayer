
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using plasma_seek.PersionalClass;
using System.ComponentModel;
using plasma_seek.DateConvertor;
using plasma_seek.MyExceptions;
using System.Windows.Controls.Primitives;

namespace plasma_seek {


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class voidSTheMusic : Window, INotifyPropertyChanged {
        #region 变量
        //========依赖属性,用来数据绑定
        public static readonly DependencyProperty IsRecycleProperty;
        public static readonly DependencyProperty IsRandomProperty;
        public static readonly DependencyProperty SingleRecycleProperty;

        public event PropertyChangedEventHandler PropertyChanged;//用于数据绑定,当属性改变时,调用事件处理器


        #endregion

        #region 静态构造器
        static voidSTheMusic() {
            IsRecycleProperty = DependencyProperty.Register("IsRecycle", typeof(bool), typeof(voidSTheMusic), new PropertyMetadata(false));
            IsRandomProperty = DependencyProperty.Register("IsRandom", typeof(bool), typeof(voidSTheMusic), new PropertyMetadata(false));
            SingleRecycleProperty = DependencyProperty.Register("SingleRecycle", typeof(bool), typeof(voidSTheMusic), new PropertyMetadata(false));
        }
        #endregion


        #region 属性
        /// <summary>
        /// 控制是否循环播放
        /// </summary>
        public bool IsRecycle { get => (bool)GetValue(IsRecycleProperty); set => SetValue(IsRecycleProperty, value); }
        /// <summary>
        /// 控制是否随机播放
        /// </summary>
        public bool IsRandom { get => (bool)GetValue(IsRandomProperty); set => SetValue(IsRandomProperty, value); }
        /// <summary>
        /// 单曲 循环
        /// </summary>
        public bool SingleRecycle { get => (bool)GetValue(SingleRecycleProperty); set => SetValue(SingleRecycleProperty, value); }
        #endregion

        /// <summary>
        /// 加载完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_MediaOpened(object sender, RoutedEventArgs e) {

            watcher.Media = audio;
            //label显示总时间
            TimeSpan time = audio.NaturalDuration.TimeSpan;
            totlaTimeLabel.Content = new TimeSpanFormat().Convert(time, null, null, null);
            timeLineSplier.Maximum = time.TotalSeconds;
            timeLineSplier.Minimum = 0;
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="info">音乐文件</param>

        /// <summary>
        /// 开始结束按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartPaulse_Click(object sender, RoutedEventArgs e) {

            //检查listbox是否选择了歌曲
            if (audio.Source==null) {
                //donothing
            } else {
                if (IsAudioPlay) {
                    audio.Pause();
                    IsAudioPlay = false;
                } else {
                    audio.Play();
                    IsAudioPlay = true;
                }
            }
        }


        /// <summary>
        /// 上一首按钮按下后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Previous_Click(object sender, RoutedEventArgs e) {
            //mediasListView.MoveCurrentToPrevious();

            ////listbox滚动到播放位置
            //songList.SelectedItem = mediaInfos[mediasListView.CurrentPosition];
            //songList.ScrollIntoView(mediaInfos[mediasListView.CurrentPosition]);

            ////audio.Source = new Uri(mediaInfos[mediasListView.CurrentPosition].Path);
            ////audio.Play();
            ////isAudioPlay = true;
            //AudioPlay(mediasListView.CurrentItem as MediaInfo);

            //============================================
            ICollectionView tmpView = AudioListSelect(AudioControlSign.Previous);
            AudioPlayControl(tmpView, AudioControlSign.Previous);
            ScrollBoxToItem(tmpView);
            ControlButtonIntinial();
        }

        /// <summary>
        /// 下一首按钮按下后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click(object sender, RoutedEventArgs e) {

            ICollectionView tmpView = AudioListSelect(AudioControlSign.Next);
            AudioPlayControl(tmpView, AudioControlSign.Next);
            ScrollBoxToItem(tmpView);
            ControlButtonIntinial();

            //========================================
            //mediasListView.MoveCurrentToNext();

            ////listbox滚动到播放位置
            //songList.SelectedItem = mediaInfos[mediasListView.CurrentPosition];
            //songList.ScrollIntoView(mediaInfos[mediasListView.CurrentPosition]);

            //AudioPlay(mediasListView.CurrentItem as MediaInfo);
        }

        /// <summary>
        /// 设置自动播放下一首
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioPlayCompliete(object sender, RoutedEventArgs e) {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = System.Windows.Controls.Button.ClickEvent;
            args.Source = next;
            Next_Click(next, args);
        }
        /// <summary>
        /// 设置这首歌曲是否喜爱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetUnsetFavorite_Click(object sender, RoutedEventArgs e) {
            ToggleButton toggle = e.Source as ToggleButton;
            if (toggle!=null&& toggle.IsChecked!=null) {
                //设置是否是最爱
                mediaInfos[mediasListView.CurrentPosition].IsFavorite = (bool)toggle.IsChecked;
            }   
        }


        /// <summary>
        /// 修改音量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumChangeEvent(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (audio != null) {
                audio.Volume = volum.Value;
            }
        }
        /// <summary>
        /// 当属性改变时发出事件,方法放置在属性set块里面
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        private void PropertyOnChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //private void TimeLineSplier_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) {

        //}

        //private void TimeLineSplier_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e) {

        //}
        #region 控制播放顺序的核心功能

        private void AudioPlay(MediaInfo info) {
            try {
                if (info != null) {
                    Uri songUri = new Uri(info.Path);
                    audio.Source = songUri;
                    audio.Volume = volum.Value;//设置音量  

                    audio.Play();

                    //currentSongImage.Source = info.GetImage();//显示专辑封面
                    //currentSongAlbum.Text = info.Album;
                    //currentSongArtist.Text = info.Artist;
                    //currentSongGenur.Text = info.Gener;
                    //currentSongTitle.Text = info.Title;
                    CurrentMusicDisplay(info);
                    loveMusic.IsChecked = mediaInfos[mediasListView.CurrentPosition].IsFavorite;//显示这首音乐是否是喜爱的
                    //watcher.Media = audio;
                    //timeLineSplier.Maximum = audio.NaturalDuration.TimeSpan.TotalMilliseconds;//设置音乐控制条的最大位置
                    //timeLineSplier.DataContext = audio;


                    IsAudioPlay = true;
                }
            } catch (MediaNotSetException) {
                return;
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// 为当前播放面板设置各种信息
        /// </summary>
        /// <param name="info"></param>
        private void CurrentMusicDisplay(MediaInfo info) {
            if (info!=null) {
                currentSongImage.Source = info.GetImage();//显示专辑封面
                currentSongAlbum.Text = info.Album;
                currentSongArtist.Text = info.Artist;
                currentSongGenur.Text = info.Gener;
                currentSongTitle.Text = info.Title;
            }
            
        }
        /// <summary>
        /// 播放音乐的异步实现
        /// </summary>
        /// <param name="info"></param>
        private void AudioPlaySync(MediaInfo info) {
            Task task = new Task(() => AudioPlay(info));
            task.Start();
        }


        /// <summary>
        /// 控制播放上一曲或者下一曲
        /// </summary>
        /// <param name="view">列表的控制视图</param>
        /// <param name="myControl"></param>
        private void AudioPlayControl(ICollectionView view, AudioControlSign myControl) {
            if (myControl == AudioControlSign.Previous) {
                if (IsRecycle && view.CurrentPosition == 0) {
                    view.MoveCurrentToPosition(mediaInfos.Count - 1);//如果列表已经结束,移到表头
                } else {
                    view.MoveCurrentToPrevious();
                }
                MediaInfo tmpInfo = view.CurrentItem as MediaInfo;
                if (tmpInfo != null) {
                    AudioPlay(tmpInfo);
                }
            } else {
                //播放下一首歌曲
                if (SingleRecycle) {
                    //单曲循环,不处理
                } else {
                    if (IsRandom) {
                        //如果设置了随机播放
                        IsRecycle = true;
                        Random random = new Random();
                        int position = random.Next(0, mediaInfos.Count);
                        view.MoveCurrentToPosition(position);
                    } else {
                        //不是随机播放
                        if (IsRecycle && view.CurrentPosition == mediaInfos.Count - 1) {
                            view.MoveCurrentToPosition(0);
                        } else {
                            view.MoveCurrentToNext();
                        }

                    }

                }
                MediaInfo tmpInfo = view.CurrentItem as MediaInfo;
                if (tmpInfo != null) {
                    AudioPlay(tmpInfo);
                }
            }
        }
        /// <summary>
        /// 选择使用那个列表
        /// </summary>
        /// <returns></returns>
        private ICollectionView AudioListSelect(AudioControlSign control) {

            if (IsRecycle && mediasListView.CurrentPosition == mediaInfos.Count - 1) {
                //如果是重复模式,在最后一首歌时,将视图控制器恢复初始化
                mediasListView.MoveCurrentToPosition(-1);
                return mediasListView;
            }


            if (control == AudioControlSign.Previous) {
                if (playList.Count != 0) {
                    if (playListView.CurrentPosition == 0) {
                        playListView.MoveCurrentToPrevious();
                        mediasListView.MoveCurrentToNext();//因为audioplaycontrol方法直接moveprevious,所以先向前移动一位,然后按"上一首"可以回到前面播放的那一首
                        return mediasListView;
                    } else if (playListView.CurrentPosition == -1) {
                        return mediasListView;
                    } else {
                        return playListView;
                    }
                } else {
                    return mediasListView;
                }
            } else {
                //输入控制是MyControl.Next
                if (playList.Count == 0 || IsRandom) {
                    //如果播放列表没有内容,或者设置了随机播放
                    return mediasListView;
                } else {
                    if (playListView.CurrentPosition == -1) {
                        return playListView;
                    } else if (playListView.CurrentPosition == playList.Count) {
                        //当播放列表播放完毕后,清空列表
                        playList.Clear();
                        playListView.Refresh();
                        return mediasListView;
                    } else {
                        return playListView;
                    }
                }
            }

        }
        /// <summary>
        /// 设置按钮是否可用
        /// </summary>
        private void ControlButtonIntinial() {
            if (IsRecycle) {
                next.IsEnabled = next.IsEnabled = true;
                previous.IsEnabled = next.IsEnabled = true;
            } else {
                previous.IsEnabled = mediasListView.CurrentPosition == 0 ? false : true;
                next.IsEnabled = mediasListView.CurrentPosition == mediaInfos.Count - 1 ? false : true;
            }

        }
        /// <summary>
        /// 设置listbox的选择项并且滚动到此项
        /// </summary>
        /// <param name="view"></param>
        private void ScrollBoxToItem(ICollectionView view) {
            var item = view.CurrentItem as MediaInfo;
            if (item != null) {
                songList.SelectedItem = item;
                songList.ScrollIntoView(item);
            }

        }
        #endregion
    }
}
