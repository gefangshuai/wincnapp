using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WincnApp
{
    /// <summary>
    /// 文章列表
    /// </summary>
    public class ArticleItems
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string CreateDate { get; set; }
        public string CategoryLink { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public int CommentCount  { get; set; }
    }
}
