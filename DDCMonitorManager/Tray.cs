using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace DDCMonitorManager
{
    class Tray
    {
        Window mainWindow;
        ContextMenu contextMenu;

        public Tray(Window window)
        {
            mainWindow = window;

            System.Windows.Forms.NotifyIcon notifyIcon = null;
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.Click += new EventHandler(notifyIcon_Click);
            notifyIcon.Visible = true;

            contextMenu = new ContextMenu();
            var menu = new MenuItem();
            contextMenu.MenuItems.AddRange(
                new MenuItem[] { menu });

            menu.Index = 0;
            menu.Text = "Quit";
            menu.Click += (s, e) =>
            {
                window.Close();
            };

            notifyIcon.ContextMenu = contextMenu;
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Resources["MainColor"] = SystemParameters.WindowGlassBrush;

            mainWindow.Show();
            mainWindow.Activate();
            var doubleAnim = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
            doubleAnim.EasingFunction = new BackEase();
            mainWindow.BeginAnimation(UIElement.OpacityProperty, doubleAnim);

        }
    }
}
