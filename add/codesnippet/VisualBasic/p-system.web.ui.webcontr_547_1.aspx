  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Create a new DataPager object.
    Dim CountryDataPager As New DataPager()
        
    ' Set the DataPager object's properties.
    CountryDataPager.PagedControlID = CountryListView.ID
    CountryDataPager.PageSize = 15
    CountryDataPager.Fields.Add(New NumericPagerField())
        
    ' Add the DataPager object to the Controls collection
    ' of the form.
    form1.Controls.Add(CountryDataPager)

    CountryListView.DataBind()
    
  End Sub