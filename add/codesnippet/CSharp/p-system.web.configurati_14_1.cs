
                // Get the current PingFrequency property value.
                TimeSpan pingFreq = 
                    processModelSection.PingFrequency;

                // Set the PingFrequency property to
                // TimeSpan.Parse("00:01:00").
                processModelSection.PingFrequency = 
                    TimeSpan.Parse("00:01:00");
