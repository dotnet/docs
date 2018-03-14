/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;
static void Ctor1()
{
   //<snippet21>
   // Create a SoapNegativeInteger object.
   SoapNegativeInteger^ xsdInteger = gcnew SoapNegativeInteger;
   xsdInteger->Value = -14;
   Console::WriteLine( L"The value of the SoapNegativeInteger object is {0}.",
      xsdInteger );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapNegativeInteger object.
   Decimal decimalValue = -14;
   SoapNegativeInteger^ xsdInteger = gcnew SoapNegativeInteger( 
      decimalValue );
   Console::WriteLine( L"The value of the SoapNegativeInteger object is {0}.",
      xsdInteger );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}

