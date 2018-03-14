//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections::Generic;

public ref class Test
{
private:
   static void DisplayGenericTypeInfo( Type^ t )
   {
      Console::WriteLine( L"\r\n{0}", t );
      Console::WriteLine( L"\tIs this a generic type definition? {0}",
         t->IsGenericTypeDefinition );
      Console::WriteLine( L"\tIs it a generic type? {0}",
         t->IsGenericType );
      
      //<Snippet2>
      if ( t->IsGenericType )
      {
         
         // If this is a generic type, display the type arguments.
         //
         array<Type^>^typeArguments = t->GetGenericArguments();
         Console::WriteLine( L"\tList type arguments ({0}):",
            typeArguments->Length );
         System::Collections::IEnumerator^ myEnum =
            typeArguments->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Type^ tParam = safe_cast<Type^>(myEnum->Current);
            
            // If this is a type parameter, display its
            // position.
            //
            if ( tParam->IsGenericParameter )
            {
               Console::WriteLine(
                  L"\t\t{0}\t(unassigned - parameter position {1})",
                  tParam, tParam->GenericParameterPosition );
            }
            else
            {
               Console::WriteLine( L"\t\t{0}", tParam );
            }
         }
      }
      //</Snippet2>
   }


public:
   static void Main()
   {
      Console::Write( L"\r\n--- Display information about a " );
      Console::WriteLine( L"constructed type, its" );
      Console::WriteLine( L"    generic type definition, and an ordinary type." );
      
      // Create a Dictionary of Test objects, using strings for the
      // keys.
      Dictionary< String^,Test^ >^ d = gcnew Dictionary< String^,Test^ >;
      
      // Display information for the constructed type and its generic
      // type definition.
      DisplayGenericTypeInfo( d->GetType() );
      DisplayGenericTypeInfo( d->GetType()->GetGenericTypeDefinition() );
      
      // Display information for an ordinary type.
      DisplayGenericTypeInfo( String::typeid );
   }

};

int main()
{
   Test::Main();
}

/* This example produces the following output:

--- Display information about a constructed type, its
    generic type definition, and an ordinary type.

System.Collections.Generic.Dictionary[System.String,Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

System.Collections.Generic.Dictionary[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey    (unassigned - parameter position 0)
                TValue  (unassigned - parameter position 1)

System.String
        Is this a generic type definition? False
        Is it a generic type? False
 */
//</Snippet1>
