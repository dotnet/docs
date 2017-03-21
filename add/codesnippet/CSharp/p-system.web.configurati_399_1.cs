
                // Get the current PingTimeout property value.
                TimeSpan pingTimeout = 
                    processModelSection.PingTimeout;

                // Set the PingTimeout property to TimeSpan.Parse("00:00:30").
                processModelSection.PingTimeout = 
                    TimeSpan.Parse("00:00:30");
