// The following code example determines the indexes of the first and last occurrences of a character or a substring within a string.

// <snippet1>
using System;
using System.Globalization;

public class SamplesCompareInfo  {

   public static void Main()  {

      // Creates CompareInfo for the InvariantCulture.
      CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo;

      // Searches for the ligature Æ.
      String myStr = "Is AE or ae the same as Æ or æ?";
      Console.WriteLine();
      Console.WriteLine( "No options    : {0}", myStr );
      PrintMarker( "           AE : ", myComp.IndexOf( myStr, "AE" ), myComp.LastIndexOf( myStr, "AE" ) );
      PrintMarker( "           ae : ", myComp.IndexOf( myStr, "ae" ), myComp.LastIndexOf( myStr, "ae" ) );
      PrintMarker( "            Æ : ", myComp.IndexOf( myStr, 'Æ' ), myComp.LastIndexOf( myStr, 'Æ' ) );
      PrintMarker( "            æ : ", myComp.IndexOf( myStr, 'æ' ), myComp.LastIndexOf( myStr, 'æ' ) );
      Console.WriteLine( "Ordinal       : {0}", myStr );
      PrintMarker( "           AE : ", myComp.IndexOf( myStr, "AE", CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "AE", CompareOptions.Ordinal ) );
      PrintMarker( "           ae : ", myComp.IndexOf( myStr, "ae", CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "ae", CompareOptions.Ordinal ) );
      PrintMarker( "            Æ : ", myComp.IndexOf( myStr, 'Æ', CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'Æ', CompareOptions.Ordinal ) );
      PrintMarker( "            æ : ", myComp.IndexOf( myStr, 'æ', CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'æ', CompareOptions.Ordinal ) );
      Console.WriteLine( "IgnoreCase    : {0}", myStr );
      PrintMarker( "           AE : ", myComp.IndexOf( myStr, "AE", CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "AE", CompareOptions.IgnoreCase ) );
      PrintMarker( "           ae : ", myComp.IndexOf( myStr, "ae", CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "ae", CompareOptions.IgnoreCase ) );
      PrintMarker( "            Æ : ", myComp.IndexOf( myStr, 'Æ', CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'Æ', CompareOptions.IgnoreCase ) );
      PrintMarker( "            æ : ", myComp.IndexOf( myStr, 'æ', CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'æ', CompareOptions.IgnoreCase ) );

      // Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
      myStr = "Is \u0055\u0308 or \u0075\u0308 the same as \u00DC or \u00FC?";
      Console.WriteLine();
      Console.WriteLine( "No options    : {0}", myStr );
      PrintMarker( "           U\u0308 : ", myComp.IndexOf( myStr, "U\u0308" ), myComp.LastIndexOf( myStr, "U\u0308" ) );
      PrintMarker( "           u\u0308 : ", myComp.IndexOf( myStr, "u\u0308" ), myComp.LastIndexOf( myStr, "u\u0308" ) );
      PrintMarker( "            Ü : ", myComp.IndexOf( myStr, 'Ü' ), myComp.LastIndexOf( myStr, 'Ü' ) );
      PrintMarker( "            ü : ", myComp.IndexOf( myStr, 'ü' ), myComp.LastIndexOf( myStr, 'ü' ) );
      Console.WriteLine( "Ordinal       : {0}", myStr );
      PrintMarker( "           U\u0308 : ", myComp.IndexOf( myStr, "U\u0308", CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "U\u0308", CompareOptions.Ordinal ) );
      PrintMarker( "           u\u0308 : ", myComp.IndexOf( myStr, "u\u0308", CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, "u\u0308", CompareOptions.Ordinal ) );
      PrintMarker( "            Ü : ", myComp.IndexOf( myStr, 'Ü', CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'Ü', CompareOptions.Ordinal ) );
      PrintMarker( "            ü : ", myComp.IndexOf( myStr, 'ü', CompareOptions.Ordinal ), myComp.LastIndexOf( myStr, 'ü', CompareOptions.Ordinal ) );
      Console.WriteLine( "IgnoreCase    : {0}", myStr );
      PrintMarker( "           U\u0308 : ", myComp.IndexOf( myStr, "U\u0308", CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "U\u0308", CompareOptions.IgnoreCase ) );
      PrintMarker( "           u\u0308 : ", myComp.IndexOf( myStr, "u\u0308", CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, "u\u0308", CompareOptions.IgnoreCase ) );
      PrintMarker( "            Ü : ", myComp.IndexOf( myStr, 'Ü', CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'Ü', CompareOptions.IgnoreCase ) );
      PrintMarker( "            ü : ", myComp.IndexOf( myStr, 'ü', CompareOptions.IgnoreCase ), myComp.LastIndexOf( myStr, 'ü', CompareOptions.IgnoreCase ) );

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
