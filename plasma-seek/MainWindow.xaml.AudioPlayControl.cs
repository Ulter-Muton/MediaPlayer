using ID3;
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

namespace plasma_seek {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {

        private void StartPaulse_Click(object sender, RoutedEventArgs e) {
            //检查是否在播放状态
            if (isAudioPlay) {
                audio.Pause();
                isAudioPlay = false;
            } else {
                audio.Play();
                isAudioPlay = true;
            }
        }
        private void Previous_Click(object sender, RoutedEventArgs e) {
            mediasListView.MoveCurrentToPrevious();
            //audio.Source = new Uri(mediaInfos[mediasListView.CurrentPosition].Path);
            //audio.Play();
            //isAudioPlay = true;
            AudioPlay(mediasListView.CurrentItem as MediaInfo);        
        }
        private void Next_Click(object sender, RoutedEventArgs e) {
            mediasListView.MoveCurrentToNext();
            AudioPlay(mediasListView.CurrentItem as MediaInfo);
        }
    }
}
