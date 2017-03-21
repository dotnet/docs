      // Construct an XML qualified name.
      XmlQualifiedName^ myXmlQualifiedName =
         gcnew XmlQualifiedName( "MathService","http://tempuri2.org/" );

      // Get the Service from the collection.
      myCollection->GetService( myXmlQualifiedName );