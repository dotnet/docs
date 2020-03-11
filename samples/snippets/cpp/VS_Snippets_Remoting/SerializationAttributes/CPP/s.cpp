

// <Snippet1>
#using <system.dll>
#using <system.messaging.dll>
#using <System.Runtime.Serialization.Formatters.Soap.dll>

using namespace System;
using namespace System::IO;
using namespace System::Runtime::Serialization::Formatters::Soap;

// A test object that needs to be serialized.

[Serializable]
ref class TestSimpleObject
{
private:
   int member1;
   String^ member2;
   String^ member3;
   double member4;

public:

   // A field that is not serialized.

   [NonSerialized]
   String^ member5;
   TestSimpleObject()
   {
      member1 = 11;
      member2 = "hello";
      member3 = "hello";
      member4 = 3.14159265;
      member5 = "hello world!";
   }

   void Print()
   {
      Console::WriteLine( "member1 = ' {0}'", member1 );
      Console::WriteLine( "member2 = ' {0}'", member2 );
      Console::WriteLine( "member3 = ' {0}'", member3 );
      Console::WriteLine( "member4 = ' {0}'", member4 );
      Console::WriteLine( "member5 = ' {0}'", member5 );
   }

};

int main()
{
   // Creates a new TestSimpleObject object.
   TestSimpleObject^ obj = gcnew TestSimpleObject;
   Console::WriteLine( "Before serialization the Object* contains: " );
   obj->Print();

   // Opens a file and serializes the object into it in binary format.
   Stream^ stream = File::Open( "data.xml", FileMode::Create );
   SoapFormatter^ formatter = gcnew SoapFormatter;

   //BinaryFormatter* formatter = new BinaryFormatter();
   formatter->Serialize( stream, obj );
   stream->Close();

   // Empties obj.
   obj = nullptr;

   // Opens file S"data.xml" and deserializes the object from it.
   stream = File::Open( "data.xml", FileMode::Open );
   formatter = gcnew SoapFormatter;

   //formatter = new BinaryFormatter();
   obj = dynamic_cast<TestSimpleObject^>(formatter->Deserialize( stream ));
   stream->Close();
   Console::WriteLine( "" );
   Console::WriteLine( "After deserialization the object contains: " );
   obj->Print();
}

// </Snippet1>
