
                // Get the current ComImpersonationLevel property value.
                ProcessModelComImpersonationLevel comImpLevel = 
                    processModelSection.ComImpersonationLevel;

                // Set the ComImpersonationLevel property to
                // ProcessModelComImpersonationLevel.Anonymous.
                processModelSection.ComImpersonationLevel = 
                    ProcessModelComImpersonationLevel.Anonymous;
