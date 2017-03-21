
                // Get the current IdleTimeout property value.
                TimeSpan idleTimeout = 
                    processModelSection.IdleTimeout;

                // Set the IdleTimeout property to TimeSpan.Parse("12:00:00").
                processModelSection.IdleTimeout = 
                    TimeSpan.Parse("12:00:00");
