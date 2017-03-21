    public int Timeout
    {
      get { return pTimeout; }
      set
      {
        if (value <= 0)
          throw new ArgumentException("Timeout value must be greater than zero.");

        if (value > MAX_TIMEOUT)
          throw new ArgumentException("Timout cannot be greater than " + MAX_TIMEOUT.ToString());

        pTimeout = value;
      }
    }