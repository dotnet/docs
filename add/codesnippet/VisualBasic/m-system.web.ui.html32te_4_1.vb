        ' Override the RenderBeforeTag method to render the
        ' opening tag of a <small> element to modify the text size of 
        ' any <a> elements that this writer encounters.
        Protected Overrides Function RenderBeforeTag() As String
            ' Check whether the element being rendered is an 
            ' <a> element. If so, render the opening tag
            ' of the <small> element; otherwise, call the base method.
            If TagKey = HtmlTextWriterTag.A Then
                Return "<small>"
            End If
            Return MyBase.RenderBeforeTag()
        End Function