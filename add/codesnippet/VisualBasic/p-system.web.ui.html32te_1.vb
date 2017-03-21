        ' Override the RenderBeforeContent method to render
        ' styles before rendering the content of a <th> element.
        Protected Overrides Function RenderBeforeContent() As String
            ' Check the TagKey property. If its value is
            ' HtmlTextWriterTag.TH, check the value of the 
            ' SupportsBold property. If true, return the
            ' opening tag of a <b> element; otherwise, render
            ' the opening tag of a <font> element with a color
            ' attribute set to the hexadecimal value for red.
            If TagKey = HtmlTextWriterTag.Th Then
                If (SupportsBold) Then
                    Return "<b>"
                Else
                    Return "<font color=""FF0000"">"
                End If
            End If

            ' Check whether the element being rendered
            ' is an <H4> element. If it is, check the 
            ' value of the SupportsItalic property.
            ' If true, render the opening tag of the <i> element
            ' prior to the <H4> element's content; otherwise, 
            ' render the opening tag of a <font> element 
            ' with a color attribute set to the hexadecimal
            ' value for navy blue.
            If TagKey = HtmlTextWriterTag.H4 Then
                If (SupportsItalic) Then
                    Return "<i>"
                Else
                    Return "<font color=""000080"">"
                End If
            End If
            ' Call the base method.
            Return MyBase.RenderBeforeContent()
        End Function