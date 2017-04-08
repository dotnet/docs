//<SnippetAddItemLogic>
using System.Windows;
using System.Windows.Controls;

namespace IEditableCollectionViewAddItemExample
{
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        // Select all text when the TextBox gets focus.
        private void TextBoxFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            tbx.SelectAll();

        }
    }
}
//</SnippetAddItemLogic>
