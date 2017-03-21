using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            if ((bool)cbWrap.IsChecked)
                tbDisplayFileContents.TextWrapping = TextWrapping.Wrap;
            else
                tbDisplayFileContents.TextWrapping = TextWrapping.NoWrap;
        }

        private void clickClear(object sender, RoutedEventArgs args) { tbDisplayFileContents.Clear(); }
        private void clickWrap(object sender, RoutedEventArgs args) 
        {
            if ((bool)cbWrap.IsChecked)
                tbDisplayFileContents.TextWrapping = TextWrapping.Wrap;
            else
                tbDisplayFileContents.TextWrapping = TextWrapping.NoWrap;
        }

        private void ehDragOver(object sender, DragEventArgs args)
        {
            // As an arbitrary design decision, we only want to deal with a single file.
            if (IsSingleFile(args) != null) args.Effects = DragDropEffects.Copy;
            else args.Effects = DragDropEffects.None;

            // Mark the event as handled, so TextBox's native DragOver handler is not called.
            args.Handled = true;
        }

        private void ehDrop(object sender, DragEventArgs args)
        {
            // Mark the event as handled, so TextBox's native Drop handler is not called.
            args.Handled = true;

            string fileName = IsSingleFile(args);
            if (fileName == null) return;

            StreamReader fileToLoad = new StreamReader(fileName);
            tbDisplayFileContents.Text = fileToLoad.ReadToEnd();
            fileToLoad.Close();

            // Set the window title to the loaded file.
            this.Title = "File Loaded: " + fileName;

        }

        // If the data object in args is a single file, this method will return the filename.
        // Otherwise, it returns null.
        private string IsSingleFile(DragEventArgs args)
        {
            // Check for files in the hovering data object.
            if (args.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] fileNames = args.Data.GetData(DataFormats.FileDrop, true) as string[];
                // Check fo a single file or folder.
                if (fileNames.Length == 1)
                {
                    // Check for a file (a directory will return false).
                    if (File.Exists(fileNames[0]))
                    {
                        // At this point we know there is a single file.
                        return fileNames[0];
                    }
                }
            }
            return null;
        }
    }
}