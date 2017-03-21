        // Commit or abort the transaction 
        if (AllowCommit)
        {
            ContextUtil::SetComplete();
        }
        else
        {
            ContextUtil::SetAbort();
        }