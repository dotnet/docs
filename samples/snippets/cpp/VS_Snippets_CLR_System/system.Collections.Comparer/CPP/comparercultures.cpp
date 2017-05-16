
// The following code example shows how Compare returns different values depending on the culture associated with the Comparer.
// <snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Globalization;
int main()
{
   
   // Creates the strings to compare.
   String^ str1 = "llegar";
   String^ str2 = "lugar";
   Console::WriteLine( "Comparing \"{0}\" and \"{1}\" ...", str1, str2 );
   
   // Uses the DefaultInvariant Comparer.
   Console::WriteLine( "   Invariant Comparer: {0}", Comparer::DefaultInvariant->Compare( str1, str2 ) );
   
   // Uses the Comparer based on the culture "es-ES" (Spanish - Spain, international sort).
   Comparer^ myCompIntl = gcnew Comparer( gcnew CultureInfo(  "es-ES",false ) );
   Console::WriteLine( "   International Sort: {0}", myCompIntl->Compare( str1, str2 ) );
   
   // Uses the Comparer based on the culture identifier 0x040A (Spanish - Spain, traditional sort).
   Comparer^ myCompTrad = gcnew Comparer( gcnew CultureInfo( 0x040A,false ) );
   Console::WriteLine( "   Traditional Sort  : {0}", myCompTrad->Compare( str1, str2 ) );
}

/*
This code produces the following output.

Comparing "llegar" and "lugar" ...
   Invariant Comparer: -1
   International Sort: -1
   Traditional Sort  : 1

*/
// </snippet1>
