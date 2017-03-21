   // Create a SoapQName object.
   String^ name = L"SomeName";
   SoapQName^ qName = gcnew SoapQName( name );
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );