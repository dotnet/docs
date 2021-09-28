/// Need snippets:
///    21    #ctor()
///    22    #ctor(string)
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

static void Ctor1()
{
   //<snippet21>
   // Create a SoapNormalizedString object.
   SoapNormalizedString^ normalized = gcnew SoapNormalizedString;
   normalized->Value = L"one two";
   Console::WriteLine( L"The value of the SoapNormalizedString object is {0}.",
      normalized );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapNormalizedString object.
   String^ testString = L"one two";
   SoapNormalizedString^ normalized = gcnew SoapNormalizedString(
      testString );
   Console::WriteLine( L"The value of the SoapNormalizedString object is {0}.",
      normalized );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}

