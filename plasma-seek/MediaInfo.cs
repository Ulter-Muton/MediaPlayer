using System;
using System.Collections.Generic;
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

namespace plasma_seek {
    /// <summary>
    /// 表示音频文件的类
    /// 用于listbox的显示
    /// </summary>
    public class MediaInfo {
        private ID3Info _id3Frames;
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
            Time = "未知";
            //_id3Frames.ID3v1Info.
        }
        public MediaInfo(ID3Info info) {

            _id3Frames = info;

            //以下是歌曲的具体信息=====================
            //获取标题
            Regex regex = new Regex(@"(\w+[ ]*)+(?=.mp3)");//从路径中获取歌曲名
            this.Title = regex.Match(_id3Frames.FilePath).Value;
            //获取作者
            if (_id3Frames.ID3v1Info.HaveTag && _id3Frames.ID3v1Info.Artist != "") {
                Artist = _id3Frames.ID3v1Info.Artist;
            } else {
                //ID3v1无歌曲信息
                string artist = _id3Frames.ID3v2Info.GetTextFrame("TOPE");//获取歌手名字,使用第三方的库
                if (artist != "") {
                    Artist = artist;
                }
            }
            //专辑名称
            if (_id3Frames.ID3v1Info.HaveTag && _id3Frames.ID3v1Info.Album != "") {
                Album = _id3Frames.ID3v1Info.Artist;
            } else {
                //ID3v1无歌曲信息
                string album = _id3Frames.ID3v2Info.GetTextFrame("TALB");//获取歌手名字,使用第三方的库
                if (album != "") {
                    Album = album;
                }
            }
            //专辑名称
            string time = _id3Frames.ID3v2Info.GetTextFrame("TIME");//获取歌手名字,使用第三方的库
            if (time != "") {
                Time=time;
            }

            //路径
            Path = _id3Frames.FilePath;
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
            AttachedPictureFrame[] frames=null;
            //======================================================
            //生成歌曲信息实例
            if (_id3Frames != null) {
                frames = _id3Frames.ID3v2Info.AttachedPictureFrames.Items;
            } else {
                try {
                    ID3Info songInfo = new ID3Info(this.Path, true);
                    frames = songInfo.ID3v2Info.AttachedPictureFrames.Items;
                } catch (Exception) {
                    frames = null;
                }
                
            }
            //======================================================
            if (frames==null || frames.Length == 0) {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("pack://application:,,,/Images/DiskImage.png");
                bitmap.EndInit();
                return bitmap;
            } else {
                var item = frames[0];

                //将实例保存的stream保存到bitmap中
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = item.Data;
                bitmap.EndInit();
                item.Data.Dispose();
                return bitmap;
            }
        }
        #region 属性
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Path { get; set; }
        public string Time { get; set; }
        #endregion
    }
}
