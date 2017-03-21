  void Page_Load(Object sender, EventArgs e)
  {
    
    // Dynamically generated field pagers need to be created only 
    // the first time the page is loaded.
    
    if (!IsPostBack)
    {
      // Create a NextPreviousPagerField object to display
      // the buttons to navigate.
      NextPreviousPagerField pagerField = new NextPreviousPagerField();
      pagerField.ShowFirstPageButton = true;
      pagerField.ShowLastPageButton = true;
      pagerField.ButtonType = ButtonType.Button;

      // Add the pager field to the Fields collection of the
      // DataPager control.
      ContactsDataPager.Fields.Add(pagerField);
    }

    ContactsListView.DataBind();
  
  }