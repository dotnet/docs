private:
   void TestDocument( String^ filename, Type^ objType )
   {
      // Using a FileStream, create an XmlTextReader.
      Stream^ fs = gcnew FileStream( filename,FileMode::Open );
      XmlReader^ reader = gcnew XmlTextReader( fs );
      XmlSerializer^ serializer = gcnew XmlSerializer( objType );
      if ( serializer->CanDeserialize( reader ) )
      {
         Object^ o = serializer->Deserialize( reader );
      }
      fs->Close();
   }