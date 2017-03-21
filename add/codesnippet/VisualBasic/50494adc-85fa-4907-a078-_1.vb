         ' Construct an XML qualified name.
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("AddSoapIn", "http://tempuri2.org/")

         ' Get the Message from the collection.
         Dim myMessage As Message = myCollection.GetMessage(myXmlQualifiedName)