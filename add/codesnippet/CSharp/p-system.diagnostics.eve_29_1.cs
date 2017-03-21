        static void DisplayEventLogProperties()
        {
            // Iterate through the current set of event log files,
            // displaying the property settings for each file.

            EventLog[] eventLogs = EventLog.GetEventLogs();
            foreach (EventLog e in eventLogs)
            {
                Int64 sizeKB = 0;

                Console.WriteLine();
                Console.WriteLine("{0}:", e.LogDisplayName);
                Console.WriteLine("  Log name = \t\t {0}", e.Log); 

                Console.WriteLine("  Number of event log entries = {0}", e.Entries.Count.ToString());
                            
                // Determine if there is an event log file for this event log.
                RegistryKey regEventLog = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\EventLog\\" + e.Log);
                if (regEventLog != null)
                {
                    Object temp = regEventLog.GetValue("File");
                    if (temp != null)
                    {
                        Console.WriteLine("  Log file path = \t {0}", temp.ToString());
                        FileInfo file = new FileInfo(temp.ToString());

                        // Get the current size of the event log file.
                        if (file.Exists)
                        {
                            sizeKB = file.Length / 1024;
                            if ((file.Length % 1024) != 0)
                            {
                                sizeKB++;
                            }
                            Console.WriteLine("  Current size = \t {0} kilobytes", sizeKB.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Log file path = \t <not set>");
                    }
                }
                            
                // Display the maximum size and overflow settings.

                sizeKB = e.MaximumKilobytes;
                Console.WriteLine("  Maximum size = \t {0} kilobytes", sizeKB.ToString());
                Console.WriteLine("  Overflow setting = \t {0}", e.OverflowAction.ToString());

                switch (e.OverflowAction)
                {
                    case OverflowAction.OverwriteOlder:
                        Console.WriteLine("\t Entries are retained a minimum of {0} days.", 
                            e.MinimumRetentionDays);
                        break;
                    case OverflowAction.DoNotOverwrite:
                        Console.WriteLine("\t Older entries are not overwritten.");
                        break;
                    case OverflowAction.OverwriteAsNeeded:
                        Console.WriteLine("\t If number of entries equals max size limit, a new event log entry overwrites the oldest entry.");
                        break;
                    default:
                        break;
                }
            }
        }