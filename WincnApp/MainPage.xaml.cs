using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “WebView 应用程序”模板在 http://go.microsoft.com/fwlink/?LinkID=391641 上有介绍

namespace WincnApp
{
    public sealed partial class MainPage : Page
    {

        private bool isSlided = false;
        public ObservableCollection<string> MyItems { get; set; }
        public MainPage()
        {
            MyItems = new ObservableCollection<string>()
            {
                "aaaa","bbb","cccc"
            };
            this.InitializeComponent();
            MyItemsControl.DataContext = this;
            MyItemsControl.ItemsSource = MyItems;


            this.NavigationCacheMode = NavigationCacheMode.Required;


        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// 在离开此页时调用。
        /// </summary>
        /// <param name="e">描述如何导航此页的事件数据。</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
        }


        private void SlideAppBarButton_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (!isSlided)
            {
                StoryboardLeft.Begin();
            }
            else
            {
                StoryboardRight.Begin();
            }
            isSlided = !isSlided;
        }
    }
}
