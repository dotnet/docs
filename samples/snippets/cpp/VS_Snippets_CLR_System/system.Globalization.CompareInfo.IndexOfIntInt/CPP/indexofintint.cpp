
// The following code example determines the indexes of the first and last occurrences of a character or a substring within a portion of a string.
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
   int iS = 8;
   
   // iL is the length of the substring.
   int iL = 18;
   
   // myT1 and myT2 are the strings used for padding.
   String^ myT1 = gcnew String( '-',iS );
   String^ myT2;
   
   // Searches for the ligature Ã†.
   String^ myStr = "Is AE or ae the same as Ã† or Ã¦?";
   myT2 = gcnew String( '-',myStr->Length - iS - iL );
   Console::WriteLine();
   Console::WriteLine( "Original      : {0}", myStr );
   Console::WriteLine( "No options    : {0}{1}{2}", myT1, myStr->Substring( iS, iL ), myT2 );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", iS, iL ), myComp->LastIndexOf( myStr, "AE", iS + iL - 1, iL ) );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", iS, iL ), myComp->LastIndexOf( myStr, "ae", iS + iL - 1, iL ) );
   PrintMarker( "            Ã† : ", myComp->IndexOf( myStr, L'Ã†', iS, iL ), myComp->LastIndexOf( myStr, L'Ã†', iS + iL - 1, iL ) );
   PrintMarker( "            Ã¦ : ", myComp->IndexOf( myStr, L'Ã¦', iS, iL ), myComp->LastIndexOf( myStr, L'Ã¦', iS + iL - 1, iL ) );
   Console::WriteLine( "Ordinal       : {0}{1}{2}", myT1, myStr->Substring( iS, iL ), myT2 );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "AE", iS + iL - 1, iL, CompareOptions::Ordinal ) );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "ae", iS + iL - 1, iL, CompareOptions::Ordinal ) );
   PrintMarker( "            Ã† : ", myComp->IndexOf( myStr, L'Ã†', iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'Ã†', iS + iL - 1, iL, CompareOptions::Ordinal ) );
   PrintMarker( "            Ã¦ : ", myComp->IndexOf( myStr, L'Ã¦', iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'Ã¦', iS + iL - 1, iL, CompareOptions::Ordinal ) );
   Console::WriteLine( "IgnoreCase    : {0}{1}{2}", myT1, myStr->Substring( iS, iL ), myT2 );
   PrintMarker( "           AE : ", myComp->IndexOf( myStr, "AE", iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "AE", iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   PrintMarker( "           ae : ", myComp->IndexOf( myStr, "ae", iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "ae", iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   PrintMarker( "            Ã† : ", myComp->IndexOf( myStr, L'Ã†', iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'Ã†', iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   PrintMarker( "            Ã¦ : ", myComp->IndexOf( myStr, L'Ã¦', iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'Ã¦', iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   
   // Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
   myStr = "Is U\u0308 or u\u0308 the same as \u00DC or \u00FC?";
   myT2 = gcnew String( '-',myStr->Length - iS - iL );
   Console::WriteLine();
   Console::WriteLine( "Original      : {0}", myStr );
   Console::WriteLine( "No options    : {0}{1}{2}", myT1, myStr->Substring( iS, iL ), myT2 );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", iS, iL ), myComp->LastIndexOf( myStr, "U\u0308", iS + iL - 1, iL ) );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", iS, iL ), myComp->LastIndexOf( myStr, "u\u0308", iS + iL - 1, iL ) );
   PrintMarker( "            Ãœ : ", myComp->IndexOf( myStr, L'Ãœ', iS, iL ), myComp->LastIndexOf( myStr, L'Ãœ', iS + iL - 1, iL ) );
   PrintMarker( "            Ã¼ : ", myComp->IndexOf( myStr, L'Ã¼', iS, iL ), myComp->LastIndexOf( myStr, L'Ã¼', iS + iL - 1, iL ) );
   Console::WriteLine( "Ordinal       : {0}{1}{2}", myT1, myStr->Substring( iS, iL ), myT2 );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "U\u0308", iS + iL - 1, iL, CompareOptions::Ordinal ) );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, "u\u0308", iS + iL - 1, iL, CompareOptions::Ordinal ) );
   PrintMarker( "            Ãœ : ", myComp->IndexOf( myStr, L'Ãœ', iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'Ãœ', iS + iL - 1, iL, CompareOptions::Ordinal ) );
   PrintMarker( "            Ã¼ : ", myComp->IndexOf( myStr, L'Ã¼', iS, iL, CompareOptions::Ordinal ), myComp->LastIndexOf( myStr, L'Ã¼', iS + iL - 1, iL, CompareOptions::Ordinal ) );
   Console::WriteLine( "IgnoreCase    : {0}{1}{2}", myT1, myStr->Substring( iS, iL ), myT2 );
   PrintMarker( "           U\u0308 : ", myComp->IndexOf( myStr, "U\u0308", iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "U\u0308", iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   PrintMarker( "           u\u0308 : ", myComp->IndexOf( myStr, "u\u0308", iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, "u\u0308", iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   PrintMarker( "            Ãœ : ", myComp->IndexOf( myStr, L'Ãœ', iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'Ãœ', iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
   PrintMarker( "            Ã¼ : ", myComp->IndexOf( myStr, L'Ã¼', iS, iL, CompareOptions::IgnoreCase ), myComp->LastIndexOf( myStr, L'Ã¼', iS + iL - 1, iL, CompareOptions::IgnoreCase ) );
}

/*
This code produces the following output.

Original      : Is AE or ae the same as Ã† or Ã¦?
No options    : -------- ae the same as Ã† -----
           AE :                         b
           ae :          b
            Ã† :                         b
            Ã¦ :          b
Ordinal       : -------- ae the same as Ã† -----
           AE :
           ae :          b
            Ã† :                         b
            Ã¦ :
IgnoreCase    : -------- ae the same as Ã† -----
           AE :          f              l
           ae :          f              l
            Ã† :          f              l
            Ã¦ :          f              l

Original      : Is U" or u" the same as Ãœ or Ã¼?
No options    : -------- u" the same as Ãœ -----
           U" :                         b
           u" :          b
            Ãœ :                         b
            Ã¼ :          b
Ordinal       : -------- u" the same as Ãœ -----
           U" :
           u" :          b
            Ãœ :                         b
            Ã¼ :
IgnoreCase    : -------- u" the same as Ãœ -----
           U" :          f              l
           u" :          f              l
            Ãœ :          f              l
            Ã¼ :          f              l

*/
// </snippet1>
