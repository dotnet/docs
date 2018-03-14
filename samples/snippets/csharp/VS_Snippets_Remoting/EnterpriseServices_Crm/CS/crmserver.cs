// <snippet0>
using System;
using System.EnterpriseServices;
using System.EnterpriseServices.CompensatingResourceManager;
using System.IO;

// <snippet1>
[assembly: ApplicationActivation(ActivationOption.Server)]
// </snippet1>
// <snippet2>
[assembly: ApplicationAccessControl(false)]
// </snippet2>
// <snippet3>
[assembly: ApplicationCrmEnabled]
// </snippet3>
// <snippet4>
[assembly: Description("A system for ensuring that the correct account balance is stored after a transaction.")]
// </snippet4>

// Subroutines to read and write account files.
internal static class AccountManager
{

    public static void WriteAccountBalance (string filename, int balance)
    {
        StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(balance);
        writer.Close();
    }

    public static int ReadAccountBalance (string filename)
    {
        int balance = 0;
        if (File.Exists(filename))
        {
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            balance = Int32.Parse(line);
            reader.Close();
        }
        return(balance);        
    }

}

// <snippet10>
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

// <snippet11>
        // Create a new clerk using the AccountCompensator class.
        Clerk clerk = new Clerk(typeof(AccountCompensator),
          "An account transaction compensator", CompensatorOptions.AllPhases);
// </snippet11>

// <snippet12>
        // Create a record of previous account status, and deliver it to the clerk.
        int balance = AccountManager.ReadAccountBalance(filename);

	Object[] record = new Object[2];
	record[0] = filename;
        record[1] = balance;

        clerk.WriteLogRecord(record);
        clerk.ForceLog();
// </snippet12>

        // Perform the transaction
        balance -= ammount;
        AccountManager.WriteAccountBalance(filename, balance);

// <snippet13>
        // Commit or abort the transaction 
        if (commit)
        {
            ContextUtil.SetComplete();
        }
        else
        {
            ContextUtil.SetAbort();
        }
// </snippet13>
      
    }

}
// </snippet10>


// <snippet20>
// A CRM Compensator
public class AccountCompensator : Compensator
{

    private bool receivedPrepareRecord = false;

// <snippet21>
    public override void BeginPrepare ()
    {
        // nothing to do
    }
// </snippet21>

// <snippet22>
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
// </snippet22>

// <snippet23>
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
// </snippet23>

// <snippet24>
    public override void BeginCommit (bool commit)
    {
        // nothing to do
    }
// </snippet24>

// <snippet25>
    public override bool CommitRecord (LogRecord log)
    {
        // nothing to do
        return(false);
    }
// </snippet25>

// <snippet26>
    public override void EndCommit ()
    {
        // nothing to do
    }
// </snippet26>

// <snippet27>
    public override void BeginAbort (bool abort)
    {
        // nothing to do
    }
// </snippet27>

// <snippet28>
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
// </snippet28>

// <snippet29>
    public override void EndAbort ()
    {
        // nothing to do
    }    
// </snippet29>

}
// </snippet20>
// </snippet0>