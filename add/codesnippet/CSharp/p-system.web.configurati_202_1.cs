
                // Get the current ShutdownTimeout property value.
                TimeSpan shutDownTimeout =
                    processModelSection.ShutdownTimeout;

                // Set the ShutdownTimeout property to
                // TimeSpan.Parse("00:00:30").
                processModelSection.ShutdownTimeout = 
                    TimeSpan.Parse("00:00:30");
