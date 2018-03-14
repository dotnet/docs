//<SnippetWindowDialogResultCODEBEHIND>
using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp
{
    public partial class DialogBox : Window
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        // The accept button is a button whose IsDefault property is set to true.
        // This event is raised whenever this button is clicked, or the ENTER key
        // is pressed.
        void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            // Accept the dialog and return the dialog result
            this.DialogResult = true;
        }
    }
}
//</SnippetWindowDialogResultCODEBEHIND>