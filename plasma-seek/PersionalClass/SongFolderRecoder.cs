using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plasma_seek.PersionalClass {
    /// <summary>
    /// 这个类用来定义要记录路径到xml中
    /// </summary>
    public class SongFolderRecoder : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _path;
        public string Path {
            get {
                return _path;
            } set {
                _path = value;
            }
        }
        public SongFolderRecoder() {
            Path = "";
        }
        public SongFolderRecoder(string path) {
            Path = path;
        }
        private void OnChange() {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Path"));
        }
        public bool Equals(SongFolderRecoder song) {
            if (this.Path==song.Path) {
                return true;
            } else {
                return false;
            }
        }
    }
}
