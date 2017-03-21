      // Create a StreamReader to read a WSDL file.
      StreamReader^ myStreamReader = gcnew StreamReader( "MyWsdl.wsdl" );
      ServiceDescription^ myDescription = ServiceDescription::Read( myStreamReader );
      Console::WriteLine( "Bindings are: " );

      // Display the Bindings present in the WSDL file.
      System::Collections::IEnumerator^ myEnum = myDescription->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ myBinding = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( myBinding->Name );
      }