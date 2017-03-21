            ' If the tagKey parameter is set to a <font> element
            ' but a size attribute is not defined on the element,
            ' the AddStyleAttribute method adds a size attribute
            ' and sets it to 30 point. 
            If tagKey = HtmlTextWriterTag.Font Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Size) Then
                    AddAttribute(GetAttributeKey("size"), "30pt")
                End If
            End If