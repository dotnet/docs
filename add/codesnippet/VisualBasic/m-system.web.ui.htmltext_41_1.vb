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