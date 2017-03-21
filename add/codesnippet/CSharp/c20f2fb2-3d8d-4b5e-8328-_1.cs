
            // Copy the EventLog entries to Array of type EventLogEntry.
            EventLogEntry[] myEventLogEntryArray =
               new EventLogEntry[myEventLogEntryCollection.Count];
            myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0);
            IEnumerator myEnumerator = myEventLogEntryArray.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                EventLogEntry myEventLogEntry = (EventLogEntry)myEnumerator.Current;
                Console.WriteLine("The LocalTime the Event is generated is "
                   + myEventLogEntry.TimeGenerated);
            }