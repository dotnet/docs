        ' Override the FilterAttributes method to check whether 
        ' <label> and <anchor> elements contain specific attributes.   
        Protected Overrides Sub FilterAttributes()

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
            ' If an <anchor> element is rendered and an href
            ' attribute has not been defined, call the AddAttribute
            ' method to add an href attribute
            ' and set it to http://www.cohowinery.com.
            ' Use the EncodeUrl method to convert any spaces to %20.
            If TagKey = HtmlTextWriterTag.A Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Href) Then
                    AddAttribute("href", EncodeUrl("http://www.cohowinery.com"))
                End If
            End If

            ' Call the FilterAttributes method of the base class.
            MyBase.FilterAttributes()
        End Sub