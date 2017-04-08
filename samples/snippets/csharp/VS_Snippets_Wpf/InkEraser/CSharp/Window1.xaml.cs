using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace InkEraserDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
            : base()
        {
            InitializeComponent();
            
        }


        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

       // Sample event handler:  
        private void ToggleErase(object sender, RoutedEventArgs e) 
        {
            //if (myInkEraser.Mode == InkMode.Ink)
            //{
            //    myInkEraser.Mode = InkMode.Erase;
            //    btnToggleMode.Content = "Ink Mode";

            //}
            //else
            //{
            //    myInkEraser.Mode = InkMode.Ink;
            //    btnToggleMode.Content = "Erase Mode";
            //}
        }

        private void ResetInk(object sender, RoutedEventArgs e)
        {
            inkEraser1.ResetInk();
        }

        private void SaveStrokes(object sender, RoutedEventArgs e)
        {
            //string strokes = inkEraser1.SaveStrokes();

            //Clipboard.SetDataObject(strokes, true);
            //MessageBox.Show(strokes);
        }
    }
}