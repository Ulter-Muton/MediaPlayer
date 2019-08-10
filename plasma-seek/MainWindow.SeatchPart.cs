using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using plasma_seek.DateConvertor;
using System.Windows.Input;

namespace plasma_seek {
    partial class voidSTheMusic {
        //private void Toggle_Checked(object sender, RoutedEventArgs e) {
        //    ToggleButton togg = e.Source as ToggleButton;
        //    if (togg != null) {
        //        searchText.Visibility = (bool)togg.IsChecked ? Visibility.Visible : Visibility.Collapsed;
        //        searchButton.Visibility = (bool)togg.IsChecked ? Visibility.Visible : Visibility.Collapsed;
        //        ShowResaultpanel.Visibility = (bool)togg.IsChecked ? Visibility.Visible : Visibility.Collapsed;
        //    }
        //}

        private void SearchButton_OnClick(object sender, RoutedEventArgs e) {

            ShowResaultpanel.Children.Clear();//清理之前的结果

            string pattern = searchText.Text;
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (var item in mediaInfos) {
                if (regex.Match(item.Title).Success || regex.Match(item.Artist).Success) {
                    //如果匹配了标题或者名称

                    //创建绑定
                    Binding visibleBInding = new Binding();
                    visibleBInding.Source = toggle;
                    visibleBInding.Path = new PropertyPath("IsChecked");
                    visibleBInding.Converter = new ToggleButtonCheckedVisibilityConvertor();

                    ShowBlock block = new ShowBlock();
                    block.SetBinding(ShowBlock.VisibilityProperty, visibleBInding);
                    block.AddHandler(Button.ClickEvent, new RoutedEventHandler(PlayMusinInsideButton_OnClick));

                    block.indexBox.Text = item.Title;

                    ShowResaultpanel.Children.Add(block);
                    ShowResaultpanel.Visibility = Visibility.Visible;
                }
            }



        }

        private void PlayMusinInsideButton_OnClick(object sender, RoutedEventArgs e) {
            ShowBlock showBlock = sender as ShowBlock;
            if (showBlock != null) {

                //利用已经有的方法实现播放音乐
                //选择音乐
                RoutedEventArgs args = new RoutedEventArgs();
                args.RoutedEvent = TextBlock.MouseDownEvent;
                args.Source = showBlock.indexBox;
                SelectedTheMusic(showBlock.indexBox, args);

                //播放音乐
                MediaInfo info = songList.SelectedValue as MediaInfo;
                mediasListView.MoveCurrentTo(info);
                ControlButtonIntinial();
                timeLineSplier.IsEnabled = true;
                AudioPlay(info);

                toggle.IsChecked = false;//卷起查找工具

                e.Handled = true;
            }
        }

        /// <summary>
        /// 点击查找结果,定位到listbox的音乐位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedTheMusic(object sender, RoutedEventArgs e) {
            TextBlock block = e.Source as TextBlock;
            if (block != null) {
                foreach (var item in mediaInfos) {
                    if (item.Title == block.Text) {
                        //对比歌曲标题
                        songList.SelectedItem = item;
                    }
                }
                e.Handled = true;
            }
        }
        /// <summary>
        /// 当查找工具失去焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchToolLostFocus(object sender, RoutedEventArgs e) {
            //ShowResaultpanel.Children.Clear();
            //toggle.IsChecked = false;
            //searchText.Text = "";
        }
    }
}
