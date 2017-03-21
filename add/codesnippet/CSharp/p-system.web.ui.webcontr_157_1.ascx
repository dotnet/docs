  public string TitleUrl
  {
    get
    {
      object objTitle = ViewState["TitleUrl"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["TitleUrl"] = value;
    }
  }