   NameTable^ nt = gcnew NameTable;
   Object^ book = nt->Add( "book" );
   Object^ price = nt->Add( "price" );
   
   // Create the reader.
   XmlReaderSettings ^ settings = gcnew XmlReaderSettings;
   settings->NameTable = nt;
   XmlReader^ reader = XmlReader::Create( (String^)"books.xml", settings );
   reader->MoveToContent();
   reader->ReadToDescendant( "book" );
   if ( System::Object::ReferenceEquals( book, reader->Name ) )
   {
      
      // Do additional processing.
   }