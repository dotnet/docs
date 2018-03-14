
// The following code example determines the indexes of the first and last occurrences of a character or a substring within a string.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintMarker( String^ Prefix, int First, int Last )
{
   
   // Determines the size of the array to create.
   int mySize;
   if ( Last > First )
      mySize = Last;
   else
      mySize = First;

   if ( mySize > -1 )
   {
      
      // Creates an array of Char to hold the markers.
      array<Char>^myCharArr = gcnew array<Char>(mySize + 1);
      
      // Inserts the appropriate markers.
      if ( First > -1 )
            myCharArr[ First ] = 'f';
      if ( Last > -1 )
            myCharArr[ Last ] = 'l';
      if ( First == Last )
            myCharArr[ First ] = 'b';
      
      // Displays the array of Char as a String.
      Console::WriteLine( "{0}{1}", Prefix, gcnew String( myCharArr ) );
   }
   else
      Console::WriteLine( Prefix );
}

int main()
{
   
   // Creates CompareInfo for the InvariantCulture.
   CompareInfo^ myComp = CultureInfo::InvariantCulture->CompareInfo;
   
   // Searches for the ligature Æ.
   String^ myStr = "Is AE or ae the same as Æ or æ?";
   Console::WriteLine();
   Console::WriteLine( "No options    : {0}", myStr );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE" ), myComp->LastIndexOf( myStr, "AE" ) );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae" ), myComp->LastIndexOf( myStr, "ae" ) );
   PrintMarker( "            Æ : ", myComp->IndexOf( myStr, L'Æ' ), myComp->LastIndexOf( myStr, L'Æ' ) );
   PrintMarker( "            æ : ", myComp->IndexOf( myStr, L'æ' ), myComp->LastIndexOf( myStr, L'æ' ) );
   Console::WriteLine( "Ordinal       : {0}", myStr );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "AE", CompareOptions::Ordinal ) );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "ae", CompareOptions::Ordinal ) );
   PrintMarker( "            Æ : ", myComp->IndexOf( myStr, L'Æ', CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'Æ', CompareOptions::Ordinal ) );
   PrintMarker( "            æ : ", myComp->IndexOf( myStr, L'æ', CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'æ', CompareOptions::Ordinal ) );
   Console::WriteLine( "IgnoreCase    : {0}", myStr );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "AE", CompareOptions::IgnoreCase ) );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "ae", CompareOptions::IgnoreCase ) );
   PrintMarker( "            Æ : ", myComp->IndexOf( myStr, L'Æ', CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'Æ', CompareOptions::IgnoreCase ) );
   PrintMarker( "            æ : ", myComp->IndexOf( myStr, L'æ', CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'æ', CompareOptions::IgnoreCase ) );
   
   // Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
   myStr = "Is U\u0308 or u\u0308 the same as \u00DC or \u00FC?";
   Console::WriteLine();
   Console::WriteLine( "No options    : {0}", myStr );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308" ), myComp->LastIndexOf( myStr, "U\u0308" ) );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308" ), myComp->LastIndexOf( myStr, "u\u0308" ) );
   PrintMarker( "            Ü : ", myComp->IndexOf( myStr, L'Ü' ), myComp->LastIndexOf( myStr, L'Ü' ) );
   PrintMarker( "            ü : ", myComp->IndexOf( myStr, L'ü' ), myComp->LastIndexOf( myStr, L'ü' ) );
   Console::WriteLine( "Ordinal       : {0}", myStr );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "U\u0308", CompareOptions::Ordinal ) );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "u\u0308", CompareOptions::Ordinal ) );
   PrintMarker( "            Ü : ", myComp->IndexOf( myStr, L'Ü', CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'Ü', CompareOptions::Ordinal ) );
   PrintMarker( "            ü : ", myComp->IndexOf( myStr, L'ü', CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'ü', CompareOptions::Ordinal ) );
   Console::WriteLine( "IgnoreCase    : {0}", myStr );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "U\u0308", CompareOptions::IgnoreCase ) );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "u\u0308", CompareOptions::IgnoreCase ) );
   PrintMarker( "            Ü : ", myComp->IndexOf( myStr, L'Ü', CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'Ü', CompareOptions::IgnoreCase ) );
   PrintMarker( "            ü : ", myComp->IndexOf( myStr, L'ü', CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'ü', CompareOptions::IgnoreCase ) );
}

/*
This code produces the following output.

No options    : Is AE or ae the same as Æ or æ?
           AE :    f                    l
           ae :          f                   l
            Æ :    f                    l
            æ :          f                   l
Ordinal       : Is AE or ae the same as Æ or æ?
           AE :    b
           ae :          b
            Æ :                         b
            æ :                              b
IgnoreCase    : Is AE or ae the same as Æ or æ?
           AE :    f                         l
           ae :    f                         l
            Æ :    f                         l
            æ :    f                         l

No options    : Is U" or u" the same as Ü or ü?
           U" :    f                    l
           u" :          f                   l
            Ü :    f                    l
            ü :          f                   l
Ordinal       : Is U" or u" the same as Ü or ü?
           U" :    b
           u" :          b
            Ü :                         b
            ü :                              b
IgnoreCase    : Is U" or u" the same as Ü or ü?
           U" :    f                         l
           u" :    f                         l
            Ü :    f                         l
            ü :    f                         l

*/
// </snippet1>
