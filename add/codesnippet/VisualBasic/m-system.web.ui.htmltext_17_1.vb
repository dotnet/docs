        Public Overloads Overrides Sub RenderBeginTag(ByVal tagName As String)
            ' Call the overloaded RenderBeginTag(HtmlTextWriterTag) method.
            RenderBeginTag(GetTagKey(tagName))
        End Sub
