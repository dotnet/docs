   virtual void ReadXml( XmlReader^ reader )
   {
      personName = reader->ReadString();
   }