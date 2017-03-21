// A CRM Compensator
public class AccountCompensator : Compensator
{

    private bool receivedPrepareRecord = false;

    public override void BeginPrepare ()
    {
        // nothing to do
    }

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

    public override void BeginCommit (bool commit)
    {
        // nothing to do
    }

    public override bool CommitRecord (LogRecord log)
    {
        // nothing to do
        return(false);
    }

    public override void EndCommit ()
    {
        // nothing to do
    }

    public override void BeginAbort (bool abort)
    {
        // nothing to do
    }

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

    public override void EndAbort ()
    {
        // nothing to do
    }    

}