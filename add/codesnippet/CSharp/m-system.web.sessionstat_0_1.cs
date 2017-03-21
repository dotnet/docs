    public bool Validate(string id)
    {
      try
      {
        Guid testGuid = new Guid(id);

        if (id == testGuid.ToString())
          return true;
      }
      catch
      {
      }

      return false;
    }