  public string Description
  {
    get
    {
      object objTitle = ViewState["Description"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["Description"] = value;
    }
  }