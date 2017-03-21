        ' Override the RenderBeginTag method to check whether
        ' the tagKey parameter is set to a <label> element
        ' or a <font> element.   
        Public Overloads Overrides Sub RenderBeginTag(ByVal tagKey As HtmlTextWriterTag)
            ' If the tagKey parameter is set to a <label> element
            ' but a color attribute is not defined on the element,
            ' the AddStyleAttribute method adds a color attribute
            ' and sets it to red.
            If tagKey = HtmlTextWriterTag.Label Then
                If Not IsStyleAttributeDefined(HtmlTextWriterStyle.Color) Then
                    AddStyleAttribute(GetStyleKey("color"), "red")
                End If
            End If

            ' If the tagKey parameter is set to a <font> element
            ' but a size attribute is not defined on the element,
            ' the AddStyleAttribute method adds a size attribute
            ' and sets it to 30 point. 
            If tagKey = HtmlTextWriterTag.Font Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Size) Then
                    AddAttribute(GetAttributeKey("size"), "30pt")
                End If
            End If

            ' Call the base class's RenderBeginTag method
            ' to ensure that this custom MarkupTextWriter
            ' includes functionality for all other markup elements.
            MyBase.RenderBeginTag(tagKey)
        End Sub