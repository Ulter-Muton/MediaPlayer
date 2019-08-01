using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace plasma_seek {
    /// <summary>
    /// 歌曲信息的列表,用于绑定listbox的内容
    /// </summary>
    public class MediaInfos:ObservableCollection<MediaInfo> {
        /// <summary>
        /// 从xml加载列表
        /// </summary>
        /// <param name="path">xml的路径完整名称</param>
        public static MediaInfos LoadFromXml(string path) {
            XmlSerializer xml = null;//xml处理器
            Stream xmlFile = null;
            try {
                xmlFile = new FileStream(path, FileMode.Open);
                xml = new XmlSerializer(typeof(MediaInfos));
                return xml.Deserialize(xmlFile) as MediaInfos;//返回xml记录的集合
            } catch (Exception) {
                Console.WriteLine("Cannot load songlist");
                return null;
            } finally {
                if (xmlFile!=null) {
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
            using (Stream stream=new FileStream(path,FileMode.Create)) {
                xml = new XmlSerializer(typeof(MediaInfos));
                xml.Serialize(stream, this);
            }
        }
        /// <summary>
        /// 查找列表中是否含有相同对象
        /// </summary>
        /// <param name="info">被检测对象</param>
        /// <returns></returns>
        public bool HaveItem(MediaInfo info) {
            foreach (var item in this) {
                if (item.Equals(info)) {
                    return true;
                }
            }
            return false;
        }
    }
}
