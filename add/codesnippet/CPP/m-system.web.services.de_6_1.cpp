      ServiceDescription^ myDescription = gcnew ServiceDescription;

      // Create a StreamReader to read a WSDL file.
      TextReader^ myTextReader = gcnew StreamReader( "MyWsdl.wsdl" );
      myDescription = ServiceDescription::Read( myTextReader );
      Console::WriteLine( "Bindings are: " );

      // Display the Bindings present in the WSDL file.
      System::Collections::IEnumerator^ myEnum = myDescription->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ myBinding = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( myBinding->Name );
      }