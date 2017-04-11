
// The following code example determines whether a String* is the prefix or suffix of another String* using CompareOptions.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Defines the strings to compare.
   String^ myStr1 = "calle";
   String^ myStr2 = "llegar";
   String^ myXfix = "LLE";
   
   // Uses the CompareInfo property of the InvariantCulture.
   CompareInfo^ myComp = CultureInfo::InvariantCulture->CompareInfo;
   Console::WriteLine( "IsSuffix \"{0}\", \"{1}\"", myStr1, myXfix );
   Console::WriteLine( "   With no CompareOptions            : {0}", myComp->IsSuffix( myStr1, myXfix ) );
   Console::WriteLine( "   With None                         : {0}", myComp->IsSuffix( myStr1, myXfix, CompareOptions::None ) );
   Console::WriteLine( "   With Ordinal                      : {0}", myComp->IsSuffix( myStr1, myXfix, CompareOptions::Ordinal ) );
   Console::WriteLine( "   With IgnoreCase                   : {0}", myComp->IsSuffix( myStr1, myXfix, CompareOptions::IgnoreCase ) );
   Console::WriteLine( "IsPrefix \"{0}\", \"{1}\"", myStr2, myXfix );
   Console::WriteLine( "   With no CompareOptions            : {0}", myComp->IsPrefix( myStr2, myXfix ) );
   Console::WriteLine( "   With None                         : {0}", myComp->IsPrefix( myStr2, myXfix, CompareOptions::None ) );
   Console::WriteLine( "   With Ordinal                      : {0}", myComp->IsPrefix( myStr2, myXfix, CompareOptions::Ordinal ) );
   Console::WriteLine( "   With IgnoreCase                   : {0}", myComp->IsPrefix( myStr2, myXfix, CompareOptions::IgnoreCase ) );
}

/*
This code produces the following output.

IsSuffix "calle", "LLE"
   With no CompareOptions            : False
   With None                         : False
   With Ordinal                      : False
   With IgnoreCase                   : True
IsPrefix "llegar", "LLE"
   With no CompareOptions            : False
   With None                         : False
   With Ordinal                      : False
   With IgnoreCase                   : True
*/
// </snippet1>
