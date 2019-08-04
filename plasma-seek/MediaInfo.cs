using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ID3;
using ID3.ID3v2Frames.BinaryFrames;
using ATL;

namespace plasma_seek {
    /// <summary>
    /// 表示音频文件的类
    /// 用于listbox的显示
    /// </summary>
    public class MediaInfo : INotifyPropertyChanged {
        //private Track mediaTrack;
        private bool _isFavorite;

        public event PropertyChangedEventHandler PropertyChanged;

        //private string _title;
        //private string _artist;
        //private string _album;
        //private string _path;
        //private Image _albumImage;
        protected MediaInfo() {
            Title = "未知";
            Album = "未知";
            Artist = "未知";
            Path = "";
            Gener = "未知";
            IsFavorite = false;
            //_id3Frames.ID3v1Info.
        }
        public MediaInfo(Track info) {

            //mediaTrack = info;

            //以下是歌曲的具体信息=====================
            //获取标题
            Regex regex = new Regex(@"(\w+( *-* *)*)+(?=[(.mp3)(.flav)])");//从路径中获取歌曲名
            if (info.Title != null && info.Title.Length != 0) {
                this.Title = info.Title;
            }
            this.Title = regex.Match(info.Path).Value;
            //获取作者
            if (info.Artist != "") {
                Artist = info.Artist;
            } else {
                //什么都不做
            }
            //专辑名称
            if (info.Album != "") {
                Album = info.Album;
            } else {
                //什么都不做
            }
            //专辑名称
            string gener = info.Genre;//获取歌曲类型
            if (gener != "") {
                Gener = gener;
            }

            //路径
            Path = info.Path;

        }
        /// <summary>
        /// 定义对比
        /// </summary>
        /// <param name="info">被比较对象</param>
        /// <returns></returns>
        public bool Equals(MediaInfo info) {
            return this.Path == info.Path;
        }


        //=================================
        /// <summary>
        /// 用于获取mp3歌曲文件的封面
        /// </summary>
        /// <returns></returns>
        public BitmapImage GetImage() {
            List<PictureInfo> pictureInfos = null;
            //======================================================
            //生成歌曲信息实例
            //if (mediaTrack != null) {
            //    //如果含有歌曲源信息
            //    pictureInfos = mediaTrack.EmbeddedPictures as List<PictureInfo>;
            //} else {
            //如果没有含有歌曲源信息
            try {
                //创建一个源信息
                Track songInfo = new Track(this.Path, true);
                pictureInfos = songInfo.EmbeddedPictures as List<PictureInfo>;
            } catch (Exception) {
                pictureInfos = null;
            }


            //======================================================
            var bitmap = new BitmapImage();
            if (pictureInfos != null && pictureInfos.Count != 0) {
                //歌曲以及嵌入图片
                var itemInfo = pictureInfos[0];
                MemoryStream stream = null;
                try {
                    stream = new MemoryStream(itemInfo.PictureData);
                    //将实例保存的stream保存到bitmap中

                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();

                    return bitmap;
                } catch (Exception) {
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("pack://application:,,,/Images/DiskImage.png");
                    bitmap.EndInit();
                    return bitmap;
                } finally {
                    if (stream != null) {
                        stream.Flush();
                        stream.Close();
                    }
                }
            } else {
                //如果没有嵌入图片
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("pack://application:,,,/Images/DiskImage.png");
                bitmap.EndInit();
                return bitmap;
            }

        }

        private void OnChange(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        #region 属性
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Path { get; set; }
        public string Gener { get; set; }
        public bool IsFavorite {
            get {
                return _isFavorite;
            }
            set {
                _isFavorite = value;
                OnChange("IsFavorite");
            }
        }
        #endregion
    }
}
