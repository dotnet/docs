    ' Override the RenderBeforeContent method to write
    ' a font element that applies red to the text in a Label element.
    Protected Overrides Function RenderBeforeContent() As String
        ' Check to determine whether the element being rendered
        ' is a label element. If so, render the opening tag
        ' of the font element; otherwise, call the base method.
        If TagKey = HtmlTextWriterTag.Label Then
            Return "<font color=""red"">"
        Else
            Return MyBase.RenderBeforeContent()
        End If
    End Function 'RenderBeforeContent
