#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5A869A9ED6106A0524C53AF109AC38086390D46D0FA9FE754D55765F55CB9107"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using plasma_seek;
using plasma_seek.DateConvertor;
using plasma_seek.PersionalClass;


namespace plasma_seek {


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {

#line default
#line hidden


#line 37 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel songCurrentPanel;

#line default
#line hidden


#line 40 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image currentSongImage;

#line default
#line hidden


#line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panel;

#line default
#line hidden


#line 44 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentSongArtist;

#line default
#line hidden


#line 48 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentSongAlbum;

#line default
#line hidden


#line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentSongGenur;

#line default
#line hidden


#line 56 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentSongTitle;

#line default
#line hidden


#line 75 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button findMusic;

#line default
#line hidden


#line 78 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox songList;

#line default
#line hidden


#line 206 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement audio;

#line default
#line hidden


#line 208 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal plasma_seek.StarStopButton previous;

#line default
#line hidden


#line 210 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal plasma_seek.StarStopButton startAndPause;

#line default
#line hidden


#line 214 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal plasma_seek.StarStopButton next;

#line default
#line hidden


#line 217 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentPosition;

#line default
#line hidden


#line 218 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentTimeLabel;

#line default
#line hidden


#line 220 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider timeLineSplier;

#line default
#line hidden


#line 223 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalTime;

#line default
#line hidden


#line 224 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totlaTimeLabel;

#line default
#line hidden


#line 228 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal plasma_seek.SongToggerButton loveMusic;

#line default
#line hidden


#line 233 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider volum;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/plasma-seek;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId) {
                case 1:
                    this.myWin = ((plasma_seek.MainWindow)(target));
                    return;
                case 2:
                    this.songCurrentPanel = ((System.Windows.Controls.WrapPanel)(target));
                    return;
                case 3:
                    this.currentSongImage = ((System.Windows.Controls.Image)(target));
                    return;
                case 4:
                    this.panel = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 5:
                    this.currentSongArtist = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 6:
                    this.currentSongAlbum = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 7:
                    this.currentSongGenur = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 8:
                    this.currentSongTitle = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 9:
                    this.findMusic = ((System.Windows.Controls.Button)(target));

#line 75 "..\..\MainWindow.xaml"
                    this.findMusic.Click += new System.Windows.RoutedEventHandler(this.FindSongOnClick);

#line default
#line hidden
                    return;
                case 10:
                    this.songList = ((System.Windows.Controls.ListBox)(target));

#line 78 "..\..\MainWindow.xaml"
                    this.songList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SongSelectionChange);

#line default
#line hidden

#line 79 "..\..\MainWindow.xaml"
                    this.songList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SongListItem_DoubleClick);

#line default
#line hidden
                    return;
                case 11:
                    this.audio = ((System.Windows.Controls.MediaElement)(target));

#line 206 "..\..\MainWindow.xaml"
                    this.audio.MediaOpened += new System.Windows.RoutedEventHandler(this.Audio_MediaOpened);

#line default
#line hidden
                    return;
                case 12:
                    this.previous = ((plasma_seek.StarStopButton)(target));
                    return;
                case 13:
                    this.startAndPause = ((plasma_seek.StarStopButton)(target));
                    return;
                case 14:
                    this.next = ((plasma_seek.StarStopButton)(target));
                    return;
                case 15:
                    this.currentPosition = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 16:
                    this.currentTimeLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 17:
                    this.timeLineSplier = ((System.Windows.Controls.Slider)(target));
                    return;
                case 18:
                    this.totalTime = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 19:
                    this.totlaTimeLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 20:
                    this.loveMusic = ((plasma_seek.SongToggerButton)(target));
                    return;
                case 21:
                    this.volum = ((System.Windows.Controls.Slider)(target));

#line 233 "..\..\MainWindow.xaml"
                    this.volum.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.VolumChangeEvent);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window myWin;
    }
}

