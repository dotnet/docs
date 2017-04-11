// The following code example compares SortKey objects created with cultures that have different sort orders.


// <snippet1>
using System;
using System.Globalization;

public class SamplesSortKey  {

   public static void Main()  {

      // Creates a SortKey using the en-US culture.
      CompareInfo myComp_enUS = new CultureInfo("en-US",false).CompareInfo;
      SortKey mySK1 = myComp_enUS.GetSortKey( "llama" );

      // Creates a SortKey using the es-ES culture with international sort.
      CompareInfo myComp_esES = new CultureInfo("es-ES",false).CompareInfo;
      SortKey mySK2 = myComp_esES.GetSortKey( "llama" );

      // Creates a SortKey using the es-ES culture with traditional sort.
      CompareInfo myComp_es   = new CultureInfo(0x040A,false).CompareInfo;
      SortKey mySK3 = myComp_es.GetSortKey( "llama" );

      // Compares the en-US SortKey with each of the es-ES SortKey objects.
      Console.WriteLine( "Comparing \"llama\" in en-US and in es-ES with international sort : {0}", SortKey.Compare( mySK1, mySK2 ) );
      Console.WriteLine( "Comparing \"llama\" in en-US and in es-ES with traditional sort   : {0}", SortKey.Compare( mySK1, mySK3 ) );

   }

}

/*
This code produces the following output.

Comparing "llama" in en-US and in es-ES with international sort : 0
Comparing "llama" in en-US and in es-ES with traditional sort   : -1
*/

// </snippet1>
