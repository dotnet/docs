  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Dynamically generated field pagers need to be created only 
    ' the first time the page is loaded.

    If Not IsPostBack Then
      ' Create a NextPreviousPagerField object to display
      ' the buttons to navigate.
      Dim pagerField As New NextPreviousPagerField()
      pagerField.ShowFirstPageButton = True
      pagerField.ShowLastPageButton = True
      pagerField.ButtonType = ButtonType.Button
  
      ' Add the pager field to the Fields collection of the
      ' DataPager control.
      ContactsDataPager.Fields.Add(pagerField)
    End If
        
    ContactsListView.DataBind()

  End Sub