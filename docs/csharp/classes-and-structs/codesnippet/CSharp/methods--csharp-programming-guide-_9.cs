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