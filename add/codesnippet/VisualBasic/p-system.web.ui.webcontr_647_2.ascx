  ' Update the selected IWebPart property value.
  Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim propertyValue As String = Server.HtmlEncode(TextBox3.Text)
    TextBox3.Text = String.Empty
      
    Select Case RadioButtonList1.SelectedValue
      Case "title"
        Me.Title = propertyValue
      Case "description"
        Me.Description = propertyValue
      Case "catalogiconimageurl"
        Me.CatalogIconImageUrl = propertyValue
      Case "titleiconimageurl"
        Me.TitleIconImageUrl = propertyValue
      Case "titleurl"
        Me.TitleUrl = propertyValue
      Case Else
    End Select

  End Sub 'Button1_Click