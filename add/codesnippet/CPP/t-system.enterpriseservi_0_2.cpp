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

        // Create a new clerk using the AccountCompensator class.
        Clerk^ clerk = gcnew Clerk(AccountCompensator::typeid,
            "An account transaction compensator", CompensatorOptions::AllPhases);

        // Create a record of previous account status, and deliver it to the
        // clerk.
        int balance = ReadAccountBalance(Filename);

        array<Object^>^ record = gcnew array<Object^>(2);
        record[0] = Filename;
        record[1] = balance;

        clerk->WriteLogRecord(record);
        clerk->ForceLog();

        // Perform the transaction
        balance -= amount;

        Console::WriteLine("{0}: {1}", Filename, balance);

        WriteAccountBalance(Filename, balance);

        // Commit or abort the transaction 
        if (AllowCommit)
        {
            ContextUtil::SetComplete();
        }
        else
        {
            ContextUtil::SetAbort();
        }

    }

};