        public async Task DoSomethingAsync()
        {
            Task<string> theTask = DelayAsync();

            try
            {
                string result = await theTask;
                Debug.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
            }
            Debug.WriteLine("Task IsCanceled: " + theTask.IsCanceled);
            Debug.WriteLine("Task IsFaulted:  " + theTask.IsFaulted);
            if (theTask.Exception != null)
            {
                Debug.WriteLine("Task Exception Message: "
                    + theTask.Exception.Message);
                Debug.WriteLine("Task Inner Exception Message: "
                    + theTask.Exception.InnerException.Message);
            }
        }

        private async Task<string> DelayAsync()
        {
            await Task.Delay(100);

            // Uncomment each of the following lines to
            // demonstrate exception handling.

            //throw new OperationCanceledException("canceled");
            //throw new Exception("Something happened.");
            return "Done";
        }

        // Output when no exception is thrown in the awaited method:
        //   Result: Done
        //   Task IsCanceled: False
        //   Task IsFaulted:  False

        // Output when an Exception is thrown in the awaited method:
        //   Exception Message: Something happened.
        //   Task IsCanceled: False
        //   Task IsFaulted:  True
        //   Task Exception Message: One or more errors occurred.
        //   Task Inner Exception Message: Something happened.

        // Output when a OperationCanceledException or TaskCanceledException
        // is thrown in the awaited method:
        //   Exception Message: canceled
        //   Task IsCanceled: True
        //   Task IsFaulted:  False
