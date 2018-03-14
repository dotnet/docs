
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.CustomControls
{
    /// <summary>
    /// Interaction logic for SampleViewer.xaml
    /// </summary>

    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();

        }

        private void pageLoaded(object sender, RoutedEventArgs e)
        {
            w = new ColorPickerDialog();
            w.Owner = Application.Current.MainWindow;
        }

        private ColorPickerDialog w;

        private void buttonClicked(object sender, RoutedEventArgs e)
        {

            w.StartingColor = Colors.Blue;
            MessageBox.Show(w.ShowDialog().ToString());


        }


    }
}