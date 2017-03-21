        ' Override the RenderAfterTag method to render
        ' close any elements opened in the RenderBeforeTag
        ' method call.
        Protected Overrides Function RenderAfterTag() As String
            ' Check whether the element being rendered is an
            ' <a> element. If so, render the closing tag of the
            ' <small> element; otherwise, call the base method.
            If TagKey = HtmlTextWriterTag.A Then
                Return "</small>"
            End If
            Return MyBase.RenderAfterTag()
        End Function