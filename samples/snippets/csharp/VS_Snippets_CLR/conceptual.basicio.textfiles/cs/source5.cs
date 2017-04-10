// <snippet5>
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

        private async void AppendButton_Click(object sender, RoutedEventArgs e)
        {
            // Set a variable to the My Documents path.
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Create a stringbuilder and write the new user input to it.
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("New User Input");
            sb.AppendLine("= = = = = =");
            sb.Append(UserInputTextBox.Text);
            sb.AppendLine();
            sb.AppendLine();

            // Open a streamwriter to a new text file named "UserInputFile.txt"and write the contents of 
            // the stringbuilder to it.
            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\UserInputFile.txt", true))
            {
                await outfile.WriteAsync(sb.ToString());
            }
        }
    }
}
// </snippet5>
