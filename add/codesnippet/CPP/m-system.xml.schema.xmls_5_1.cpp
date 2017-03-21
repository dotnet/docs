      if ( xsc->Contains( "urn:bookstore-schema" ) )
      {
         XmlSchema^ schema = xsc[ "urn:bookstore-schema" ];
         StringWriter^ sw = gcnew StringWriter;
         XmlTextWriter^ xmlWriter = gcnew XmlTextWriter( sw );
         xmlWriter->Formatting = Formatting::Indented;
         xmlWriter->Indentation = 2;
         schema->Write( xmlWriter );
         Console::WriteLine( sw );
      }