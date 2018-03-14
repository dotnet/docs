using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace PhotoStore
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

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, RoutedEventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

        PhotoList Photos;
        PrintList PhotoTray;

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Photos = (PhotoList)(this.Resources["Photos"] as ObjectDataProvider).Data;
            Photos.Path = "...\\...\\Resources";

            PhotoTray = (PrintList)(this.Resources["PhotoTray"] as ObjectDataProvider).Data;
        }

        private void AddToPhotoTray(object sender, RoutedEventArgs e)
        {
            if (PrintTypeComboBox.SelectedItem != null)
            {
                foreach (Photo p in PhotosListBox.SelectedItems)
                {
                    Print print = GetPrintFromPhotoTray(p, PrintTypeComboBox.SelectedItem as PrintType);

                    if (print != null)
                    {
                        print.Quantity++;
                    }
                    else
                    {
                        print = new Print(p, PrintTypeComboBox.SelectedItem as PrintType, 1);
                        PhotoTray.Add(print);
                    }
                }
            }
        }

        private void Upload(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                UploadProgressBar.Value = i;
            }
        }

        private Print GetPrintFromPhotoTray(Photo photo, PrintType printtype)
        {
            foreach (Print print in PhotoTray)
            {
                if (print.Photo == photo && print.PrintType == printtype)
                {
                    return print;
                }
            }
            return null;
        }
    }
}