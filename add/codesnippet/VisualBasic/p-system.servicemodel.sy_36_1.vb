        Dim item As New SyndicationItem()

        ' Add several different types of element extensions
        item.ElementExtensions.Add("simpleString", "", "hello, world!")
        item.ElementExtensions.Add("simpleString", "", "another simple string")

        ' DataContractExtension is a user-defined type marked with the DataContractAttribute
        item.ElementExtensions.Add(New DataContractExtension With {.Key = "X", .Value = 4})

        ' XmlSerializerExtension is a user-defined type that defines a ToString() method
        item.ElementExtensions.Add(New XmlSerializerExtension With {.Key = "Y", .Value = 8}, New XmlSerializer(GetType(XmlSerializerExtension)))

        item.ElementExtensions.Add(New XElement("xElementExtension", New XElement("Key", New XAttribute("attr1", "someValue"), "Z"), _
                New XElement("Value", New XAttribute("attr1", "someValue"), "15")).CreateReader())