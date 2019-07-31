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

namespace plasma_seek {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {

        MediaInfos mediaInfos;//歌曲信息列表S
        public MainWindow() {

            InitializeComponent();

            //=============================================
            //获取软件的运行目录
            _solfWarePath = Directory.GetCurrentDirectory();
            _configPath = System.IO.Path.Combine(_solfWarePath, "Config");
            _SongListXmlPath = System.IO.Path.Combine(_configPath, "SongList.xml");
            //创建路径
            Directory.CreateDirectory(_configPath);
            //============================================

            mediaInfos = MediaInfos.LoadFromXml(SongListXmlPath);//从歌曲列表记录文件加载
            if (mediaInfos == null) {
                //如果加载失败,则重新创建一个集合
                mediaInfos = new MediaInfos();
            }
            songList.ItemsSource = mediaInfos;

            //====================

        }

        //==============================================================

        private string _solfWarePath;//软件的运行路径
        private string _configPath;//各种设置信息路径
        private string _SongListXmlPath;//歌曲列表文件路径

        //==============================================================

        //属性
        public string ConfigPath { get => _configPath; }
        public string SongListXmlPath { get => _SongListXmlPath; }
        //====================================================



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
                ID3Info media = null;
                Regex regex = new Regex(@"^.+\.mp3$", RegexOptions.IgnoreCase);//使用正则表达式过滤出音频名称
                foreach (string songPath in FilePaths) {
                    if (regex.IsMatch(songPath)) {
                        //当符合正则表达式时
                        try {
                            try {
                                //获取歌曲文件
                                media = new ID3Info(songPath, true);
                                MediaInfo info = new MediaInfo(media);
                                //将歌曲信息增加到
                                if (mediaInfos.Contains(info) == false) {
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
            }
        }
    }
}
