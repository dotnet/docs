      // Construct an XML qualified name.
      XmlQualifiedName^ myXmlQualifiedName =
         gcnew XmlQualifiedName( "AddSoapIn","http://tempuri2.org/" );
      
      // Get the Message from the collection.
      myCollection->GetMessage( myXmlQualifiedName );