
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security;
public ref class MyClass1
{
public:
   MyClass1(){}

   MyClass1( int i ){}

};

int main()
{
   try
   {
      Type^ myType = MyClass1::typeid;
      array<Type^>^types = gcnew array<Type^>(1);
      types[ 0 ] = int::typeid;
      
      // Get the constructor that takes an integer as a parameter.
      ConstructorInfo^ constructorInfoObj = myType->GetConstructor( types );
      if ( constructorInfoObj != nullptr )
      {
         Console::WriteLine( "The constructor of MyClass1 that takes an integer as a parameter is: " );
         Console::WriteLine( constructorInfoObj );
      }
      else
      {
         Console::WriteLine( "The constructor of MyClass1 that takes an integer as a parameter is not available." );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }
}
// </Snippet1>
