public:
   void DisplaySchemas( XmlSchemaCollection^ xsc )
   {
      XmlSchemaCollectionEnumerator^ ienum = xsc->GetEnumerator();
      while ( ienum->MoveNext() )
      {
         XmlSchema^ schema = ienum->Current;
         StringWriter^ sw = gcnew StringWriter;
         XmlTextWriter^ writer = gcnew XmlTextWriter( sw );
         writer->Formatting = Formatting::Indented;
         writer->Indentation = 2;
         schema->Write( writer );
         Console::WriteLine( sw );
      }
   }