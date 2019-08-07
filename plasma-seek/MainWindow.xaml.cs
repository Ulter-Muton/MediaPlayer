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
using System.Collections.ObjectModel;
using ATL;
using System.ComponentModel;

namespace plasma_seek {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {


        public MainWindow() {

            InitializeComponent();

            //=============================================
            //获取软件的运行目录
            _solfWarePath = Directory.GetCurrentDirectory();
            _configPath = System.IO.Path.Combine(_solfWarePath, "Config");
            _SongListXmlPath = System.IO.Path.Combine(_configPath, "SongList.xml");
            _FolderPath = System.IO.Path.Combine(_configPath, "PathList.xml");
            //创建路径
            //Directory.CreateDirectory(_configPath);
            _currentSongInfo = null;
            MediaElementInitialization();
            InitializationAllSetting();
        }

        #region 变量
        //==============================================================

        private string _solfWarePath;//软件的运行路径
        private string _configPath;//各种设置信息路径
        private string _SongListXmlPath;//歌曲列表文件路径
        private string _FolderPath;//歌曲文件夹列表路径
        //private string _favoriteSongPath;//最爱歌曲记录文件路径

        private MediaInfos mediaInfos;//歌曲信息列表S
        private MediaInfos playList;//播放列表
        private Track _currentSongInfo;//当前歌曲信息
        private SongFolderRecoders _folderRecoerds;//路径文件夹列表
                                                   //private FavoriteSongs favorites//最喜爱列表

        private bool isAudioPlay;//记录音乐播放状态
        private System.ComponentModel.ICollectionView mediasListView;
        private System.ComponentModel.ICollectionView playListView;

        private AudioPositionWatcher watcher;//音频时间轴监测
                                             



        #endregion


        #region 属性
        //属性
        public string ConfigPath { get => _configPath; }
        public string SongListXmlPath { get => _SongListXmlPath; }
        public string FolderPath { get => _FolderPath; }
        public bool IsAudioPlay { get => isAudioPlay; set {
                isAudioPlay = value;
                PropertyOnChanged("IsAudioPlay");
            } }
        //public string  FavoriteSongPath { get => _favoriteSongPath; }
        //====================================================
        #endregion
        /// <summary>
        /// 初始化播放器
        /// </summary>
        private void MediaElementInitialization() {
            //audio = new MediaElement();
            audio.LoadedBehavior = MediaState.Manual;
            audio.UnloadedBehavior = MediaState.Stop;
            audio.Visibility = Visibility.Collapsed;
            audio.MediaEnded += AudioPlayCompliete;
            watcher = new AudioPositionWatcher();
            currentTimeLabel.DataContext = watcher;
            timeLineSplier.DataContext = watcher;
            //panel.Children.Add(audio);
        }



        private void InitializationAllSetting() {

            if (Directory.Exists(_configPath) == false) {
                //检查文件是否存在,如果不存在创建它
                Directory.CreateDirectory(_configPath);
            }

            //加载文件夹路径列表
            _folderRecoerds = SongFolderRecoders.LoadFromXml(_FolderPath) as SongFolderRecoders;
            if (_folderRecoerds == null) {
                _folderRecoerds = new SongFolderRecoders();
                _folderRecoerds.SaveToXml(_FolderPath);
            }
            //加载歌曲信息列表
            mediaInfos = MediaInfos.LoadFromXml(SongListXmlPath);//从歌曲列表记录文件加载
            if (mediaInfos == null) {
                mediaInfos = new MediaInfos();
            } else {
                //检查歌曲是否存在
                //foreach (MediaInfo tmpInfo in mediaInfos) {
                //    if (Directory.Exists(tmpInfo.Path)) {
                //        不做任何事
                //    } else {
                //        mediaInfos.Remove(tmpInfo);
                //    }
                //}
                for (int i = 0; i < mediaInfos.Count; i++) {
                    if (File.Exists(mediaInfos[i].Path)) {
                        //不做任何事
                    } else {
                        mediaInfos.Remove(mediaInfos[i]);
                    }
                }
            }
            mediaInfos.SaveToXml(SongListXmlPath);


            //创建音乐播放控制
            mediasListView = CollectionViewSource.GetDefaultView(mediaInfos);
            //设置前一首,下一首按钮是否可用
            previous.IsEnabled = mediasListView.CurrentPosition != 0;
            next.IsEnabled = mediasListView.CurrentPosition != mediaInfos.Count - 1;

            songList.ItemsSource = mediasListView;//将歌曲信息赋值到Listbox中

            //播放列表初始化
            playList = new MediaInfos();
            playListView = CollectionViewSource.GetDefaultView(playList);
        }

        /// <summary>
        /// 获取文件夹里面的音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindSongOnClick(object sender, RoutedEventArgs e) {
            FolderBrowserDialog getFolder = new FolderBrowserDialog();
            string[] FilePaths = null;
            //获取文件夹信息
            if (getFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                FilePaths = Directory.GetFiles(getFolder.SelectedPath);
                //FileStream mediaStream = null;
                Track media = null;
                Regex regex = new Regex(@"(\w+[ ]*)+(?=[(.mp3)(.flav)])", RegexOptions.IgnoreCase);//使用正则表达式过滤出音频名称
                foreach (string songPath in FilePaths) {
                    //过滤出属于音频信息的音频
                    if (regex.IsMatch(songPath)) {

                        //记录拥有音乐文件的文件夹路径=================================
                        if (_folderRecoerds.Count == 0) {
                            //将文件夹路径记录到列表中
                            _folderRecoerds.Add(new SongFolderRecoder(getFolder.SelectedPath));
                            //将列表信息记录到xml中
                            _folderRecoerds.SaveToXml(FolderPath);
                        } else {
                            //foreach (var item in _folderRecoerds) {
                            //    if (item.Equals(new SongFolderRecoder(getFolder.SelectedPath))) {
                            //        //不做任何操作
                            //    } else {
                            //        //将文件夹路径记录到列表中
                            //        _folderRecoerds.Add(new SongFolderRecoder(getFolder.SelectedPath));
                            //        //将列表信息记录到xml中
                            //        _folderRecoerds.SaveToXml(FolderPath);
                            //    }
                            //}
                            for (int i = 0; i < _folderRecoerds.Count; i++) {
                                if (_folderRecoerds[i].Equals(new SongFolderRecoder(getFolder.SelectedPath))) {
                                    //不做任何操作
                                } else {
                                    //将文件夹路径记录到列表中
                                    _folderRecoerds.Add(new SongFolderRecoder(getFolder.SelectedPath));
                                    //将列表信息记录到xml中
                                    _folderRecoerds.SaveToXml(FolderPath);
                                }
                            }
                        }
                        //==================================================================

                        //当符合正则表达式时
                        try {
                            try {
                                //获取歌曲文件
                                media = new Track(songPath, true);
                                MediaInfo info = new MediaInfo(media);
                                //将歌曲信息增加到
                                if (mediaInfos.HaveItem(info) == false) {
                                    mediaInfos.Add(info);
                                }

                            } catch (Exception) {
                                Console.WriteLine("cannot create media");
                            }
                        } catch (Exception) {
                            Console.WriteLine("cannot open media stream");
                        }
                    }
                }
                mediaInfos.SaveToXml(SongListXmlPath);
                mediasListView.Refresh();
            }
        }

        private void SongSelectionChange(object sender, SelectionChangedEventArgs e) {
            ListBoxItem item = e.Source as ListBoxItem;
            if (item != null) {
                System.Windows.MessageBox.Show(songList.SelectedValue.ToString());
            }
        }
        /// <summary>
        /// 双击歌曲发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SongListItem_DoubleClick(object sender, MouseButtonEventArgs e) {
            MediaInfo info = songList.SelectedValue as MediaInfo;
            mediasListView.MoveCurrentTo(info);
            PreviewNextButtonIntinial();
            AudioPlay(info);
            //AudioPlaySync(info);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (audio!=null) {
                audio.Position = new TimeSpan(0, 0, 50);
            }
        }
    }
}
