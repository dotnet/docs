            // Get the event log corresponding to the existing source.
            string myLogName = EventLog.LogNameFromSourceName(sourceName,".");
       
            // Find each instance of a specific event log entry in a
            // particular event log.

            EventLog myEventLog = new EventLog(myLogName, ".");
            int count = 0;

            Console.WriteLine("Searching event log entries for the event ID {0}...",
                ServerConnectionDownMsgId.ToString());

            // Search for the resource ID, display the event text,
            // and display the number of matching entries.

            foreach(EventLogEntry entry in myEventLog.Entries)
            {
                if (entry.InstanceId == ServerConnectionDownMsgId)
                {
                    count ++;
                    Console.WriteLine();
                    Console.WriteLine("Entry ID    = {0}", 
                        entry.InstanceId.ToString());
                    Console.WriteLine("Reported at {0}", 
                        entry.TimeWritten.ToString());
                    Console.WriteLine("Message text:");
                    Console.WriteLine("\t{0}", entry.Message);
                }
            }    
            Console.WriteLine();
            Console.WriteLine("Found {0} events with ID {1} in event log {2}.",
                count.ToString(), ServerConnectionDownMsgId.ToString(), myLogName);
