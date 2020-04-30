/// Need snippets:
///    21    #ctor()
///    22    #ctor(string)
///    23    #ctor(string,string)
///    24    #ctor(string,string,string)
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

static void Ctor1()
{
   //<snippet21>
   // Create a SoapQName object.
   SoapQName^ qName = gcnew SoapQName;
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapQName object.
   String^ name = L"SomeName";
   SoapQName^ qName = gcnew SoapQName( name );
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );
   //</snippet22>
}

static void Ctor3()
{
   //<snippet23>
   // Create a SoapQName object.
   String^ key = L"tns";
   String^ name = L"SomeName";
   SoapQName^ qName = gcnew SoapQName( key,name );
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );
   //</snippet23>
}

static void Ctor4()
{
   //<snippet24>
   // Create a SoapQName object.
   String^ key = L"tns";
   String^ name = L"SomeName";
   String^ namespaceValue = L"http://example.org";
   SoapQName^ qName = gcnew SoapQName(
      key,name,namespaceValue );
   Console::WriteLine(
      L"The value of the SoapQName object is \"{0}\".", qName );
   //</snippet24>
}

int main()
{
   Ctor1();
   Ctor2();
   Ctor3();
   Ctor4();
}
