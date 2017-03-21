        ' Override the OnAttributeRender method to 
        ' allow this text writer to render only eight-point 
        ' text size.
        Overrides Protected Function OnAttributeRender(ByVal name As String, _
          ByVal value As String, _
          ByVal key As HtmlTextWriterAttribute _
        ) As Boolean
           If key = HtmlTextWriterAttribute.Size Then
              If String.Compare(value, "8pt") = 0 Then
                 Return True
              Else
                 Return False
              End If 
           Else
              Return MyBase.OnAttributeRender(name, value, key)
           End If
        End Function