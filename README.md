# MediaPlayer
一个用wpf写的基础音乐播放器
<h2>引用的工具集</h2>
<h3>https://github.com/Zeugma440/atldotnet.git</h3>

<img src="https://github.com/Ulter-Muton/Pictures/blob/master/%E5%9B%BE%E6%A0%87.ico" alt="图标" width="60" height="60" />
<a href="https://github.com/Ulter-Muton/MediaPlayer/blob/master/plasma-seek/bin/Debug/Player.zip">软件在这里</a>
<p>涉及到显示的控件大都重新写模板,让界面更美观</p>
<h2>项目明细</h2>
<p style="text-indent:-2em;padding:2em">项目结构
	<pre>
	plasma-seek============================================项目名称
		DateConvertor======================================数据转换相关类,用于数据绑定过程的数据之间的转换
			BitmapImageToILixtConvertor.cs=================图像的byte[]信息转换成位图
			SliderIsEnabledConvertor.cs====================返回true/false来设置滚动条是否可用
			StringtoSecondConvertor.cs=====================将00:00格式的字符串转换为秒
			TimeSpanFormat.cs==============================将时间转换成00:00格式的字符串
			TimeSpanToDoubleConvertor.cs===================将时间转换成double类
			ToggleButtonCheckedVisibilityConvertor.cs======判断数据返回true/false,控制控件是否可见
		Images=============================================图像文件夹
		MyException========================================自定义异常
			CannotConverterException.cs================转换失败时抛出,可附带信息
		PersinalClass======================================需要用到的自定义类型
			AudioPositionWatcher.cs========================作为连接Mediaelement和被绑定的element主要用来控制音乐的时间轴	
			BaseLoadAsve.cs================================一个实现了ObservableCollection的具有xml和类之间储存和解析的方法
			PlayList.cs===================================表示播放列表的集合,实现了ObservableColleaction</li>
		PlayListItem.cs================================类型表示播放列表的其中一个item记录的数据是什么
		SongFolderRecoders.cs==========================类表示了需要记录的信息和实现了类型和xml的相互转
		App.xaml
		App.xaml.cs
		MainWIndow.PlayControl.cs==========================Partial类含有控制音乐播放的相关方法
		mainWindow.SeatchPart.cs===========================Partial类含有控制查找的相关方法
		mainWindow.SortList.cs=============================Partial类含有控制音乐列表排序的相关方法
		MainWindow.xaml====================================程序的外观
		MainWindow.xaml.cs=================================程序入口,含有程序启动的相关初始化的方法
		MediaInfo.cs=======================================实现类INotifyPropertyChange的用以记录音频对象相关信息的类
		MediaInfos.cs======================================实现ObservableCollection的集合,当集合元素改变(增加音乐)时可发出通知
		MyEnum.cs==========================================相关枚举
		MySlider.Xaml======================================自定义滚动条外观
		MyTreeViewItem.xaml================================自定义树表外观
		MyTreeViewItem.xaml.cs
		PlayerSetting.cs===================================类用以记录播放器的相关信息
		ShowBlock.xaml=====================================自定义的显示块
		ShowBlock.xaml.cs==================================自定义的显示块
		SongDisPlayPanel.xaml==============================boxlist内部Item的显示效果
		SongToggerButton.xaml==============================表示喜爱,随机,循环等的按钮
		SongToggerButton.xaml.cs
		StarStopButton.xaml================================表示开始暂停的相关按钮
		StarStopButton.xaml.cs

		图标.ico</pre></p>
<p>界面截图</P>
<img src="https://github.com/Ulter-Muton/Pictures/blob/master/Annotation%202019-08-11%20102651.png"/>
