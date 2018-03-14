using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;


namespace ColorPickerApp
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

        private void changeColor(object sender, RoutedEventArgs e)
        {
            colorPicker.Color = Colors.Blue;
        }

        private void getColor(object sender, RoutedEventArgs e)
        {
            textBlockCurrentColor.Text = MaincolorPicker.Color.ToString();
        }
        //<SnippetOnColorChangedSnip>
        private void OnColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            colorPickerValue.Text = e.NewValue.ToString();
        }
        //</SnippetOnColorChangedSnip>

    }
}