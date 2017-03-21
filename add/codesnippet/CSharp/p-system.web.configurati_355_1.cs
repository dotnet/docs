
                // Get the current ClientConnectedCheck property value.
                TimeSpan clConnectCheck = 
                 processModelSection.ClientConnectedCheck;

                // Set the ClientConnectedCheck property to
                // TimeSpan.Parse("00:15:00").
                processModelSection.ClientConnectedCheck = 
                    TimeSpan.Parse("00:15:00");
