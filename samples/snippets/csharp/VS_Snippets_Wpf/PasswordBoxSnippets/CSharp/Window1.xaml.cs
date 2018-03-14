using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace PasswordBoxSnippets
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

        void WindowLoaded (Object sender, RoutedEventArgs args)
        {
        }

        // <Snippet_PwBox_PwChanged>
        private int pwChanges = 0;

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            // Increment a counter each time the event fires.
            ++pwChanges;
        }
        // </Snippet_PwBox_PwChanged>

        void ChangeMaxLen()
        {
            // <Snippet_PwdBox_MaxLen>
            // Set the new maximum input length for passwords to 128 characters.
            pwdBox.MaxLength = 128;
            // </Snippet_PwdBox_MaxLen>
        }

        void ChangePwdChar()
        {
            // <Snippet_PwdBox_PwdChar>
            // Change the password masking character to a period.
            pwdBox.PasswordChar = '.';
            // </Snippet_PwdBox_PwdChar>

        }

        void ClearPwdBox()
        {
            {
                // <Snippet_PwdBox_Clear>
                PasswordBox pwdBox = new PasswordBox();
                pwdBox.Password = "Open Sesame!";

                // Clear any contents of the PasswordBox, as well as the value stored in the Password property.
                pwdBox.Clear();
                // </Snippet_PwdBox_Clear>
            }
        }

        void PwdProperty()
        {
            {
                // <Snippet_PwdBox_Pwd>
                PasswordBox pwdBox = new PasswordBox();
                pwdBox.Password = "Open Sesame!";
                // </Snippet_PwdBox_Pwd>
            }
        }

        void PwdPaste()
        {
            // <Snippet_PwdBox_Paste>
            // A TextBox will serve as a contrived means of putting our test 
            // password on the Clipboard.
            TextBox txtBox = new TextBox();
            PasswordBox pwdBox = new PasswordBox();

            // Put some content in the TextBox, and copy it to the Clipboard.
            txtBox.Text = "Open Sesame!";
            txtBox.SelectAll();
            txtBox.Copy();
          
            // Paste the contents of the Clipboard into the PasswordBox.  After this
            // call, the value of pwdBox.Password == "Open Sesame!".
            pwdBox.Paste();
            // </Snippet_PwdBox_Paste>

        }
    }
}