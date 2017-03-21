
                // Get the current ResponseRestartDeadlockInterval property
                // value.
                TimeSpan respRestartDeadlock =
                    processModelSection.ResponseRestartDeadlockInterval;

                // Set the ResponseRestartDeadlockInterval property to
                // TimeSpan.Parse("04:00:00").
                processModelSection.ResponseRestartDeadlockInterval = 
                    TimeSpan.Parse("04:00:00");
