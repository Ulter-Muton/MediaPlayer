using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace plasma_seek {
    /// <summary>
    /// 用来记录播放器设置的类
    /// </summary>
    public class PlayerSetting {

        public PlayerSetting() {
            //设置默认值
            this.AudioIndex = 0;
            this.IsRandom = false;
            this.IsRecycle = false;
            this.IsSIngleRecycle = false;
            this.Volumn = 0.8;
            this.IsFirstUsing = true;
        }
        public int AudioIndex { get; set; }
        public bool IsRandom { get; set; }
        public bool IsRecycle { get; set; }
        public bool IsSIngleRecycle { get; set; }
        public double Volumn { get; set; }
        public bool IsFirstUsing { get; set; }
        public static object LoadFromXml(string path) {
            XmlSerializer xml = null;//xml处理器
            Stream xmlFile = null;
            try {
                xmlFile = new FileStream(path, FileMode.Open);
                xml = new XmlSerializer(typeof(PlayerSetting));
                return xml.Deserialize(xmlFile);//返回xml记录的集合
            } catch (Exception) {
                Console.WriteLine("Cannot load songlist");
                return null;
            } finally {
                if (xmlFile != null) {
                    xmlFile.Close();
                }
            }
        }
        /// <summary>
        /// 将集合写入xml并且保存
        /// </summary>
        /// <param name="path">xml的储存路径</param>
        public void SaveToXml(string path) {
            XmlSerializer xml = null;
            using (Stream stream = new FileStream(path, FileMode.Create)) {
                xml = new XmlSerializer(typeof(PlayerSetting));
                xml.Serialize(stream, this);
            }
        }
    }
}

