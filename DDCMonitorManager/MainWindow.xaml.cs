using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace DDCMonitorManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private BrightnessControl brightnessControl;
        const int WIDTH = 360;
        const int HEIGHT = 100;

        bool firstRun = true;

        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
            LostKeyboardFocus += new KeyboardFocusChangedEventHandler(lostKeyboardFocus);
            Window window = Window.GetWindow(this);
            var wih = new WindowInteropHelper(window);
            IntPtr hWnd = wih.Handle;
            brightnessControl = new BrightnessControl(hWnd);
            InitializeSliders(brightnessControl.GetMonitors());

            SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Dark;

            var w = System.Windows.SystemParameters.PrimaryScreenWidth;
            var h = System.Windows.SystemParameters.PrimaryScreenHeight;

            var taskBarHeight = h - System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            Top = h - HEIGHT - taskBarHeight;
            Left = w - WIDTH;

            var tray = new Tray(this);
            Hide();
        }

        private void lostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (firstRun)
            {
                firstRun = false;
                return;
            }
            Hide();
        }

        private void InitializeSliders(uint count)
        {
            // TODO: Add multi monitor support.
            //for (int i = 0; i<count; ++i)
            //{
            var scroll = new Scroll(brightnessControl);
            GridRoot.Children.Add(scroll);
            //}
        }
    }
}
