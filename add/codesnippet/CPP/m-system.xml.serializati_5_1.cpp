private:
   void SerializeObject( String^ filename )
   {
      XmlSerializer^ serializer = gcnew XmlSerializer(
         OrderedItem::typeid,"http://www.cpandl.com" );

      // Create an instance of the class to be serialized.
      OrderedItem^ i = gcnew OrderedItem;

      // Insert code to set property values.

      // Writing the document requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );
      // Serialize the object, and close the TextWriter
      serializer->Serialize( writer, i );
      writer->Close();
   }

   void DeserializeObject( String^ filename )
   {
      XmlSerializer^ serializer = gcnew XmlSerializer(
         OrderedItem::typeid,"http://www.cpandl.com" );
      // A FileStream is needed to read the XML document.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );

      // Declare an object variable of the type to be deserialized.
      OrderedItem^ i;

      // Deserialize the object.
      i = dynamic_cast<OrderedItem^>(serializer->Deserialize( fs ));

      // Insert code to use the properties and methods of the object.
   }