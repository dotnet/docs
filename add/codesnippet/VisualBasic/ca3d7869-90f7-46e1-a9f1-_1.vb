            ' If the <label> element is rendered and a style
            ' attribute is not defined, add a style attribute 
            ' and set its value to blue.
            If TagKey = HtmlTextWriterTag.Label Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Style) Then
                    AddAttribute("style", EncodeAttributeValue("color:blue", True))
                    Write(NewLine)
                    Indent = 3
                    OutputTabs()
                End If
            End If