    public void CopyTo(Array items, int index)
    {
      foreach (object o in items)
        items.SetValue(o, index++);
    }