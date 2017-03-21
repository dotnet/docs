    public void RemoveAt(int index)
    {
      if (index < 0 || index >= this.Count)
        throw new ArgumentOutOfRangeException("The specified index is not within the acceptable range.");

      pItems.RemoveAt(index);
      pDirty = true;
    }