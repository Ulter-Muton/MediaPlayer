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
using ATL;

namespace plasma_seek {
    /// <summary>
    /// 表示音频文件的类,其字段储存歌曲的各种信息
    /// 用于listbox的显示
    /// </summary>
    public class MediaInfo : INotifyPropertyChanged {
        //private Track mediaTrack;
        private bool _isFavorite;
        private string _title;
        private string _artist;
        private string _album;
        private string _path;
        private string _gener;
        private byte[] _picture;

        public event PropertyChangedEventHandler PropertyChanged;

        protected MediaInfo() {
            Title = "未知";
            Album = "未知";
            Artist = "未知";
            Path = "";
            Gener = "未知";
            IsFavorite = false;
            PictureBytes = null;
            //Picture = null;
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
            //获取封面
            //Picture = GetImage(info);
            byte[] date = info.EmbeddedPictures[0].PictureData;
            if (date !=null&&date.Length!=0){
                PictureBytes = date;
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
           
            //======================================================
            //生成歌曲信息实例
            //if (mediaTrack != null) {
            //    //如果含有歌曲源信息
            //    pictureInfos = mediaTrack.EmbeddedPictures as List<PictureInfo>;
            //} else {
            //如果没有含有歌曲源信息
            Track songInfo=null;
            try {
                //创建一个源信息
                songInfo = new Track(this.Path, true);
            } catch (Exception) {
                return null;
            }
            if (songInfo!=null) {
                return GetImage(songInfo);
            } else {
                return null;
            }
            
        }
        public BitmapImage GetImage(Track track) {
            List<PictureInfo> pictureInfos = null;
            //======================================================
            //生成歌曲信息实例
            //if (mediaTrack != null) {
            //    //如果含有歌曲源信息
            //    pictureInfos = mediaTrack.EmbeddedPictures as List<PictureInfo>;
            //} else {
            //如果没有含有歌曲源信息
            try {
                pictureInfos = track.EmbeddedPictures as List<PictureInfo>;
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
        public void SetImaage() {

        }


        private void OnChange(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        #region 属性
        public string Title { get => _title; set{ _title = value; OnChange("Title"); } }
        public string Artist { get => _artist; set { _artist = value; OnChange("Artist"); } }
        public string Album { get => _album; set { _album = value; OnChange("Album"); } }
        public string Path { get => _path; set { _path = value; OnChange("Path"); } }
        public string Gener { get => _gener; set { _gener = value; OnChange("Gener"); } }
        public byte[] PictureBytes { get => _picture; set {_picture = value; OnChange("PictureBytes"); } }
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
