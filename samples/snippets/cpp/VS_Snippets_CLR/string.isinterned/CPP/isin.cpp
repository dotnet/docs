//<snippet1>
// Sample for String::IsInterned(String)
using namespace System;
using namespace System::Text;
using namespace System::Runtime::CompilerServices;

// In the .NET Framework 2.0 the following attribute declaration allows you to 
// avoid the use of the interning when you use NGEN.exe to compile an assembly 
// to the native image cache.
[assembly:CompilationRelaxations(CompilationRelaxations::NoStringInterning)];
void Test( int sequence, String^ str )
{
   Console::Write( "{0} The string '", sequence );
   String^ strInterned = String::IsInterned( str );
   if ( strInterned == nullptr )
      Console::WriteLine( "{0}' is not interned.", str );
   else
      Console::WriteLine( "{0}' is interned.", strInterned );
}

int main()
{
   
   // String str1 is known at compile time, and is automatically interned.
   String^ str1 = "abcd";
   
   // Constructed string, str2, is not explicitly or automatically interned.
   String^ str2 = (gcnew StringBuilder)->Append( "wx" )->Append( "yz" )->ToString();
   Console::WriteLine();
   Test( 1, str1 );
   Test( 2, str2 );
}

//This example produces the following results:

//1) The string, 'abcd', is interned.
//2) The string, 'wxyz', is not interned.

//If you use NGEN.exe to compile the assembly to the native image cache, this
//example produces the following results:

//1) The string, 'abcd', is not interned.
//2) The string, 'wxyz', is not interned.

//</snippet1>
