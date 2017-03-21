        ' If a size attribute is to be rendered, compare its value to 30 point.
        ' If it is not set to 30 point, add the attribute and set the value to 30
        ' then return false.
        Protected Overrides Function OnAttributeRender(name As String, _
            value As String, _
            key As HtmlTextWriterAttribute) _
        As Boolean

            If key = HtmlTextWriterAttribute.Size Then
                If [String].Compare(value, "30pt") <> 0 Then
                    AddAttribute("size", "30pt")
                    Return False
                End If
            End If

            ' If the attribute is not a size attribute, use
            ' the base functionality of the OnAttributeRender method.
            Return MyBase.OnAttributeRender(name, value, key)
        End Function 'OnAttributeRender