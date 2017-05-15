//<SnippetWindowLogic>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingExpressionBaseValidateWithoutUpdating
{

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Create an object and set it to the window's DataContext.
            LibraryItem item = new LibraryItem("Enter the title",
                    "Enter the call number",  DateTime.Now + new TimeSpan(14, 0, 0, 0));

            this.DataContext = item;
        }

        //<SnippetValidateWithoutUpdate>
        // Check whether the call number is valid when the
        // TextBox loses foces.
        private void CallNum_LostFocus(object sender, RoutedEventArgs e)
        {
            BindingExpression be = CallNum.GetBindingExpression(TextBox.TextProperty);

            be.ValidateWithoutUpdate();
        }
        //</SnippetValidateWithoutUpdate>


        // Show the validation error when one occurs.
        private void CallNum_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }

        }

        // Update the source data object when the user clicks
        // the submit button.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression be = CallNum.GetBindingExpression(TextBox.TextProperty);

            be.UpdateSource();
        }
    }
}
//</SnippetWindowLogic>
