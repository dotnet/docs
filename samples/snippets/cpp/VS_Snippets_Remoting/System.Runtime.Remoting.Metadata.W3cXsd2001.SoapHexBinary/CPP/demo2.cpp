/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

static void Ctor1()
{
   //<snippet21>
   // Create a SoapHexBinary object.
   SoapHexBinary^ hexBinary = gcnew SoapHexBinary;
   hexBinary->Value = gcnew array<Byte>(5){
      2,3,5,7,11
   };
   Console::WriteLine( L"The SoapHexBinary object is {0}.", hexBinary );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapHexBinary object.
   array<Byte>^ bytes = gcnew array<Byte>(5){
      2,3,5,7,11
   };
   SoapHexBinary^ hexBinary = gcnew SoapHexBinary( bytes );
   Console::WriteLine( L"The SoapHexBinary object is {0}.", hexBinary );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}

