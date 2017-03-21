         ' Construct an XML qualified name.
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("MathServiceSoap", "http://tempuri2.org/")
         ' Get the PortType from the collection.
         Dim myPort As PortType = myCollection.GetPortType(myXmlQualifiedName)