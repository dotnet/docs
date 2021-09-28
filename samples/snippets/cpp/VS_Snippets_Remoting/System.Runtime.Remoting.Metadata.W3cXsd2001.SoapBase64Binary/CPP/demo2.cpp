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
   // Create a SoapBase64Binary object.
   SoapBase64Binary^ base64Binary = gcnew SoapBase64Binary;
   base64Binary->Value = gcnew array<Byte>(7){
      2,3,5,7,11,0,5
   };
   Console::WriteLine( L"The SoapBase64Binary object is {0}.",
      base64Binary );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapBase64Binary object.
   array<Byte>^bytes = gcnew array<Byte>(5){
      2,3,5,7,11
   };
   SoapBase64Binary^ base64Binary = gcnew SoapBase64Binary( bytes );
   Console::WriteLine( L"The SoapBase64Binary object is {0}.",
      base64Binary );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}

