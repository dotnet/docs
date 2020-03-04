
// The following code example compares portions of two strings using the different CompareInfo instances:
//    a CompareInfo instance associated with the S"Spanish - Spain" culture with international sort,
//    a CompareInfo instance associated with the S"Spanish - Spain" culture with traditional sort, and
//    a CompareInfo instance associated with the InvariantCulture.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Defines the strings to compare.
   String^ myStr1 = "calle";
   String^ myStr2 = "calor";
   
   // Uses GetCompareInfo to create the CompareInfo that 
   // uses the S"es-ES" culture with international sort.
   CompareInfo^ myCompIntl = CompareInfo::GetCompareInfo( "es-ES" );
   
   // Uses GetCompareInfo to create the CompareInfo that 
   // uses the S"es-ES" culture with traditional sort.
   CompareInfo^ myCompTrad = CompareInfo::GetCompareInfo( 0x040A );
   
   // Uses the CompareInfo property of the InvariantCulture.
   CompareInfo^ myCompInva = CultureInfo::InvariantCulture->CompareInfo;
   
   // Compares two strings using myCompIntl.
   Console::WriteLine( "Comparing \"{0}\" and \"{1}\"", myStr1->Substring( 2 ), myStr2->Substring( 2 ) );
   Console::WriteLine( "   With myCompIntl::Compare: {0}", myCompIntl->Compare( myStr1, 2, myStr2, 2 ) );
   Console::WriteLine( "   With myCompTrad::Compare: {0}", myCompTrad->Compare( myStr1, 2, myStr2, 2 ) );
   Console::WriteLine( "   With myCompInva::Compare: {0}", myCompInva->Compare( myStr1, 2, myStr2, 2 ) );
}

/*
This code produces the following output.

Comparing "lle" and "lor"
   With myCompIntl::Compare: -1
   With myCompTrad::Compare: 1
   With myCompInva::Compare: -1
*/
// </snippet1>
