   // Create a SoapQName object.
   String^ key = L"tns";
   String^ name = L"SomeName";
   String^ namespaceValue = L"http://example.org";
   SoapQName^ qName = gcnew SoapQName(
      key,name,namespaceValue );
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );