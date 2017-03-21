    public override bool AbortRecord (LogRecord log)
    {

        // Check the validity of the record.
        if (log == null) return(true);
        Object[] record = log.Record as Object[];
        if (record == null) return(true);
        if (record.Length != 2) return(true);

        // Extract old account data from the record.
        string filename = (string) record[0];
        int balance = (int) record[1];
 
        // Restore the old state of the account.
        AccountManager.WriteAccountBalance(filename, balance);

        return(false);
    }