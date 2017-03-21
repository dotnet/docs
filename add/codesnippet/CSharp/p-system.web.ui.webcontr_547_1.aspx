  protected void Page_Load(object sender, EventArgs e)
  {

    // Create a new DataPager object.
    DataPager CountryDataPager = new DataPager();

    // Set the DataPager object's properties.
    CountryDataPager.PagedControlID = CountryListView.ID;
    CountryDataPager.PageSize = 15;
    CountryDataPager.Fields.Add(new NumericPagerField());

    // Add the DataPager object to the Controls collection
    // of the form.
    form1.Controls.Add(CountryDataPager);

    CountryListView.DataBind();
  }