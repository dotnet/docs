   // Create a SoapQName object.
   String^ key = L"tns";
   String^ name = L"SomeName";
   SoapQName^ qName = gcnew SoapQName( key,name );
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );