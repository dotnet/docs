
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class MyClass
{
public:
   ref class NestClass
   {
      public:
         static int myPublicInt = 0;
   };

   ref struct NestStruct
   {
      public:
         static int myPublicInt = 0;
   };
};

int main()
{
   try
   {
      // Get the Type object corresponding to MyClass.
      Type^ myType = MyClass::typeid;
      
      // Get an array of nested type objects in MyClass.
      array<Type^>^nestType = myType->GetNestedTypes();
      Console::WriteLine( "The number of nested types is {0}.", nestType->Length );
      System::Collections::IEnumerator^ myEnum = nestType->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Type^ t = safe_cast<Type^>(myEnum->Current);
         Console::WriteLine( "Nested type is {0}.", t );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Error {0}", e->Message );
   }
}
// </Snippet1>
