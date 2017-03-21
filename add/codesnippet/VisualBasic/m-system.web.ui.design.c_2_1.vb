      Public Overrides Function GetDesignTimeHtml() As String
         ' Component is the instance of the component or control that
         ' this designer object is associated with. This property is 
         ' inherited from System.ComponentModel.ComponentDesigner.
         simpleControl = CType(Component, Simple)
         
         If simpleControl.Text.Length > 0 Then
            Dim sw As New StringWriter()
            Dim tw As New HtmlTextWriter(sw)
            
            Dim placeholderLink As New HyperLink()
            
            ' Put simpleControl.Text into the link's Text.
            placeholderLink.Text = simpleControl.Text
            placeholderLink.NavigateUrl = simpleControl.Text
            placeholderLink.RenderControl(tw)
            
            Return sw.ToString()
         Else
            Return GetEmptyDesignTimeHtml()
         End If
      End Function