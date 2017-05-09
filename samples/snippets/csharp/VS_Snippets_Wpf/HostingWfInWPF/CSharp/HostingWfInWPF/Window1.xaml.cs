using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

//<snippet11>
using System.Windows.Forms;
//</snippet11>

namespace HostingWfInWpf
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //<snippet10>
        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Create the MaskedTextBox control.
            MaskedTextBox mtbDate = new MaskedTextBox("00/00/0000");

            // Assign the MaskedTextBox control as the host control's child.
            host.Child = mtbDate;

            // Add the interop host control to the Grid
            // control's collection of child controls.
            this.grid1.Children.Add(host);
        }
        //</snippet10>
    }
}
