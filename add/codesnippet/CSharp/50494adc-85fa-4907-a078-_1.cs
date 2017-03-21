         // Construct an XML qualified name.
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("AddSoapIn", "http://tempuri2.org/");

         // Get the Message from the collection.
         Message  myMessage = myCollection.GetMessage(myXmlQualifiedName);