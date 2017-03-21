        // Commit or abort the transaction 
        if (commit)
        {
            ContextUtil.SetComplete();
        }
        else
        {
            ContextUtil.SetAbort();
        }