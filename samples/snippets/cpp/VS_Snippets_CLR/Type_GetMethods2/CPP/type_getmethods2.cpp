
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// Create a class having two public methods and one protected method.
public ref class MyTypeClass
{
public:
   void MyMethods(){}

   int MyMethods1()
   {
      return 3;
   }


protected:
   String^ MyMethods2()
   {
      return "hello";
   }
};

void DisplayMethodInfo( array<MethodInfo^>^myArrayMethodInfo )
{
   // Display information for all methods.
   for ( int i = 0; i < myArrayMethodInfo->Length; i++ )
   {
      MethodInfo^ myMethodInfo = dynamic_cast<MethodInfo^>(myArrayMethodInfo[ i ]);
      Console::WriteLine( "\nThe name of the method is {0}.", myMethodInfo->Name );
   }
}

int main()
{
   Type^ myType = MyTypeClass::typeid;
   
   // Get the public methods.
   array<MethodInfo^>^myArrayMethodInfo = myType->GetMethods( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance | BindingFlags::DeclaredOnly) );
   Console::WriteLine( "\nThe number of public methods is {0}->", myArrayMethodInfo->Length );
   
   // Display all the methods.
   DisplayMethodInfo( myArrayMethodInfo );
   
   // Get the nonpublic methods.
   array<MethodInfo^>^myArrayMethodInfo1 = myType->GetMethods( static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::DeclaredOnly) );
   Console::WriteLine( "\nThe number of protected methods is {0}->", myArrayMethodInfo1->Length );
   
   // Display information for all methods.
   DisplayMethodInfo( myArrayMethodInfo1 );
}
// </Snippet1>
