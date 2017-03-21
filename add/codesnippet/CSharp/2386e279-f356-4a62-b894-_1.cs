         // Construct an XML qualified name.
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("MathServiceSoap","http://tempuri2.org/");
         // Get the PortType from the collection.
         PortType myPort = myCollection.GetPortType(myXmlQualifiedName);