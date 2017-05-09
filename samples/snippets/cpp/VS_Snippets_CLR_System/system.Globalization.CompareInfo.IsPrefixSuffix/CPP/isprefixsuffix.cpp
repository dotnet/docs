
// The following code example determines whether a String* is the prefix or suffix of another String*.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Defines the strings to compare.
   String^ myStr1 = "calle";
   String^ myStr2 = "llegar";
   String^ myXfix = "lle";
   
   // Uses the CompareInfo property of the InvariantCulture.
   CompareInfo^ myComp = CultureInfo::InvariantCulture->CompareInfo;
   
   // Determines whether myXfix is a prefix of S"calle" and S"llegar".
   Console::WriteLine( "IsPrefix( {0}, {1}) : {2}", myStr1, myXfix, myComp->IsPrefix( myStr1, myXfix ) );
   Console::WriteLine( "IsPrefix( {0}, {1}) : {2}", myStr2, myXfix, myComp->IsPrefix( myStr2, myXfix ) );
   
   // Determines whether myXfix is a suffix of S"calle" and S"llegar".
   Console::WriteLine( "IsSuffix( {0}, {1}) : {2}", myStr1, myXfix, myComp->IsSuffix( myStr1, myXfix ) );
   Console::WriteLine( "IsSuffix( {0}, {1}) : {2}", myStr2, myXfix, myComp->IsSuffix( myStr2, myXfix ) );
}

/*
This code produces the following output.

IsPrefix(calle, lle) : False
IsPrefix(llegar, lle) : True
IsSuffix(calle, lle) : True
IsSuffix(llegar, lle) : False

*/
// </snippet1>
