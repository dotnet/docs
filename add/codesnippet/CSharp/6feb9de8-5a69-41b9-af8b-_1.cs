         // Construct an XML qualified name.
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("MathService", "http://tempuri2.org/");

         // Get the Service from the collection.
         Service myService = myCollection.GetService(myXmlQualifiedName);