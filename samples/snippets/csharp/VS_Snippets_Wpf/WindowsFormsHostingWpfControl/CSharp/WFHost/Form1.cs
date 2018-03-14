// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Controls;

// <snippet10>
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Media;
// </snippet10>

namespace WFHost
{
    partial class Form1 : Form
    {
        // <snippet2>
        private ElementHost ctrlHost;
        private MyControls.MyControl1 wpfAddressCtrl;
        System.Windows.FontWeight initFontWeight;
        double initFontSize;
        System.Windows.FontStyle initFontStyle;
        System.Windows.Media.SolidColorBrush initBackBrush;
        System.Windows.Media.SolidColorBrush initForeBrush;
        System.Windows.Media.FontFamily initFontFamily;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrlHost = new ElementHost();
            ctrlHost.Dock = DockStyle.Fill;
            panel1.Controls.Add(ctrlHost);
            wpfAddressCtrl = new MyControls.MyControl1();
            wpfAddressCtrl.InitializeComponent();
            ctrlHost.Child = wpfAddressCtrl;

            wpfAddressCtrl.OnButtonClick +=
                new MyControls.MyControl1.MyControlEventHandler(
                avAddressCtrl_OnButtonClick);
            wpfAddressCtrl.Loaded += new RoutedEventHandler(
                avAddressCtrl_Loaded);
        }

        void avAddressCtrl_Loaded(object sender, EventArgs e)
        {
            initBackBrush = (SolidColorBrush)wpfAddressCtrl.MyControl_Background;
            initForeBrush = wpfAddressCtrl.MyControl_Foreground;
            initFontFamily = wpfAddressCtrl.MyControl_FontFamily;
            initFontSize = wpfAddressCtrl.MyControl_FontSize;
            initFontWeight = wpfAddressCtrl.MyControl_FontWeight;
            initFontStyle = wpfAddressCtrl.MyControl_FontStyle;
        }
        // </snippet2>

        // <snippet3>
        void avAddressCtrl_OnButtonClick(
            object sender,
            MyControls.MyControl1.MyControlEventArgs args)
        {
            if (args.IsOK)
            {
                lblAddress.Text = "Street Address: " + args.MyStreetAddress;
                lblCity.Text = "City: " + args.MyCity;
                lblName.Text = "Name: " + args.MyName;
                lblState.Text = "State: " + args.MyState;
                lblZip.Text = "Zip: " + args.MyZip;
            }
            else
            {
                lblAddress.Text = "Street Address: ";
                lblCity.Text = "City: ";
                lblName.Text = "Name: ";
                lblState.Text = "State: ";
                lblZip.Text = "Zip: ";
            }
        }
        // </snippet3>

        // <snippet4>
        private void radioBackgroundOriginal_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_Background = initBackBrush;
        }

        private void radioBackgroundLightGreen_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_Background = new SolidColorBrush(Colors.LightGreen);
        }

        private void radioBackgroundLightSalmon_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_Background = new SolidColorBrush(Colors.LightSalmon);
        }

        private void radioForegroundOriginal_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_Foreground = initForeBrush;
        }

        private void radioForegroundRed_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_Foreground = new System.Windows.Media.SolidColorBrush(Colors.Red);
        }

        private void radioForegroundYellow_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_Foreground = new System.Windows.Media.SolidColorBrush(Colors.Yellow);
        }

        private void radioFamilyOriginal_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontFamily = initFontFamily;
        }

        private void radioFamilyTimes_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontFamily = new System.Windows.Media.FontFamily("Times New Roman");
        }

        private void radioFamilyWingDings_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontFamily = new System.Windows.Media.FontFamily("WingDings");
        }

        private void radioSizeOriginal_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontSize = initFontSize;
        }

        private void radioSizeTen_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontSize = 10;
        }

        private void radioSizeTwelve_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontSize = 12;
        }

        private void radioStyleOriginal_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontStyle = initFontStyle;
        }

        private void radioStyleItalic_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontStyle = System.Windows.FontStyles.Italic;
        }

        private void radioWeightOriginal_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontWeight = initFontWeight;
        }

        private void radioWeightBold_CheckedChanged(object sender, EventArgs e)
        {
            wpfAddressCtrl.MyControl_FontWeight = FontWeights.Bold;
        }
        // </snippet4>
    }
}
// </snippet1>