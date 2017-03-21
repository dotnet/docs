  public string TitleIconImageUrl
  {
    get
    {
      object objTitle = ViewState["TitleIconImageUrl"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["TitleIconImageUrl"] = value;
    }
  }