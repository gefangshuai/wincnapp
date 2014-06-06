using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace WincnApp.Core
{
    class AppUtils
    {
        public static void toastMessage(string title, string content)
        {
            string toastStr = "<toast duration='long' launch='Page1'>"//通过给Toast节点添加一个duration属性来设置Toast通知的显示时间长(long)短(short)
                               + "<visual version='1'>"
                               + "<binding template='ToastText02'>"
                               + "<text id='1'>Heading text</text>"
                               + "<text id='2'>我来试一试</text>"
                               + "</binding>"
                               + "</visual>"
                               + "<audio src='ms-winsoundevent:Notification.Mail' loop='true'/>"//可以在toast的节点下面设置声音节点,当声音设置循环的时候，duration必须设置为long，不播放声音的时候需要设置audio元素的属性silent=true
                               + "</toast>";
            XmlDocument toastXml = new XmlDocument();
            toastXml.LoadXml(toastStr);
            ToastNotification toastNotification = new ToastNotification(toastXml);
            //在调试前必须先在程序清单中Package.appxmanifest文件中将支持Toast通知设置为'是'
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }
    }
}
