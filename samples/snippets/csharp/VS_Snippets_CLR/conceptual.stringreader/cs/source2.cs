// <snippet2>
using System;
using System.Text;
using System.Windows;
using System.IO;

namespace WpfApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            char[] charsRead = new char[UserInput.Text.Length];
            using (StringReader reader = new StringReader(UserInput.Text))
            {
                await reader.ReadAsync(charsRead, 0, UserInput.Text.Length);
            }

            StringBuilder reformattedText = new StringBuilder();
            using (StringWriter writer = new StringWriter(reformattedText))
            {
                foreach (char c in charsRead)
                {
                    if (char.IsLetter(c) || char.IsWhiteSpace(c))
                    {
                        await writer.WriteLineAsync(char.ToLower(c));
                    }
                }
            }
            Result.Text = reformattedText.ToString();
        }
    }
}
// </snippet2>
