using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace plasma_seek.MyControl {
    /// <summary>
    /// 用以将drawing的image类绘制图片
    /// </summary>
    class DrawImagePanel : Panel {
        #region 表示图片的依赖属性
        public static readonly DependencyProperty SourceProperty;
        static DrawImagePanel() {
            var sourceMetadata = new FrameworkPropertyMetadata();
            sourceMetadata.Inherits = true;
            sourceMetadata.AffectsRender = true;
            sourceMetadata.DefaultValue = null;

            SourceProperty = DependencyProperty.Register("Source", typeof(System.Drawing.Image), typeof(DrawImagePanel),sourceMetadata);
        }
        /// <summary>
        /// 设置Drawing.image
        /// </summary>
        public System.Drawing.Image Source {
            get => (System.Drawing.Image)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        #endregion
        public DrawImagePanel() {

            if (Source != null) {
                
            }

        }
        protected override void OnRender(DrawingContext dc) {
            if (Source!=null) {
                var drawimage = Graphics.FromImage(Source);
                drawimage.DrawImage(Source, new Rectangle(0, 0, (int)RenderSize.Width, (int)RenderSize.Height));
            } else {
                ImageSource imgSource = new BitmapImage(new Uri("pack://application:,,,/Images/DiskImage.png"));
                dc.DrawImage(imgSource, new Rect(new System.Windows.Point(0, 0), RenderSize));
            }
            base.OnRender(dc);
        }
    }
}
