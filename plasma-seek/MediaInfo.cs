using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            //路径
            Path = _id3Frames.FilePath;
        }


        //=================================
        /// <summary>
        /// 用于获取mp3歌曲文件的封面
        /// </summary>
        /// <returns></returns>
        public Image GetImage() {
            var frame = _id3Frames.ID3v2Info.AttachedPictureFrames;
            if (frame.Items.Length == 0) {
                return null;
            } else {
                var item = frame.Items[0];
                return Image.FromStream(item.Data);
            }
        }
        //======================================
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Path { get; set; }
    }
}
