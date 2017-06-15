//<SnippetWindowClosingCODEBEHIND1>
using System; // EventArgs
using System.ComponentModel; // CancelEventArgs
using System.Windows; // window

namespace CSharp
{
    public partial class DataWindow : Window
    {
        // Is data dirty
        bool isDataDirty = false;
        //</SnippetWindowClosingCODEBEHIND1>
        public DataWindow()
        {
            InitializeComponent();
        }

        void documentTextBox_TextChanged(object sender, EventArgs e)
        {
            this.isDataDirty = true;
        }

        //<SnippetWindowClosingCODEBEHIND2>
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Closing called");

            // If data is dirty, notify user and ask for a response
            if (this.isDataDirty)
            {
                string msg = "Data is dirty. Close without saving?";
                MessageBoxResult result = 
                  MessageBox.Show(
                    msg, 
                    "Data App", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    // If user doesn't want to close, cancel closure
                    e.Cancel = true;
                }
            }
        }
    }
}
//</SnippetWindowClosingCODEBEHIND2>
