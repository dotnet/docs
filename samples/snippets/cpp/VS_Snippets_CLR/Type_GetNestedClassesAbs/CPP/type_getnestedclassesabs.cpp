
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Create a class with two nested public classes and two nested protected classes.
public ref class MyTypeClass
{
   public:
      ref class Myclass1{};
   
   public:
      ref class Myclass2{};
   
   protected:
      ref class MyClass3{};
   
   protected:
      ref class MyClass4{};
};

void DisplayTypeInfo(array<Type^>^ myArrayType)
{
   // Display the information for all the nested classes.
   for each (Type^ t in myArrayType)
      Console::WriteLine( "The name of the nested class is {0}.", t->FullName);
}

int main()
{
   Type^ myType = MyTypeClass::typeid;
   
   // Get the public nested classes.
   array<Type^>^myTypeArray = myType->GetNestedTypes( static_cast<BindingFlags>(BindingFlags::Public));
   Console::WriteLine( "The number of nested public classes is {0}.", myTypeArray->Length );
  
   // Display all the public nested classes.
   DisplayTypeInfo( myTypeArray );
   Console::WriteLine();
   
   // Get the nonpublic nested classes.
   array<Type^>^myTypeArray1 = myType->GetNestedTypes( static_cast<BindingFlags>(BindingFlags::NonPublic));
   Console::WriteLine( "The number of nested protected classes is {0}.", myTypeArray1->Length );
   
   // Display all the nonpublic nested classes.
   DisplayTypeInfo( myTypeArray1 );
}
// The example displays the following output:
//       The number of public nested classes is 2.
//       The name of the nested class is MyTypeClass+Myclass1.
//       The name of the nested class is MyTypeClass+Myclass2.
//       
//       The number of protected nested classes is 2.
//       The name of the nested class is MyTypeClass+MyClass3.
//       The name of the nested class is MyTypeClass+MyClass4.
// </Snippet1>
