         ' Construct an XML qualified name.
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("MathServiceSoap", "http://tempuri2.org/")
         
         ' Get the Binding from the collection.
         Dim myBinding As Binding = _
            myCollection.GetBinding(myXmlQualifiedName)