using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace plasma_seek {
    partial class SongDisPlayPanel {
        public static readonly DependencyProperty SongTitleProperty;
        public static readonly DependencyProperty MusicArtistProperty;
        public static readonly DependencyProperty ImageBytesProperty;
        static SongDisPlayPanel() {
            SongTitleProperty = DependencyProperty.Register("SongTitle", typeof(string), typeof(SongDisPlayPanel));
            MusicArtistProperty = DependencyProperty.Register("MusicArtist", typeof(string), typeof(SongDisPlayPanel));
            ImageBytesProperty = DependencyProperty.Register("ImageBytes", typeof(IList<byte>), typeof(SongDisPlayPanel));
        }
        public string SongTitle {
            get {
                return GetValue(SongTitleProperty) as string;
            }
            set {
                SetValue(SongTitleProperty, value);
            }
        }
        public string MusicArtist {
            get {
                return GetValue(MusicArtistProperty) as string;
            }
            set {
                SetValue(MusicArtistProperty, value);
            }
        }
        public IList<byte> ImageBytes {
            get {
                return GetValue(ImageBytesProperty) as byte[];
            }
            set {
                SetValue(ImageBytesProperty, value);
            }
        }
        public SongDisPlayPanel() {
            InitializeComponent();

            songName.DataContext = this;
            artist.DataContext = this;

            MemoryStream stream = null;
            BitmapImage bitmap = null;
            try {
                stream = new MemoryStream(ImageBytes as byte[]);
                //将实例保存的stream保存到bitmap中

                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            } catch (Exception) {
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("pack://application:,,,/Images/DiskImage.png");
                bitmap.EndInit();
            } finally {
                if (stream != null) {
                    stream.Flush();
                    stream.Close();
                }
            }
            Picture.Source = bitmap;
            editSong.Tag = "Edit";
            loveSong.Tag = "Love";
            addToPlayList.Tag = "AddToList";
        }
    }
}
