using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace wpf_app1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // ExampleMethodAsync returns a Task<int>, which means that the method
            // eventually produces an int result. However, ExampleMethodAsync returns
            // the Task<int> value as soon as it reaches an await.
            ResultsTextBox.Text += "\n";

            try
            {
                int length = await ExampleMethodAsync();
                // Note that you could put "await ExampleMethodAsync()" in the next line where
                // "length" is, but due to when '+=' fetches the value of ResultsTextBox, you
                // would not see the global side effect of ExampleMethodAsync setting the text.
                ResultsTextBox.Text += String.Format("Length: {0:N0}\n", length);
            }
            catch (Exception)
            {
                // Process the exception if one occurs.
            }
        }

        public async Task<int> ExampleMethodAsync()
        {
            var httpClient = new HttpClient();
            int exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;
            ResultsTextBox.Text += "Preparing to finish ExampleMethodAsync.\n";
            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartButton_Click) can get the
            // integer result.
            return exampleInt;
        }
        // The example displays the following output:
        // Preparing to finish ExampleMethodAsync.
        // Length: 53292
        // </Snippet1>
    }
}
