    ' Override the RenderAfterContent method to render
    ' the closing tag of a font element if the 
    ' rendered tag is a label element.
    Protected Overrides Function RenderAfterContent() As String
        ' Check to determine whether the element being rendered
        ' is a label element. If so, render the closing tag
        ' of the font element; otherwise, call the base method.
        If TagKey = HtmlTextWriterTag.Label Then
            Return "</font>"
        Else
            Return MyBase.RenderAfterContent()
        End If
    End Function 'RenderAfterContent