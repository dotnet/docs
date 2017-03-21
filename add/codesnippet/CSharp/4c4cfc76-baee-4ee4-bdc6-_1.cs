         // Construct an XML qualified name.
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("MathServiceSoap", "http://tempuri2.org/");
        
         // Get the Binding from the collection.
         Binding myBinding = myCollection.GetBinding(myXmlQualifiedName);