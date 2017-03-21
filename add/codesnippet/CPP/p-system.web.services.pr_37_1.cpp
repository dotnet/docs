      // MyHeader class is derived from the SoapHeader class.
      MyHeader ^ customHeader = gcnew MyHeader;
      customHeader->MyValue = "Header value for MyValue";

      // Set the EncodedMustUnderstand property to true.
      customHeader->EncodedMustUnderstand = "1";
      WebService_SoapHeader_EncodedMustUnderstand ^ myWebService = gcnew WebService_SoapHeader_EncodedMustUnderstand;
      myWebService->myHeader1 = customHeader;
      String^ results = myWebService->MyWebMethod1();
      Console::WriteLine( results );
      try
      {
         results = myWebService->MyWebMethod2();
      }
      catch ( Exception^ myException ) 
      {
         Console::WriteLine( "Exception raised in MyWebMethod2." );
         Console::WriteLine( "Message: {0}", myException->Message );
      }