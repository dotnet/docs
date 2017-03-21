  public string CatalogIconImageUrl
  {
    get
    {
      object objTitle = ViewState["CatalogIconImageUrl"];
      if (objTitle == null)
        return String.Empty;

      return (string)objTitle;
    }
    set
    {
      ViewState["CatalogIconImageUrl"] = value;
    }
  }