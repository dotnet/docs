/// Need snippets:
///    21    #ctor()
///    22    #ctor(string)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

static void Ctor1()
{
   //<snippet21>
   // Create a SoapAnyUri object.
   SoapAnyUri^ anyUri = gcnew SoapAnyUri;
   anyUri->Value = L"http://localhost:8080/WebService";
   Console::WriteLine( L"The value of the SoapAnyUri object is {0}.", anyUri );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapAnyUri object.
   String^ anyUriValue = L"http://localhost:8080/WebService";
   SoapAnyUri^ anyUri = gcnew SoapAnyUri( anyUriValue );
   Console::WriteLine( L"The value of the SoapAnyUri object is {0}.", anyUri );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}

