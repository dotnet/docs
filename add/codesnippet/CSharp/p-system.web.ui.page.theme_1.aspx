  void Page_PreInit(object sender, EventArgs e)
  {
    // Get the theme name from a QueryString variable
    string ThemeName;
    ThemeName = Request.QueryString["thename"];
    if (ThemeName != null)
    {
      Page.Theme = ThemeName;
    }
  }