public:
   void CreateBook( String^ filename )
   {
      try
      {
         // Create instance of XmlSerializerNamespaces and add the namespaces.
         XmlSerializerNamespaces^ myNameSpaces = gcnew XmlSerializerNamespaces;
         myNameSpaces->Add( "BookName", "http://www.cpandl.com" );
         
         // Create instance of XmlSerializer and specify the type of object
         // to be serialized.
         XmlSerializer^ mySerializerObject =
            gcnew XmlSerializer( MyBook::typeid );

         TextWriter^ myWriter = gcnew StreamWriter( filename );
         // Create object to be serialized.
         MyBook^ myXMLBook = gcnew MyBook;

         myXMLBook->Author = "XMLAuthor";
         myXMLBook->BookName = "DIG THE XML";
         myXMLBook->Description = "This is a XML Book";

         MyPriceClass^ myBookPrice = gcnew MyPriceClass;
         myBookPrice->Price = (Decimal)45.89;
         myBookPrice->Units = "$";
         myXMLBook->BookPrice = myBookPrice;
         
         // Serialize the object.
         mySerializerObject->Serialize( myWriter, myXMLBook, myNameSpaces );
         myWriter->Close();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception: {0} occured", e->Message );
      }
   }