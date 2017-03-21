      // Construct an XML qualified name.
      XmlQualifiedName^ myXmlQualifiedName =
         gcnew XmlQualifiedName( "MathServiceSoap","http://tempuri2.org/" );
      
      // Get the Binding from the collection.
      myCollection->GetBinding( myXmlQualifiedName );