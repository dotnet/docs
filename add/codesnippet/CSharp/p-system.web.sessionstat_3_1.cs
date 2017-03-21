    public object this[int index]
    {
      get { return pItems[index]; }
      set
      {
        pItems[index] = value;
        pDirty = true;
      }
    }