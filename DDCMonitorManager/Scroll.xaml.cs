using System;
using System.Windows;
using System.Windows.Controls;

namespace DDCMonitorManager
{
    /// <summary>
    /// Interaction logic for Scroll.xaml
    /// </summary>
    public partial class Scroll : UserControl
    {
        private BrightnessControl brightnessControl;

        public Scroll(BrightnessControl brightnessControl)
        {
            InitializeComponent();
            this.brightnessControl = brightnessControl;

            MySlider.Value = Properties.Settings.Default.Brightness;

            //(Properties.Settings.Default.Brightness);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (brightnessControl == null)
                return;

            var value = Convert.ToInt16((sender as Slider).Value);
            brightnessControl.SetBrightness(value, 0);

            Properties.Settings.Default.Brightness = value;
            Properties.Settings.Default.Save();
        }
    }
}
