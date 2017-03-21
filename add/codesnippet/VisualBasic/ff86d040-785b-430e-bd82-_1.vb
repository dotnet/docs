        ' Override the OnStyleAttributeRender
        ' method to prevent this text writer 
        ' from rendering purple text.
        Overrides Protected Function OnStyleAttributeRender(ByVal name As String, _
          ByVal value As String, _
          ByVal key As HtmlTextWriterStyle _
        ) As Boolean
           If key = HtmlTextWriterStyle.Color Then
              If String.Compare(value, "purple") = 0 Then
                 Return False
              Else
                 Return True
              End If
           Else
              Return MyBase.OnStyleAttributeRender(name, value, key)        
           End If
        End Function  