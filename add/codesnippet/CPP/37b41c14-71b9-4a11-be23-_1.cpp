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