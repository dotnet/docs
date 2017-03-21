  Sub Text_Change(ByVal sender As Object, ByVal e As EventArgs)
    myLabel.Text = "<b>Welcome " + myTextBox.Text + " to ASP.NET</b>"
  End Sub 'Text_Change

  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
    Me.RegisterRequiresPostBack(myTextBox)
  End Sub