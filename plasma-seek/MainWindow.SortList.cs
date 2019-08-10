using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace plasma_seek {
    partial class voidSTheMusic {
        private void FavoriteItem_Click(object sender, MouseButtonEventArgs e) {
            mediasListView.SortDescriptions.Clear();//清空排序历史
            //第一排序
            mediasListView.SortDescriptions.Add(new SortDescription("IsFavorite",ListSortDirection.Descending));
            //第二排序
            mediasListView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            mediasListView.Refresh();
            songList.ItemsSource = mediasListView;
        }

        private void ArtistItem_Click(object sender, MouseButtonEventArgs e) {
            mediasListView.SortDescriptions.Clear();//清空排序历史
            mediasListView.SortDescriptions.Add(new SortDescription("Artist", ListSortDirection.Ascending));
            mediasListView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            mediasListView.Refresh();
            songList.ItemsSource = mediasListView;
        }

        private void TypeItem_Click(object sender, MouseButtonEventArgs e) {
            mediasListView.SortDescriptions.Clear();//清空排序历史
            mediasListView.SortDescriptions.Add(new SortDescription("Gener", ListSortDirection.Ascending));
            mediasListView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            mediasListView.Refresh();
            songList.ItemsSource = mediasListView;
        }
    }
}
