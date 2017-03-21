        ' Override the OnAttributeRender method to
        ' not render the bgcolor attribute, which is 
        ' not supported in CHTML.
        Protected Overrides Function OnAttributeRender(ByVal name As String, ByVal value As String, ByVal key As HtmlTextWriterAttribute) As Boolean
            If (String.Equals("bgcolor", name)) Then
                Return False
            End If

            ' Call the ChtmlTextWriter version of 
            ' the OnAttributeRender method.
            MyBase.OnAttributeRender(name, value, key)

        End Function