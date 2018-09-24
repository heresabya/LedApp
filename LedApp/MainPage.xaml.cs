using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Devices.Gpio;
using Windows.UI.Core;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LedApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int LED_PIN = 17;
        //private const int BUTTON_PIN = 5;
        private GpioPin ledPin;
        

        public MainPage()
        {
            this.InitializeComponent();
            InitGPIO();

        }
        
        void InitGPIO()
        {
            var gpio = GpioController.GetDefault();
            if (gpio == null)
            {
                GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }
            //buttonPin = gpio.OpenPin(BUTTON_PIN);
            ledPin = gpio.OpenPin(LED_PIN);
        }
        private void btnGPIONo_Click(object sender, RoutedEventArgs e)
        {
                ledPin.Write(GpioPinValue.Low);
                ledPin.SetDriveMode(GpioPinDriveMode.Output);
        }

        private void btnGPIOYes_Click(object sender, RoutedEventArgs e)
        {
            ledPin.Write(GpioPinValue.High);
            ledPin.SetDriveMode(GpioPinDriveMode.Output);
        }
    }
}
