    protected static void MyOnEntry(Object source, EntryWrittenEventArgs e)
    {
        EventLogEntry myEventLogEntry = e.Entry;
        if (myEventLogEntry != null)
        {
            Console.WriteLine("Current message entry is: '"
                              + myEventLogEntry.Message + "'");
        }
        else
        {
            Console.WriteLine("The current entry is null");
        }
    }