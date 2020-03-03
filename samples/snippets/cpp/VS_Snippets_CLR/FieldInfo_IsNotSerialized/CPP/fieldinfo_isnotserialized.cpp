
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::Serialization;

public ref class MyClass
{
public:
   short myShort;

   // The following field will not be serialized.  

   [NonSerialized]
   int myInt;
};

int main()
{
   // Get the type of MyClass.
   Type^ myType = MyClass::typeid;

   // Get the fields of MyClass.
   array<FieldInfo^>^myFields = myType->GetFields( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::Static) );
   Console::WriteLine( "\nDisplaying whether or not the field is serializable.\n" );

   // Display whether or not the field is serializable.
   for ( int i = 0; i < myFields->Length; i++ )
      if ( myFields[ i ]->IsNotSerialized )
            Console::WriteLine( "The {0} field is not serializable.", myFields[ i ] );
      else
            Console::WriteLine( "The {0} field is serializable.", myFields[ i ] );
}
// </Snippet1>
