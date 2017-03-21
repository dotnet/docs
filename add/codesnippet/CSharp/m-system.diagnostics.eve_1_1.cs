        static void CreateEventSourceSample1(string messageFile)
        {
            string myLogName;
            string sourceName = "SampleApplicationSource";

            // Create the event source if it does not exist.
            if(!EventLog.SourceExists(sourceName))
            {
                // Create a new event source for the custom event log
                // named "myNewLog."  

                myLogName = "myNewLog";
                EventSourceCreationData mySourceData = new EventSourceCreationData(sourceName, myLogName);

                // Set the message resource file that the event source references.
                // All event resource identifiers correspond to text in this file.
                if (!System.IO.File.Exists(messageFile))
                {
                    Console.WriteLine("Input message resource file does not exist - {0}", 
                        messageFile);
                    messageFile = "";
                }
                else 
                {
                    // Set the specified file as the resource
                    // file for message text, category text, and 
                    // message parameter strings.  

                    mySourceData.MessageResourceFile = messageFile;
                    mySourceData.CategoryResourceFile = messageFile;
                    mySourceData.CategoryCount = CategoryCount;
                    mySourceData.ParameterResourceFile = messageFile;

                    Console.WriteLine("Event source message resource file set to {0}", 
                        messageFile);
                }

                Console.WriteLine("Registering new source for event log.");
                EventLog.CreateEventSource(mySourceData);
            }
            else
            {
                // Get the event log corresponding to the existing source.
                myLogName = EventLog.LogNameFromSourceName(sourceName,".");
            }

            // Register the localized name of the event log.
            // For example, the actual name of the event log is "myNewLog," but
            // the event log name displayed in the Event Viewer might be
            // "Sample Application Log" or some other application-specific
            // text.
            EventLog myEventLog = new EventLog(myLogName, ".", sourceName);
            
            if (messageFile.Length > 0)
            {
                myEventLog.RegisterDisplayName(messageFile, DisplayNameMsgId);
            }
        }