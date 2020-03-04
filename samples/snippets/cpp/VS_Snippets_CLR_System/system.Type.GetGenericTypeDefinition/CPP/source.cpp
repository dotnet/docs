//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections::Generic;

public ref class Test
{
public:
   static void Main()
   {
      Console::Write( L"\r\n--- Get the generic type that " );
      Console::WriteLine( L"defines a constructed type." );
     
      // Create a Dictionary of Test objects, using strings for the
      // keys.
      Dictionary< String^,Test^ >^ d = gcnew Dictionary< String^,Test^ >;
      
      // Get a Type object representing the constructed type.
      //
      Type^ constructed = d->GetType();
      DisplayTypeInfo( constructed );
      Type^ myGeneric = constructed->GetGenericTypeDefinition();
      DisplayTypeInfo( myGeneric );
   }

private:
   static void DisplayTypeInfo( Type^ t )
   {
      Console::WriteLine( L"\r\n{0}", t );
      Console::WriteLine( L"\tIs this a generic type definition? {0}",
         t->IsGenericTypeDefinition );
      Console::WriteLine( L"\tIs it a generic type? {0}",
         t->IsGenericType );
      array<Type^>^typeArguments = t->GetGenericArguments();
      Console::WriteLine( L"\tList type arguments ({0}):",
         typeArguments->Length );
      System::Collections::IEnumerator^ myEnum =
         typeArguments->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Type^ tParam = safe_cast<Type^>(myEnum->Current);
         Console::WriteLine( L"\t\t{0}", tParam );
      }
   }
};

int main()
{
   Test::Main();
}

/* This example produces the following output:

--- Get the generic type that defines a constructed type.

System.Collections.Generic.Dictionary`2[System.String,Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

System.Collections.Generic.Dictionary`2[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey
                TValue
 */
//</Snippet1>
