  Sub ContactsListView_Sorting(ByVal sender As Object, ByVal e As ListViewSortEventArgs) 
  
    ' Check the sort direction to set the image URL accordingly.
    Dim imgUrl As String
    If e.SortDirection = SortDirection.Ascending Then
      imgUrl = "~/images/ascending.gif"
    Else
      imgUrl = "~/images/descending.gif"
    End If
    
    ' Check which field is being sorted
    ' to set the visibility of the image controls.
    Dim sortImage1 As Image = CType(ContactsListView.FindControl("SortImage1"), Image)
    Dim sortImage2 As Image = CType(ContactsListView.FindControl("SortImage2"), Image)
    Dim sortImage3 As Image = CType(ContactsListView.FindControl("SortImage3"), Image)
    
    Select Case e.SortExpression
      Case "FirstName"
        sortImage1.Visible = True
        sortImage1.ImageUrl = imgUrl
        sortImage2.Visible = False
        sortImage3.Visible = False
      Case "LastName"
        sortImage1.Visible = False
        sortImage2.Visible = True
        sortImage2.ImageUrl = imgUrl
        sortImage3.Visible = False
      Case "EmailAddress"
        sortImage1.Visible = False
        sortImage2.Visible = False
        sortImage3.Visible = True
        sortImage3.ImageUrl = imgUrl
    End Select
    
  End Sub