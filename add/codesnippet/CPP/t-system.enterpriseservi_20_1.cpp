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