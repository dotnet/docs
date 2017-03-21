        Dim feed As New SyndicationFeed()

        ' Add several different types of element extensions.
        feed.ElementExtensions.Add("simpleString", "", "hello, world!")
        feed.ElementExtensions.Add("simpleString", "", "another simple string")

        '  DataContractExtension is a user-defined type marked with the DataContractAttribute
        feed.ElementExtensions.Add(New DataContractExtension With {.Key = "X", .Value = 4})

        '  XmlSerializerExtension is a user-defined type that defines a ToString() method
        feed.ElementExtensions.Add(New XmlSerializerExtension With {.Key = "Y", .Value = 8}, New XmlSerializer(GetType(XmlSerializerExtension)))

        feed.ElementExtensions.Add(New XElement("xElementExtension", _
                                    New XElement("Key", New XAttribute("attr1", "someValue"), "Z"), _
                                    New XElement("Value", New XAttribute("attr1", "someValue"), "15")).CreateReader())