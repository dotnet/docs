

// System.Web.Services.Protocols.SoapHeader.EncodedMustUnderstand
/*
This program demonstrates the 'EncodedMustUnderstand' property of
the 'SoapHeader' class. This example calls two webservice methods,
namely 'WebMethod1' for which the property 'DidUnderstand' is set
to true and 'WebMethod2' for which the property 'DidUnderstand'
is set to false. The property 'EncodedMustUnderstand' is set to '1'
for the client soapheader. The client calls the method 'WebMethod2' 
whose 'DidUnderstand' property is set to false and hence a 'SoapHeaderException'
is thrown.
*/
#using <System.dll>
#using <System.Web.dll>
#using <System.Web.Services.dll>
#using <WebService_SoapHeader_EncodedMustUnderstand.dll>

using namespace System;

int main()
{
   try
   {
      // <Snippet1>
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
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!" );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }
}
