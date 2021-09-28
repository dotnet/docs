// <snippetClientCredentialsLogin>
using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace NorthwindClient
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            e.Handled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
             this.DialogResult = false;
             e.Handled = true;
        }

        private void LoginWindow_Closing(object sender, CancelEventArgs e)
        {
            if (this.DialogResult == true &&
                    (this.userNameBox.Text == string.Empty || this.passwordBox.SecurePassword.Length == 0))
            {
                e.Cancel = true;
                MessageBox.Show("Please enter name and password or click Cancel.");
            }
        }
    }
}
// </snippetClientCredentialsLogin>
