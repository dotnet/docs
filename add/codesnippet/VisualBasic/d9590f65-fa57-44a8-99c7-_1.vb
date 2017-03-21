        ' If a color style attribute is to be rendered,
        ' compare its value to purple. If it is not set to
        ' purple, add the style attribute and set the value
        ' to purple, then return false.
        Protected Overrides Function OnStyleAttributeRender(name As String, _
            value As String, _
            key As HtmlTextWriterStyle) _
        As Boolean

            If key = HtmlTextWriterStyle.Color Then
                If [String].Compare(value, "purple") <> 0 Then
                    AddStyleAttribute("color", "purple")
                    Return False
                End If
            End If

            ' If the style attribute is not a color attribute,
            ' use the base functionality of the
            ' OnStyleAttributeRender method.
            Return MyBase.OnStyleAttributeRender(name, value, key)
        End Function 'OnStyleAttributeRender