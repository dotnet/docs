  Protected Sub TemplatePagerField_OnPagerCommand(ByVal sender As Object, _
    ByVal e As DataPagerCommandEventArgs)
    
    ' Get the new page number 
    Dim PageNumberTextBox As TextBox = _
      CType(e.Item.FindControl("PageNumberTextBox"), TextBox)
    
    Dim newPageNumber As Integer = -1
    Try
      newPageNumber = Convert.ToInt32(PageNumberTextBox.Text.Trim())
    Catch fex As FormatException
      Message.Text = "Invalid page number."
      Return
    Catch oex As OverflowException
      Message.Text = "Invalid page number."
      Return
    End Try
        
    Dim newIndex As Integer = _
      (newPageNumber - 1) * e.Item.Pager.PageSize
    
    'Verify if the new index is valid
    If newIndex >= 0 AndAlso newIndex <= e.TotalRowCount Then
      'Set the new start index and maximum rows
      e.NewStartRowIndex = newIndex
      e.NewMaximumRows = e.Item.Pager.MaximumRows
    Else
      Message.Text = "Invalid page number."
    End If
    
  End Sub