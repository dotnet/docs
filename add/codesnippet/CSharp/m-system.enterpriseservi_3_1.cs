    public override bool EndPrepare ()
    {
        // Allow the transaction to proceed onlyif we have received a prepare record.
        if (receivedPrepareRecord)
        {
            return(true);
        }
        else
        {
            return(false);
        }
    }