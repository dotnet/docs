        ' Create the XmlNodeReader object.
        Dim doc As New XmlDocument()
        doc.Load("books.xml")
        Dim nodeReader As New XmlNodeReader(doc)
        
        ' Set the validation settings.
        Dim settings As New XmlReaderSettings()
        settings.ValidationType = ValidationType.Schema
        settings.Schemas.Add("urn:bookstore-schema", "books.xsd")
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
        
        ' Create a validating reader that wraps the XmlNodeReader object.
        Dim reader As XmlReader = XmlReader.Create(nodeReader, settings)
        ' Parse the XML file.
        While reader.Read()
        End While