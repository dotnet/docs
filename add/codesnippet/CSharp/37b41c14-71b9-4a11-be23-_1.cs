    public override bool PrepareRecord (LogRecord log)
    {

        // Check the validity of the record.
        if (log == null) return(true);
        Object[] record = log.Record as Object[];
        if (record == null) return(true);
        if (record.Length != 2) return(true);

        // The record is valid.
        receivedPrepareRecord = true;
        return(false);              
    }