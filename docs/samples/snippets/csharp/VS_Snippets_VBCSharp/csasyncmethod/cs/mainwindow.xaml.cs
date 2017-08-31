using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncMethodCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Methods (C# Programming Guide)
        // cc738f07-e8cd-4683-9585-9f40c0667c37

        // Snippet1 is used for VB, and Snippet2 is used for C#.

        //<Snippet2>
        // using System.Diagnostics;
        // using System.Threading.Tasks;

        // This Click event is marked with the async modifier.
        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            await DoSomethingAsync();
        }

        private async Task DoSomethingAsync()
        {
            Task<int> delayTask = DelayAsync();
            int result = await delayTask;

            // The previous two statements may be combined into
            // the following statement.
            //int result = await DelayAsync();

            Debug.WriteLine("Result: " + result);
        }

        private async Task<int> DelayAsync()
        {
            await Task.Delay(100);
            return 5;
        }

        // Output:
        //  Result: 5
        //</Snippet2>
    }
}
