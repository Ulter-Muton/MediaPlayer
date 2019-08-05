using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace plasma_seek.DateConvertor {
    [ValueConversion(typeof(IList<byte>),typeof(BitmapImage))]
    class BitmapImageToILixtConvertor : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            byte[] bt= (value as IList<byte>).ToArray();
            if (bt!=null&&bt.Length>0) {
                MemoryStream stream = null;
                BitmapImage bitmap = new BitmapImage();
                try {
                    stream = new MemoryStream(bt);
                    //将实例保存的stream保存到bitmap中

                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();

                    return bitmap;
                } catch (Exception) {
                    bitmap = new BitmapImage();
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
                throw new Exception();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
