            // Abort the operation if the user has canceled.
            // Note that a call to CancelAsync may have set 
            // CancellationPending to true just after the
            // last invocation of this method exits, so this 
            // code will not have the opportunity to set the 
            // DoWorkEventArgs.Cancel flag to true. This means
            // that RunWorkerCompletedEventArgs.Cancelled will
            // not be set to true in your RunWorkerCompleted
            // event handler. This is a race condition.

            if (worker.CancellationPending)
            {   
                e.Cancel = true;
            }
            else
            {   
                if (n < 2)
                {   
                    result = 1;
                }
                else
                {   
                    result = ComputeFibonacci(n - 1, worker, e) + 
                             ComputeFibonacci(n - 2, worker, e);
                }

                // Report progress as a percentage of the total task.
                int percentComplete = 
                    (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }