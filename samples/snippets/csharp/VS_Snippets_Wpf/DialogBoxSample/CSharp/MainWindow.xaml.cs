//<SnippetOpenMarginsDialogCODEBEHIND1>
//<SnippetOpenFindDialogCODEBEHIND1>
//<SnippetOpenMarginsDialogProcessReturnCODEBEHIND1>
//<SnippetOpenFindDialogResultCODEBEHIND1>
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace SDKSample
{
    public partial class MainWindow : Window
    {
        //</SnippetOpenMarginsDialogProcessReturnCODEBEHIND1>
        //</SnippetOpenMarginsDialogCODEBEHIND1>
        //</SnippetOpenFindDialogCODEBEHIND1>
        //</SnippetOpenFindDialogResultCODEBEHIND1>
        bool needsToBeSaved;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Closing
        void mainWindow_Closing(object sender, CancelEventArgs e)
        {
            // If the document needs to be saved
            if (this.needsToBeSaved)
            {
                // Configure the message box
                string messageBoxText = "This document needs to be saved. Click Yes to save and exit, No to exit without saving, or Cancel to not exit.";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;

                // Display message box
                MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);

                // Process message box results
                switch (messageBoxResult)
                {
                    case MessageBoxResult.Yes: // Save document and exit
                        SaveDocument();
                        break;
                    case MessageBoxResult.No: // Exit without saving
                        break;
                    case MessageBoxResult.Cancel: // Don't exit
                        e.Cancel = true;
                        break;
                }
            }
        }

        void fileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument();
        }
        void fileSave_Click(object sender, RoutedEventArgs e)
        {
            SaveDocument();
        }
        void filePrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument();
        }
        void fileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //<SnippetOpenFindDialogCODEBEHIND2>
        void editFindMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate the dialog box
            FindDialogBox dlg = new FindDialogBox(this.documentTextBox);

            // Configure the dialog box
            dlg.Owner = this;
            dlg.TextFound += new TextFoundEventHandler(dlg_TextFound);

            // Open the dialog box modally
            dlg.Show();
        }
        //</SnippetOpenFindDialogCODEBEHIND2>

        //<SnippetOpenMarginsDialogCODEBEHIND2>
        //<SnippetOpenMarginsDialogProcessReturnCODEBEHIND2>
        void formatMarginsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //</SnippetOpenMarginsDialogProcessReturnCODEBEHIND2>
            // Instantiate the dialog box
            MarginsDialogBox dlg = new MarginsDialogBox();

            // Configure the dialog box
            dlg.Owner = this;
            dlg.DocumentMargin = this.documentTextBox.Margin;

            // Open the dialog box modally 
            dlg.ShowDialog();

            //</SnippetOpenMarginsDialogCODEBEHIND2>
            //<SnippetOpenMarginsDialogProcessReturnCODEBEHIND3>
            // Process data entered by user if dialog box is accepted
            if (dlg.DialogResult == true)
            {
                // Update fonts
                this.documentTextBox.Margin = dlg.DocumentMargin;
            }
            //<SnippetOpenMarginsDialogCODEBEHIND3>
        }
        //</SnippetOpenMarginsDialogCODEBEHIND3>
        //</SnippetOpenMarginsDialogProcessReturnCODEBEHIND3>

        void formatFontMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate the dialog box
            FontDialogBox dlg = new FontDialogBox();

            // Configure the dialog box
            dlg.Owner = this;
            dlg.FontFamily = this.documentTextBox.FontFamily;
            dlg.FontSize = this.documentTextBox.FontSize;
            dlg.FontWeight = this.documentTextBox.FontWeight;
            dlg.FontStyle = this.documentTextBox.FontStyle;

            // Open the dialog box modally 
            dlg.ShowDialog();

            // Process data entered by user if dialog box is accepted
            if (dlg.DialogResult == true)
            {
                // Update fonts
                this.documentTextBox.FontFamily = dlg.FontFamily;
                this.documentTextBox.FontSize = dlg.FontSize;
                this.documentTextBox.FontWeight = dlg.FontWeight;
                this.documentTextBox.FontStyle = dlg.FontStyle;
            }
        }

        // Detect when document has been altered
        void documentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.needsToBeSaved = true;
        }

        void OpenDocument()
        {
            // Instantiate the dialog box
            OpenFileDialog dlg = new OpenFileDialog();

            // Configure open file dialog box
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".wpf"; // Default file extension
            dlg.Filter = "Word Processor Files (.wpf)|*.wpf"; // Filter files by extension

            // Open the dialog box modally
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
        }
        void SaveDocument()
        {
            // Configure save file dialog
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".wpf"; // Default file extension
            dlg.Filter = "Word Processor Files (.wpf)|*.wpf"; // Filter files by extension

            // Show save file dialog
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }
        void PrintDocument()
        {
            // Configure printer dialog
            PrintDialog dlg = new PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            // Show save file dialog
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog results
            if (result == true)
            {
                // Print document
            }
        }

        //<SnippetOpenFindDialogResultCODEBEHIND2>
        void dlg_TextFound(object sender, EventArgs e)
        {
            // Get the find dialog box that raised the event
            FindDialogBox dlg = (FindDialogBox)sender;

            // Get find results and select found text
            this.documentTextBox.Select(dlg.Index, dlg.Length);
            this.documentTextBox.Focus();
        }
        //<SnippetOpenMarginsDialogCODEBEHIND4>
        //<SnippetOpenFindDialogCODEBEHIND3>
        //<SnippetOpenMarginsDialogProcessReturnCODEBEHIND4>
    }
}
//</SnippetOpenMarginsDialogCODEBEHIND4>
//</SnippetOpenMarginsDialogProcessReturnCODEBEHIND4>
//</SnippetOpenFindDialogCODEBEHIND3>
//</SnippetOpenFindDialogResultCODEBEHIND2>