        public async Task DoMultipleAsync()
        {
            Task theTask1 = ExcAsync(info: "First Task");
            Task theTask2 = ExcAsync(info: "Second Task");
            Task theTask3 = ExcAsync(info: "Third Task");

            Task allTasks = Task.WhenAll(theTask1, theTask2, theTask3);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                Debug.WriteLine("Task IsFaulted: " + allTasks.IsFaulted);
                foreach (var inEx in allTasks.Exception.InnerExceptions)
                {
                    Debug.WriteLine("Task Inner Exception: " + inEx.Message);
                }
            }
        }

        private async Task ExcAsync(string info)
        {
            await Task.Delay(100);
            
            throw new Exception("Error-" + info);
        }

        // Output:
        //   Exception: Error-First Task
        //   Task IsFaulted: True
        //   Task Inner Exception: Error-First Task
        //   Task Inner Exception: Error-Second Task
        //   Task Inner Exception: Error-Third Task