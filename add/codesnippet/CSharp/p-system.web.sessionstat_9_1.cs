    public object this[string name]
    {
      get { return pItems[name]; }
      set
      {
        pItems[name] = value;
        pDirty = true;
      }
    }