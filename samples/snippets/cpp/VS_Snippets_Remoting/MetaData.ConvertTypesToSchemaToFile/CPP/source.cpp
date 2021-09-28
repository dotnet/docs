// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting::Metadata;
using namespace System::Runtime::Remoting::MetadataServices;

ref class TestClass
{
private:
   int integer;

public:
   static const double dFloatingPoint = 5.1999;

   property int Int
   {
      int get()
      {
         return integer;
      }
      void set( int value )
      {
         integer = value;
      }
   }
   void Print()
   {
      Console::WriteLine( "The double is equal to {0}.", dFloatingPoint );
   }
};

int main()
{
   array<Type^>^types = gcnew array<Type^>(4);
   String^ s = "a";
   int i = -5;
   double d = 3.1415;
   TestClass^ tc = gcnew TestClass;
   types[ 0 ] = s->GetType();
   types[ 1 ] = i.GetType();
   types[ 2 ] = d.GetType();
   types[ 3 ] = tc->GetType();
   MetaData::ConvertTypesToSchemaToFile( types, SdlType::Wsdl, "test.xml" );
   return 0;
}
// </Snippet1>
