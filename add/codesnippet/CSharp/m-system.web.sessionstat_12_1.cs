    //
    // Abandon marks the session as abandoned. The IsAbandoned property is used by the
    // session state module to perform the abandon work during the ReleaseRequestState event.
    //
    public void Abandon()
    {
      pAbandon = true;
    }

    public bool IsAbandoned
    {
      get { return pAbandon; }
    }