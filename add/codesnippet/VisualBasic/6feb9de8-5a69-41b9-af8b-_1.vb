         ' Construct an XML qualified name.
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("MathService", "http://tempuri2.org/")

         ' Get the Service from the collection.
         Dim myService As Service = myCollection.GetService(myXmlQualifiedName)