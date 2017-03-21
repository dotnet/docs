private:
   void serializer_UnknownAttribute( Object^ /*sender*/, XmlAttributeEventArgs^ e )
   {
      System::Xml::XmlAttribute^ attr = e->Attr;
      Console::WriteLine( "Unknown Attribute Name and Value: {0} = '{1}'",
         attr->Name, attr->Value );
      Object^ x = e->ObjectBeingDeserialized;
      Console::WriteLine( "ObjectBeingDeserialized: {0}", x );
   }