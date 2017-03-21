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

public:
    virtual void BeginPrepare() override 
    {
        // nothing to do
    }

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

public:
    virtual void BeginCommit(bool commit) override
    {
        // nothing to do
    }

public:
    virtual bool CommitRecord(LogRecord^ log) override
    {
        // nothing to do
        return(false);
    }

public:
    virtual void EndCommit() override
    {
        // nothing to do
    }

public:
    virtual void BeginAbort(bool abort) override
    {
        // nothing to do
    }

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

public:
    virtual void EndAbort() override
    {
        // nothing to do
    }    

};