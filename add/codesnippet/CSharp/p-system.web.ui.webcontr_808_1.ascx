  public string Title
  {
    get
    {
      object objTitle = ViewState["Title"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["Title"] = value;
    }
  }