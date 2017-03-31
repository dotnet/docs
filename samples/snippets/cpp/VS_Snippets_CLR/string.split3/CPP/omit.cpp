
//<snippet1>
// This example demonstrates the String.Split(Char[], Boolean) and 
//                               String.Split(Char[], Int32, Boolean) methods
using namespace System;
void Show( array<String^>^entries )
{
   Console::WriteLine( "The return value contains these {0} elements:", entries->Length );
   System::Collections::IEnumerator^ myEnum = entries->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ entry = safe_cast<String^>(myEnum->Current);
      Console::Write( "<{0}>", entry );
   }

   Console::Write( "{0}{0}", Environment::NewLine );
}

int main()
{
   String^ s = ",one,,,two,,,,,three,,";
   array<Char>^sep = gcnew array<Char>{
      ','
   };
   array<String^>^result;
   
   //
   Console::WriteLine( "The original string is \"{0}\".", s );
   Console::WriteLine( "The separation character is '{0}'.", sep[ 0 ] );
   Console::WriteLine();
   
   //
   Console::WriteLine( "Split the string and return all elements:" );
   result = s->Split( sep, StringSplitOptions::None );
   Show( result );
   
   //
   Console::WriteLine( "Split the string and return all non-empty elements:" );
   result = s->Split( sep, StringSplitOptions::RemoveEmptyEntries );
   Show( result );
   
   //
   Console::WriteLine( "Split the string and return 2 elements:" );
   result = s->Split( sep, 2, StringSplitOptions::None );
   Show( result );
   
   //
   Console::WriteLine( "Split the string and return 2 non-empty elements:" );
   result = s->Split( sep, 2, StringSplitOptions::RemoveEmptyEntries );
   Show( result );
}

/*
This example produces the following results:

The original string is ",one,,,two,,,,,three,,".
The separation character is ','.

Split the string and return all elements:
The return value contains these 12 elements:
<><one><><><two><><><><><three><><>

Split the string and return all non-empty elements:
The return value contains these 3 elements:
<one><two><three>

Split the string and return 2 elements:
The return value contains these 2 elements:
<><one,,,two,,,,,three,,>

Split the string and return 2 non-empty elements:
The return value contains these 2 elements:
<one><,,two,,,,,three,,>

*/
//</snippet1>
