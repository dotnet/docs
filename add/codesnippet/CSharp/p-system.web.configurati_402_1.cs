
                // Get the current ResponseDeadlockInterval property value.
                TimeSpan respDeadlock  = 
                    processModelSection.ResponseDeadlockInterval;

                // Set the ResponseDeadlockInterval property to
                // TimeSpan.Parse("00:05:00").
                processModelSection.ResponseDeadlockInterval = 
                    TimeSpan.Parse("00:05:00");
