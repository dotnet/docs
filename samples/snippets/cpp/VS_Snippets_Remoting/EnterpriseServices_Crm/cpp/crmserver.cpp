// <snippet0>
#using <System.EnterpriseServices.dll>
#using <System.Transactions.dll>
#using <System.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::EnterpriseServices::CompensatingResourceManager;
using namespace System::IO;
using namespace System::Diagnostics;

// <snippet1>
[assembly: ApplicationActivation(ActivationOption::Server)];
// </snippet1>
// <snippet2>
[assembly: ApplicationAccessControl(false)];
// </snippet2>
// <snippet3>                    
[assembly: ApplicationCrmEnabled];
// </snippet3>
// <snippet4>
[assembly: Description("A system for ensuring that the correct account "
                       "balance is stored after a transaction.")];
// </snippet4>

// Subroutines to read and write account files.
void WriteAccountBalance(String^ filename, int balance)
{
    StreamWriter^ streamWriter = gcnew StreamWriter(filename);
    try
    {
        streamWriter->WriteLine(balance);
    }
    finally
    {
        delete streamWriter;
    }
}

int ReadAccountBalance(String^ filename)
{                
    int balance = 0;
    if (File::Exists(filename))
    {
        StreamReader^ streamReader = gcnew StreamReader(filename);
        try
        {
            String^ line = streamReader->ReadLine();
            balance = Int32::Parse(line);
        }
        finally
        {
            delete streamReader;
        }
    }
    return balance;         
}

ref class AccountCompensator;

// <snippet10>
// A CRM Worker
[Transaction]
public ref class Account : public ServicedComponent
{

    // A data member for the account file name.
private:
    String^ filenameValue;

public:
    property String^ Filename
    {
        String^ get()
        {
            return filenameValue;
        }
        void set( String^ value )
        {
            filenameValue = value;
        }
    }

    // A boolean data member that determines whether to commit or abort the 
    // transaction.
private:
    bool allowCommitValue;

public:
    property bool AllowCommit
    {
        bool get()
        {
            return allowCommitValue;
        }
        void set( bool value )
        {
            allowCommitValue = value;
        }
    }

    // Debit the account, 
public:
    void DebitAccount(int amount)
    {

        // <snippet11>
        // Create a new clerk using the AccountCompensator class.
        Clerk^ clerk = gcnew Clerk(AccountCompensator::typeid,
            "An account transaction compensator", CompensatorOptions::AllPhases);
        // </snippet11>

        // <snippet12>
        // Create a record of previous account status, and deliver it to the
        // clerk.
        int balance = ReadAccountBalance(Filename);

        array<Object^>^ record = gcnew array<Object^>(2);
        record[0] = Filename;
        record[1] = balance;

        clerk->WriteLogRecord(record);
        clerk->ForceLog();
        // </snippet12>

        // Perform the transaction
        balance -= amount;

        Console::WriteLine("{0}: {1}", Filename, balance);

        WriteAccountBalance(Filename, balance);

        // <snippet13>
        // Commit or abort the transaction 
        if (AllowCommit)
        {
            ContextUtil::SetComplete();
        }
        else
        {
            ContextUtil::SetAbort();
        }
        // </snippet13>

    }

};
// </snippet10>

// <snippet20>
// A CRM Compensator
public ref class AccountCompensator : public Compensator
{
private:
    bool receivedPrepareRecord;

public:
    AccountCompensator()
    {
        receivedPrepareRecord = false;
    } 

    // <snippet21>
public:
    virtual void BeginPrepare() override 
    {
        // nothing to do
    }
    // </snippet21>

    // <snippet22>
public:
    virtual bool PrepareRecord(LogRecord^ log) override 
    {

        // Check the validity of the record.
        if (log == nullptr)
        {
            return false;
        }
        array<Object^>^ record = dynamic_cast<array<Object^>^>(log->Record);
        if (record == nullptr)
        {
            return false;
        }
        if (record->Length != 2)
        {
            return false;
        }

        // The record is valid.
        receivedPrepareRecord = true;
        return true;              
    }
    // </snippet22>

    // <snippet23>
public:
    virtual bool EndPrepare() override
    {
        // Allow the transaction to proceed onlyif we have received a prepare
        // record.
        if (receivedPrepareRecord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // </snippet23>

    // <snippet24>
public:
    virtual void BeginCommit(bool commit) override
    {
        // nothing to do
    }
    // </snippet24>

    // <snippet25>
public:
    virtual bool CommitRecord(LogRecord^ log) override
    {
        // nothing to do
        return(false);
    }
    // </snippet25>

    // <snippet26>
public:
    virtual void EndCommit() override
    {
        // nothing to do
    }
    // </snippet26>

    // <snippet27>
public:
    virtual void BeginAbort(bool abort) override
    {
        // nothing to do
    }
    // </snippet27>

    // <snippet28>
public:
    virtual bool AbortRecord(LogRecord^ log) override
    {

        // Check the validity of the record.
        if (log == nullptr)
        {
            return true;
        }
        array<Object^>^ record = dynamic_cast<array<Object^>^>(log->Record);
        if (record == nullptr)
        {
            return true;
        }
        if (record->Length != 2)
        {
            return true;
        }

        // Extract old account data from the record.
        String^ filename = (String^) record[0];
        int balance = (int) record[1];

        // Restore the old state of the account.
        WriteAccountBalance(filename, balance);

        return false;
    }
    // </snippet28>

    // <snippet29>
public:
    virtual void EndAbort() override
    {
        // nothing to do
    }    
    // </snippet29>

};
// </snippet20>

// </snippet0> 
