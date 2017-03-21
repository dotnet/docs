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