    Protected Overrides Sub DeserializeElement(ByVal reader _
        As System.Xml.XmlReader, _
        ByVal serializeCollectionKey As Boolean)

        MyBase.DeserializeElement(reader, _
            serializeCollectionKey)
        ' Enter your custom processing code here.
    End Sub 'DeserializeElement