// The following code example determines the indexes of the first and last occurrences of a character or a substring within a portion of a string.

// <snippet1>
using System;
using System.Globalization;

public class SamplesCompareInfo  {

   public static void Main()  {

      // Creates CompareInfo for the InvariantCulture.
      CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo;

      // iS is the starting index of the substring.
      int iS = 8;
      // iL is the length of the substring.
      int iL = 18;
      // myT1 and myT2 are the strings used for padding.
      String myT1 = new String( '-', iS );
      String myT2;

      // Searches for the ligature Æ.
      String myStr = "Is AE or ae the same as Æ or æ?";
      myT2 = new String( '-', myStr.Length - iS - iL );
      Console.WriteLine();
      Console.WriteLine( "Original      : {0}", myStr );
      Console.WriteLine( "No options    : {0}{1}{2}", myT1, myStr.Substring( iS, iL ), myT2 );
      PrintMarker( "           AE : ", myComp.IndexOf( myStr, "AE", iS, iL ), myComp.LastIndexOf( myStr, "AE", iS + iL - 1, iL ) );
      PrintMarker( "           ae : ", myComp.IndexOf( myStr, "ae", iS, iL ), myComp.LastIndexOf( myStr, "ae", iS + iL - 1, iL ) );
      PrintMarker( "            Æ : ", myComp.IndexOf( myStr, 'Æ', iS, iL ), myComp.LastIndexOf( myStr, 'Æ', iS + iL - 1, iL ) );
      PrintMarker( "            æ : ", myComp.IndexOf( myStr, 'æ', iS, iL ), myComp.LastIndexOf( myStr, 'æ', iS + iL - 1, iL ) );
      Console.WriteLine( "Ordinal       : {0}{1}{2}", myT1, myStr.Substring( iS, iL ), myT2 );
      PrintMarker( "           AE : ", myComp.IndexOf( myStr, "AE", iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "AE", iS + iL - 1, iL, CompareOptions.Ordinal ) );
      PrintMarker( "           ae : ", myComp.IndexOf( myStr, "ae", iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "ae", iS + iL - 1, iL, CompareOptions.Ordinal ) );
      PrintMarker( "            Æ : ", myComp.IndexOf( myStr, 'Æ', iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'Æ', iS + iL - 1, iL, CompareOptions.Ordinal ) );
      PrintMarker( "            æ : ", myComp.IndexOf( myStr, 'æ', iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'æ', iS + iL - 1, iL, CompareOptions.Ordinal ) );
      Console.WriteLine( "IgnoreCase    : {0}{1}{2}", myT1, myStr.Substring( iS, iL ), myT2 );
      PrintMarker( "           AE : ", myComp.IndexOf( myStr, "AE", iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "AE", iS + iL - 1, iL, CompareOptions.IgnoreCase ) );
      PrintMarker( "           ae : ", myComp.IndexOf( myStr, "ae", iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "ae", iS + iL - 1, iL, CompareOptions.IgnoreCase ) );
      PrintMarker( "            Æ : ", myComp.IndexOf( myStr, 'Æ', iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'Æ', iS + iL - 1, iL, CompareOptions.IgnoreCase ) );
      PrintMarker( "            æ : ", myComp.IndexOf( myStr, 'æ', iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'æ', iS + iL - 1, iL, CompareOptions.IgnoreCase ) );

      // Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
      myStr = "Is \u0055\u0308 or \u0075\u0308 the same as \u00DC or \u00FC?";
      myT2 = new String( '-', myStr.Length - iS - iL );
      Console.WriteLine();
      Console.WriteLine( "Original      : {0}", myStr );
      Console.WriteLine( "No options    : {0}{1}{2}", myT1, myStr.Substring( iS, iL ), myT2 );
      PrintMarker( "           U\u0308 : ", myComp.IndexOf( myStr, "U\u0308", iS, iL ), myComp.LastIndexOf( myStr, "U\u0308", iS + iL - 1, iL ) );
      PrintMarker( "           u\u0308 : ", myComp.IndexOf( myStr, "u\u0308", iS, iL ), myComp.LastIndexOf( myStr, "u\u0308", iS + iL - 1, iL ) );
      PrintMarker( "            Ü : ", myComp.IndexOf( myStr, 'Ü', iS, iL ), myComp.LastIndexOf( myStr, 'Ü', iS + iL - 1, iL ) );
      PrintMarker( "            ü : ", myComp.IndexOf( myStr, 'ü', iS, iL ), myComp.LastIndexOf( myStr, 'ü', iS + iL - 1, iL ) );
      Console.WriteLine( "Ordinal       : {0}{1}{2}", myT1, myStr.Substring( iS, iL ), myT2 );
      PrintMarker( "           U\u0308 : ", myComp.IndexOf( myStr, "U\u0308", iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "U\u0308", iS + iL - 1, iL, CompareOptions.Ordinal ) );
      PrintMarker( "           u\u0308 : ", myComp.IndexOf( myStr, "u\u0308", iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "u\u0308", iS + iL - 1, iL, CompareOptions.Ordinal ) );
      PrintMarker( "            Ü : ", myComp.IndexOf( myStr, 'Ü', iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'Ü', iS + iL - 1, iL, CompareOptions.Ordinal ) );
      PrintMarker( "            ü : ", myComp.IndexOf( myStr, 'ü', iS, iL, CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'ü', iS + iL - 1, iL, CompareOptions.Ordinal ) );
      Console.WriteLine( "IgnoreCase    : {0}{1}{2}", myT1, myStr.Substring( iS, iL ), myT2 );
      PrintMarker( "           U\u0308 : ", myComp.IndexOf( myStr, "U\u0308", iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "U\u0308", iS + iL - 1, iL, CompareOptions.IgnoreCase ) );
      PrintMarker( "           u\u0308 : ", myComp.IndexOf( myStr, "u\u0308", iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "u\u0308", iS + iL - 1, iL, CompareOptions.IgnoreCase ) );
      PrintMarker( "            Ü : ", myComp.IndexOf( myStr, 'Ü', iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'Ü', iS + iL - 1, iL, CompareOptions.IgnoreCase ) );
      PrintMarker( "            ü : ", myComp.IndexOf( myStr, 'ü', iS, iL, CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'ü', iS + iL - 1, iL, CompareOptions.IgnoreCase ) );

   }

   public static void PrintMarker( String Prefix, int First, int Last )  {

      // Determines the size of the array to create.
      int mySize;
      if ( Last > First )
         mySize = Last;
      else
         mySize = First;

      if ( mySize > -1 )  {

         // Creates an array of Char to hold the markers.
         Char[] myCharArr = new Char[mySize+1];

         // Inserts the appropriate markers.
         if ( First > -1 )
         myCharArr[First] = 'f';
         if ( Last > -1 )
            myCharArr[Last] = 'l';
         if ( First == Last )
         myCharArr[First] = 'b';

         // Displays the array of Char as a String.
         Console.WriteLine( "{0}{1}", Prefix, new String( myCharArr ) );

      }
      else
         Console.WriteLine( Prefix );

   }

}


/*
This code produces the following output.

Original      : Is AE or ae the same as Æ or æ?
No options    : -------- ae the same as Æ -----
           AE :                         b
           ae :          b
            Æ :                         b
            æ :          b
Ordinal       : -------- ae the same as Æ -----
           AE :
           ae :          b
            Æ :                         b
            æ :
IgnoreCase    : -------- ae the same as Æ -----
           AE :          f              l
           ae :          f              l
            Æ :          f              l
            æ :          f              l

Original      : Is U" or u" the same as Ü or ü?
No options    : -------- u" the same as Ü -----
           U" :                         b
           u" :          b
            Ü :                         b
            ü :          b
Ordinal       : -------- u" the same as Ü -----
           U" :
           u" :          b
            Ü :                         b
            ü :
IgnoreCase    : -------- u" the same as Ü -----
           U" :          f              l
           u" :          f              l
            Ü :          f              l
            ü :          f              l

*/
// </snippet1>
