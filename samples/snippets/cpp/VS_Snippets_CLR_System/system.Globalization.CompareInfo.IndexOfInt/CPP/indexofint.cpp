
// The following code example determines the indexes of the first and last occurrences of a character or a substring within a portion of a string.
// Note that IndexOf and LastIndexOf are searching in different portions of the string, even with the same StartIndex parameter.
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
   
   // iS is the starting index of the substring.
   int iS = 20;
   
   // myT1 is the string used for padding.
   String^ myT1;
   
   // Searches for the ligature Æ.
   String^ myStr = "Is AE or ae the same as Æ or æ?";
   Console::WriteLine();
   myT1 = gcnew String( '-',iS );
   Console::WriteLine( "IndexOf( String, *, {0}, * )", iS );
   Console::WriteLine( "Original      : {0}", myStr );
   Console::WriteLine( "No options    : {0}{1}", myT1, myStr->Substring( iS ) );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", iS ), -1 );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", iS ), -1 );
   PrintMarker( "            Æ : ", myComp->IndexOf( myStr, L'Æ', iS ), -1 );
   PrintMarker( "            æ : ", myComp->IndexOf( myStr, L'æ', iS ), -1 );
   Console::WriteLine( "Ordinal       : {0}{1}", myT1, myStr->Substring( iS ) );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", iS, CompareOptions::Ordinal ), -1 );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", iS, CompareOptions::Ordinal ), -1 );
   PrintMarker( "            Æ : ", myComp->IndexOf( myStr, L'Æ', iS, CompareOptions::Ordinal ), -1 );
   PrintMarker( "            æ : ", myComp->IndexOf( myStr, L'æ', iS, CompareOptions::Ordinal ), -1 );
   Console::WriteLine( "IgnoreCase    : {0}{1}", myT1, myStr->Substring( iS ) );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", iS, CompareOptions::IgnoreCase ), -1 );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", iS, CompareOptions::IgnoreCase ), -1 );
   PrintMarker( "            Æ : ", myComp->IndexOf( myStr, L'Æ', iS, CompareOptions::IgnoreCase ), -1 );
   PrintMarker( "            æ : ", myComp->IndexOf( myStr, L'æ', iS, CompareOptions::IgnoreCase ), -1 );
   myT1 = gcnew String( '-',myStr->Length - iS - 1 );
   Console::WriteLine( "LastIndexOf( String, *, {0}, * )", iS );
   Console::WriteLine( "Original      : {0}", myStr );
   Console::WriteLine( "No options    : {0}{1}", myStr->Substring( 0, iS + 1 ), myT1 );
   PrintMarker( "           AE : ", -1, myComp->LastIndexOf( myStr, "AE", iS ) );
   PrintMarker( "           ae : ", -1, myComp->LastIndexOf( myStr, "ae", iS ) );
   PrintMarker( "            Æ : ", -1, myComp->LastIndexOf( myStr, L'Æ', iS ) );
   PrintMarker( "            æ : ", -1, myComp->LastIndexOf( myStr, L'æ', iS ) );
   Console::WriteLine( "Ordinal       : {0}{1}", myStr->Substring( 0, iS + 1 ), myT1 );
   PrintMarker( "           AE : ", -1, myComp->LastIndexOf( myStr, "AE", iS, CompareOptions::Ordinal ) );
   PrintMarker( "           ae : ", -1, myComp->LastIndexOf( myStr, "ae", iS, CompareOptions::Ordinal ) );
   PrintMarker( "            Æ : ", -1, myComp->LastIndexOf( myStr, L'Æ', iS, CompareOptions::Ordinal ) );
   PrintMarker( "            æ : ", -1, myComp->LastIndexOf( myStr, L'æ', iS, CompareOptions::Ordinal ) );
   Console::WriteLine( "IgnoreCase    : {0}{1}", myStr->Substring( 0, iS + 1 ), myT1 );
   PrintMarker( "           AE : ", -1, myComp->LastIndexOf( myStr, "AE", iS, CompareOptions::IgnoreCase ) );
   PrintMarker( "           ae : ", -1, myComp->LastIndexOf( myStr, "ae", iS, CompareOptions::IgnoreCase ) );
   PrintMarker( "            Æ : ", -1, myComp->LastIndexOf( myStr, L'Æ', iS, CompareOptions::IgnoreCase ) );
   PrintMarker( "            æ : ", -1, myComp->LastIndexOf( myStr, L'æ', iS, CompareOptions::IgnoreCase ) );
   
   // Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
   myStr = "Is U\u0308 or u\u0308 the same as \u00DC or \u00FC?";
   Console::WriteLine();
   myT1 = gcnew String( '-',iS );
   Console::WriteLine( "IndexOf( String, *, {0}, * )", iS );
   Console::WriteLine( "Original      : {0}", myStr );
   Console::WriteLine( "No options    : {0}{1}", myT1, myStr->Substring( iS ) );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", iS ), -1 );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", iS ), -1 );
   PrintMarker( "            Ü : ", myComp->IndexOf( myStr, L'Ü', iS ), -1 );
   PrintMarker( "            ü : ", myComp->IndexOf( myStr, L'ü', iS ), -1 );
   Console::WriteLine( "Ordinal       : {0}{1}", myT1, myStr->Substring( iS ) );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", iS, CompareOptions::Ordinal ), -1 );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", iS, CompareOptions::Ordinal ), -1 );
   PrintMarker( "            Ü : ", myComp->IndexOf( myStr, L'Ü', iS, CompareOptions::Ordinal ), -1 );
   PrintMarker( "            ü : ", myComp->IndexOf( myStr, L'ü', iS, CompareOptions::Ordinal ), -1 );
   Console::WriteLine( "IgnoreCase    : {0}{1}", myT1, myStr->Substring( iS ) );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", iS, CompareOptions::IgnoreCase ), -1 );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", iS, CompareOptions::IgnoreCase ), -1 );
   PrintMarker( "            Ü : ", myComp->IndexOf( myStr, L'Ü', iS, CompareOptions::IgnoreCase ), -1 );
   PrintMarker( "            ü : ", myComp->IndexOf( myStr, L'ü', iS, CompareOptions::IgnoreCase ), -1 );
   myT1 = gcnew String( '-',myStr->Length - iS - 1 );
   Console::WriteLine( "LastIndexOf( String, *, {0}, * )", iS );
   Console::WriteLine( "Original      : {0}", myStr );
   Console::WriteLine( "No options    : {0}{1}", myStr->Substring( 0, iS + 1 ), myT1 );
   PrintMarker( "           U\u0308 : ", -1, myComp->LastIndexOf( myStr, "U\u0308", iS ) );
   PrintMarker( "           u\u0308 : ", -1, myComp->LastIndexOf( myStr, "u\u0308", iS ) );
   PrintMarker( "            Ü : ", -1, myComp->LastIndexOf( myStr, L'Ü', iS ) );
   PrintMarker( "            ü : ", -1, myComp->LastIndexOf( myStr, L'ü', iS ) );
   Console::WriteLine( "Ordinal       : {0}{1}", myStr->Substring( 0, iS + 1 ), myT1 );
   PrintMarker( "           U\u0308 : ", -1, myComp->LastIndexOf( myStr, "U\u0308", iS, CompareOptions::Ordinal ) );
   PrintMarker( "           u\u0308 : ", -1, myComp->LastIndexOf( myStr, "u\u0308", iS, CompareOptions::Ordinal ) );
   PrintMarker( "            Ü : ", -1, myComp->LastIndexOf( myStr, L'Ü', iS, CompareOptions::Ordinal ) );
   PrintMarker( "            ü : ", -1, myComp->LastIndexOf( myStr, L'ü', iS, CompareOptions::Ordinal ) );
   Console::WriteLine( "IgnoreCase    : {0}{1}", myStr->Substring( 0, iS + 1 ), myT1 );
   PrintMarker( "           U\u0308 : ", -1, myComp->LastIndexOf( myStr, "U\u0308", iS, CompareOptions::IgnoreCase ) );
   PrintMarker( "           u\u0308 : ", -1, myComp->LastIndexOf( myStr, "u\u0308", iS, CompareOptions::IgnoreCase ) );
   PrintMarker( "            Ü : ", -1, myComp->LastIndexOf( myStr, L'Ü', iS, CompareOptions::IgnoreCase ) );
   PrintMarker( "            ü : ", -1, myComp->LastIndexOf( myStr, L'ü', iS, CompareOptions::IgnoreCase ) );
}

/*
This code produces the following output.

IndexOf( String, *, 20, * )
Original      : Is AE or ae the same as Æ or æ?
No options    : -------------------- as Æ or æ?
           AE :                         f
           ae :                              f
            Æ :                         f
            æ :                              f
Ordinal       : -------------------- as Æ or æ?
           AE :
           ae :
            Æ :                         f
            æ :                              f
IgnoreCase    : -------------------- as Æ or æ?
           AE :                         f
           ae :                         f
            Æ :                         f
            æ :                         f
LastIndexOf( String, *, 20, * )
Original      : Is AE or ae the same as Æ or æ?
No options    : Is AE or ae the same ----------
           AE :    l
           ae :          l
            Æ :    l
            æ :          l
Ordinal       : Is AE or ae the same ----------
           AE :    l
           ae :          l
            Æ :
            æ :
IgnoreCase    : Is AE or ae the same ----------
           AE :          l
           ae :          l
            Æ :          l
            æ :          l

IndexOf( String, *, 20, * )
Original      : Is U" or u" the same as Ü or ü?
No options    : -------------------- as Ü or ü?
           U" :                         f
           u" :                              f
            Ü :                         f
            ü :                              f
Ordinal       : -------------------- as Ü or ü?
           U" :
           u" :
            Ü :                         f
            ü :                              f
IgnoreCase    : -------------------- as Ü or ü?
           U" :                         f
           u" :                         f
            Ü :                         f
            ü :                         f
LastIndexOf( String, *, 20, * )
Original      : Is U" or u" the same as Ü or ü?
No options    : Is U" or u" the same ----------
           U" :    l
           u" :          l
            Ü :    l
            ü :          l
Ordinal       : Is U" or u" the same ----------
           U" :    l
           u" :          l
            Ü :
            ü :
IgnoreCase    : Is U" or u" the same ----------
           U" :          l
           u" :          l
            Ü :          l
            ü :          l

*/
// </snippet1>
