#using <system.dll>
#using <system.runtime.remoting.dll>
#using <system.runtime.serialization.formatters.soap.dll>

using namespace System;
using namespace System::IO;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Soap;
using namespace System::Runtime::Remoting::Metadata;

// A test Object* that needs to be serialized
// <Snippet1>
[Serializable]
[SoapTypeAttribute(XmlNamespace="MyXmlNamespace")]
public ref class TestSimpleObject
{
public:
   int member1;

   [SoapFieldAttribute(XmlElementName="MyXmlElement")] String^ member2;

   String^ member3;
   double member4;

   // A field that is not serialized.

   [NonSerialized] String^ member5;

   TestSimpleObject()
   {
      member1 = 11;
      member2 = "hello";
      member3 = "hello";
      member4 = 3.14159265;
      member5 = "hello world!";
   }
};
// </Snippet1>

int main()
{
   // Creates a new TestSimpleObject Object^.
   TestSimpleObject^ obj = gcnew TestSimpleObject;
   
   // Opens a file and serializes the Object^ into it in binary format.
   Stream^ stream = File::Open( "data.xml", FileMode::Create );
   SoapFormatter^ formatter = gcnew SoapFormatter;
   formatter->Serialize( stream, obj );
   stream->Close();
}
