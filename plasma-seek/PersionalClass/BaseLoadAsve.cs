using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace plasma_seek.PersionalClass {
    /// <summary>
    /// 用于xml化类的基类
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    /// <typeparam name="Ts">元素对应的集合类型</typeparam>
    public class BaseLoadAsve<T,Ts>:ObservableCollection<T> {
        public static object LoadFromXml(string path) {
            XmlSerializer xml = null;//xml处理器
            Stream xmlFile = null;
            try {
                xmlFile = new FileStream(path, FileMode.Open);
                xml = new XmlSerializer(typeof(Ts));
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
                xml = new XmlSerializer(typeof(Ts));
                xml.Serialize(stream, this);
            }
        }
    }
}
