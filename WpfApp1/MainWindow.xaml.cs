using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Storage;
using System.Windows.Forms; // NotifyIcon control
using System.Drawing; // Icon


namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon;
        public MainWindow()
        {
            InitializeComponent();


        }
        void click(object sender, RoutedEventArgs e)
        {
            string str1 = System.Environment.CurrentDirectory;
            // Configure and show a notification icon in the system tray
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.BalloonTipText = "Hello, NotifyIcon!";
            this.notifyIcon.Text = "Hello, NotifyIcon!";
            //this.notifyIcon.Icon = new System.Drawing.Icon("‪C:/Users/Administrator/Downloads/01.ico");
            this.notifyIcon.Icon = new Icon(
   System.Windows.Application.GetResourceStream(
     new Uri(
     "01.ico", UriKind.Relative)
   ).Stream
 );

            this.notifyIcon.Visible = true;
            this.notifyIcon.ShowBalloonTip(1000);
        }

        // 弹出 toast 通知（图片来自 http，image 的 placement 为 appLogoOverride，image 的 addImageQuery 为 true）
        private void ButtonShowToast_Click(object sender, RoutedEventArgs e)
        {
            string title = "featured picture of the day";
            string content = "beautiful scenery";
            //string image = "https://picsum.photos/360/180?image=104";
            string logo = "https://picsum.photos/64?image=883";
            //本地 格式png 大小 
            string image = "Images/js.png";
            string xmlString =
            $@"<toast><visual>
       <binding template='ToastGeneric'>
       <text>{title}</text>
       <text>{content}</text>
       <image src='{image}'/>
       <image src='{logo}' placement='appLogoOverride' hint-crop='circle'/>
       </binding>
      </visual></toast>";

            XmlDocument toastXml = new XmlDocument();
            toastXml.LoadXml(xmlString);

            ToastNotification toast = new ToastNotification(toastXml);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }


}
