Private Sub Button2_Click(sender As Object, e As System.EventArgs)
   Dim myColor As String
   Dim myAttributes As AttributeCollection = TextBox1.Attributes
   myColor = DropDownList1.Items(DropDownList1.SelectedIndex).Text
   ' Add the attribute "background-color" in to the CssStyle.
   myAttributes.CssStyle.Add("background-color", myColor)
End Sub