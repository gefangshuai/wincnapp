using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using HtmlAgilityPack;

namespace WincnApp.Core
{
    /// <summary>
    /// 解析首页代码的Helper
    /// </summary>
    class IndexHtmlHelper : HtmlHelper
    {
        private CoreDispatcher simpleDispatcher;                    // 刷新UI用
        public ObservableCollection<ArticleItems> ArticleLists { get; set; }
        public ProgressRing ProgressRing { get; set; }
        public IndexHtmlHelper(ProgressRing progressRing, ObservableCollection<ArticleItems> articleLists)
        {
            this.ProgressRing = progressRing;
            this.ArticleLists = articleLists;
            simpleDispatcher = Window.Current.Dispatcher;
        }

        protected override void HtmlHandler(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                simpleDispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    var document = new HtmlDocument();
                    document.LoadHtml(html);
                    AnewHelper.IndexItemParse(ArticleLists, document);
                    ProgressRing.IsActive = false;
                });
            }
        }
    }
}
