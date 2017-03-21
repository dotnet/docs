// A CRM Worker
[Transaction]
public class Account : ServicedComponent
{

    // A data member for the account file name.
    private string filename;
    
    public string Filename
    {
        get
        {
            return(filename);
        }
        set
        {
            filename = value;
        }
    }


    // A boolean data member that determines whether to commit or abort the transaction.
    private bool commit;

    public bool AllowCommit
    {
        get
        {
            return(commit);
        }
        set
        {
            commit = value;
        }
    }



    // Debit the account, 
    public void DebitAccount (int ammount)
    {

        // Create a new clerk using the AccountCompensator class.
        Clerk clerk = new Clerk(typeof(AccountCompensator),
          "An account transaction compensator", CompensatorOptions.AllPhases);

        // Create a record of previous account status, and deliver it to the clerk.
        int balance = AccountManager.ReadAccountBalance(filename);

	Object[] record = new Object[2];
	record[0] = filename;
        record[1] = balance;

        clerk.WriteLogRecord(record);
        clerk.ForceLog();

        // Perform the transaction
        balance -= ammount;
        AccountManager.WriteAccountBalance(filename, balance);

        // Commit or abort the transaction 
        if (commit)
        {
            ContextUtil.SetComplete();
        }
        else
        {
            ContextUtil.SetAbort();
        }
      
    }

}