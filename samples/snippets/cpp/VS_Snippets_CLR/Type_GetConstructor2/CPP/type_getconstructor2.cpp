
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security;
public ref class MyClass1
{
public:
   MyClass1( int i ){}

};

int main()
{
   try
   {
      Type^ myType = MyClass1::typeid;
      array<Type^>^types = gcnew array<Type^>(1);
      types[ 0 ] = int::typeid;
      
      // Get the constructor that is public and takes an integer parameter.
      ConstructorInfo^ constructorInfoObj = myType->GetConstructor( static_cast<BindingFlags>(BindingFlags::Instance | BindingFlags::Public), nullptr, types, nullptr );
      if ( constructorInfoObj != nullptr )
      {
         Console::WriteLine( "The constructor of MyClass1 that is public and takes an integer as a parameter is:" );
         Console::WriteLine( constructorInfoObj );
      }
      else
      {
         Console::WriteLine( "The constructor of the MyClass1 that is public and takes an integer as a parameter is not available." );
      }
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "ArgumentNullException: {0}", e->Message );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( "ArgumentException: {0}", e->Message );
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "SecurityException: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
