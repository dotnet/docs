using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CSharp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        void messageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetMsgBoxConfigureCODEBEHIND>
            // Configure the message box to be displayed
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            //</SnippetMsgBoxConfigureCODEBEHIND>

            //<SnippetMsgBoxShowCODEBEHIND>
            // Display message box
            MessageBox.Show(messageBoxText, caption, button, icon);
            //</SnippetMsgBoxShowCODEBEHIND>

            //<SnippetMsgBoxShowAndResultCODEBEHIND1>
            // Display message box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button
                    // ...
                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
                case MessageBoxResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    break;
            }
            //</SnippetMsgBoxShowAndResultCODEBEHIND1>
        }

        void openFileDialog_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetOpenFileDialogBoxCODEBEHIND>
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
            //</SnippetOpenFileDialogBoxCODEBEHIND>
        }

        void saveFileDialog_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetSaveFileDialogBoxCODEBEHIND>
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
            //</SnippetSaveFileDialogBoxCODEBEHIND>
        }

        void printDialog_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetPrintDialogBoxCODEBEHIND>
            // Configure printer dialog box
            System.Windows.Controls.PrintDialog dlg = new System.Windows.Controls.PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Print document
            }
            //</SnippetPrintDialogBoxCODEBEHIND>
        }
    }
}