using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace WincnApp.Core
{
    public abstract class HtmlHelper
    {

        private static string _htmlString;

        public static string HtmlString
        {
            get { return _htmlString; }
            set { _htmlString = value; }
        }

        public void HttpGet(string url)
        {

            //创建WebRequest类
            HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(url));
            //设置请求方式GET POST
            request.Method = "GET";
            //返回应答请求异步操作的状态                
            request.BeginGetResponse(ResponseCallback, request);

        }

        private void ResponseCallback(IAsyncResult result)
        {
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
                //解析应答头
                //parseRecvHeader(response.Headers);
                //获取请求体信息长度
                long contentLength = response.ContentLength;

                //获取应答码
                int statusCode = (int)response.StatusCode;
                string statusText = response.StatusDescription;

                //应答头信息验证
                using (Stream stream = response.GetResponseStream())
                {
                    //获取请求信息
                    StreamReader read = new StreamReader(stream);
                    HtmlString = read.ReadToEnd();
                    HtmlHandler(HtmlString);
                }

            }
            catch (WebException e)
            {
                //连接失败               
            }
            catch (Exception e)
            {
                //异常处理                
            }

        }

        /// <summary>
        /// 获取html后处理
        /// </summary>
        /// <param name="html"></param>
        protected abstract void HtmlHandler(string html);
    }
}
