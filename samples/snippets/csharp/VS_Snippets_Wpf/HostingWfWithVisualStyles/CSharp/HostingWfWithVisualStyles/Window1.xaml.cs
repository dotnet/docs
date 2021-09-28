// <snippet10>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HostingWfWithVisualStyles
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // <snippet11>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Comment out the following line to disable visual
            // styles for the hosted Windows Forms control.
            System.Windows.Forms.Application.EnableVisualStyles();

            // Create a WindowsFormsHost element to host
            // the Windows Forms control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Create a Windows Forms tab control.
            System.Windows.Forms.TabControl tc = new System.Windows.Forms.TabControl();
            tc.TabPages.Add("Tab1");
            tc.TabPages.Add("Tab2");

            // Assign the Windows Forms tab control as the hosted control.
            host.Child = tc;

            // Assign the host element to the parent Grid element.
            this.grid1.Children.Add(host);
        }
        // </snippet11>
    }
}
// </snippet10>