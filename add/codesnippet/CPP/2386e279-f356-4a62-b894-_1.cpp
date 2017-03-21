      // Construct an XML qualified name.
      XmlQualifiedName^ myXmlQualifiedName =
         gcnew XmlQualifiedName( "MathServiceSoap","http://tempuri2.org/" );
      
      // Get the PortType from the collection.
      myCollection->GetPortType( myXmlQualifiedName );