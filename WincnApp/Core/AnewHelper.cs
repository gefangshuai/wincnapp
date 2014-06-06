using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HtmlAgilityPack;

namespace WincnApp.Core
{
    /// <summary>
    /// ANew主题解析工具类
    /// </summary>
    class AnewHelper
    {
        /// <summary>
        /// 首页文章解析
        /// </summary>
        /// <returns></returns>
        public static void IndexItemParse(ObservableCollection<ArticleItems> articleItemses, HtmlDocument document)
        {
            var result = document.DocumentNode.Descendants().Where(n => n.Name == "article"); //获得所有Article
            foreach (var item in result)
            {
                try
                {
                    ArticleItems articleItems = new ArticleItems();
                    //  Title
                    var titleNode = item.ChildNodes.Where(n => n.Name == "h2");
                    articleItems.Title = titleNode.First().InnerText.Trim();
                    //  Link
                    articleItems.Link =
                        titleNode.First().ChildNodes.Where(n => n.Name == "a").First().Attributes["href"].Value.Trim();

                    var padNode = item.ChildNodes.Where(n => n.Name == "ul");
                    //  Summary
                    articleItems.Summary = item.ChildNodes.Where(n => n.Name == "div").First().ChildNodes.Where(n => n.Name == "div").ElementAt(1).ChildNodes.Where(n => n.Name == "div").First().InnerText.Trim();
                       
                    //  Category & CreateDate & CommentCount
                    var liNode = padNode.First().ChildNodes.Where(n => n.Name == "li");
                    articleItems.Category = liNode.ElementAt(0).InnerText.Trim();
                    articleItems.CreateDate = liNode.ElementAt(1).InnerText.Trim();
                    articleItems.CommentCount = int.Parse(liNode.ElementAt(2).InnerText.Trim());
                    articleItemses.Add(articleItems);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.ToString()).ShowAsync();
                }
            }
        }
    }
}
