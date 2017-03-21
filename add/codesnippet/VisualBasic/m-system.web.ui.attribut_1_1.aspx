   myButton.Attributes.Clear()
   myTextBox.Attributes.Clear()
   myButton.Attributes("onClick") = "javascript:alert('Visiting msn.com');"
   
   myTextBox.Attributes("name") = "MyTextBox"
   
   myTextBox.Attributes("onBlur") = "javascript:alert('Leaving MyTextBox...');"
   
   Dim myHttpResponse As HttpResponse = Response
   Dim myHtmlTextWriter As New HtmlTextWriter(myHttpResponse.Output)
   
   myButton.Attributes.AddAttributes(myHtmlTextWriter)
   myTextBox.Attributes.AddAttributes(myHtmlTextWriter)