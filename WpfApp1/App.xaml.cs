using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static NotifyIcon trayIcon;

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            RemoveTrayIcon();
            AddTrayIcon();
        }

        private void AddTrayIcon()
        {
            string str1 = System.Environment.CurrentDirectory;

            if (trayIcon != null)
            {
                return;
            }
            trayIcon = new NotifyIcon
            {
                   

            //Icon = new System.Drawing.Icon("C:/Users/Administrator/Downloads/01.ico"),

           Icon = new Icon(
   System.Windows.Application.GetResourceStream(
     new Uri(
     "01.ico", UriKind.Relative)
   ).Stream
 ),

            Text = "NotifyIconStd"
            };
            trayIcon.Visible = true;

            ContextMenu menu = new ContextMenu();

            MenuItem closeItem = new MenuItem();
            closeItem.Text = "Close";
            closeItem.Click += new EventHandler(delegate { this.Shutdown(); });

            MenuItem addItem = new MenuItem();
            addItem.Text = "Menu";

            menu.MenuItems.Add(addItem);
            menu.MenuItems.Add(closeItem);

            trayIcon.ContextMenu = menu;    //设置NotifyIcon的右键弹出菜单
        }

        private void RemoveTrayIcon()
        {
            if (trayIcon != null)
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                trayIcon = null;
            }
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            RemoveTrayIcon();
        }
    }

}
