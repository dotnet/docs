// The following code example shows how sorting with CompareOptions.StringSort differs from sorting without CompareOptions.StringSort.

// <snippet1>
using System;
using System.Collections;
using System.Globalization;


public class SamplesCompareOptions  {

   private class MyStringComparer: IComparer {
      private CompareInfo myComp;   
      private CompareOptions myOptions = CompareOptions.None;

      // Constructs a comparer using the specified CompareOptions.
      public MyStringComparer( CompareInfo cmpi, CompareOptions options )  {
         myComp = cmpi;
         this.myOptions = options;
      }

      // Compares strings with the CompareOptions specified in the constructor.
      public int Compare(Object a, Object b) {
         if (a == b) return 0;
         if (a == null) return -1;
         if (b == null) return 1;

         String sa = a as String;
         String sb = b as String;
         if (sa != null && sb != null)
            return myComp.Compare(sa, sb, myOptions);
         throw new ArgumentException("a and b should be strings.");

      }
   }
   
   public static void Main()  {

      // Creates and initializes an array of strings to sort.
      String[] myArr = new String[9] { "cant", "bill's", "coop", "cannot", "billet", "can't", "con", "bills", "co-op" };
      Console.WriteLine( "\nInitially," );
      foreach ( String myStr in myArr )
         Console.WriteLine( myStr );

      // Creates and initializes a Comparer to use.
      //CultureInfo myCI = new CultureInfo( "en-US", false );
      MyStringComparer myComp = new MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.None);

      // Sorts the array without StringSort.
      Array.Sort( myArr, myComp );
      Console.WriteLine( "\nAfter sorting without CompareOptions.StringSort:" );
      foreach ( String myStr in myArr )
         Console.WriteLine( myStr );

      // Sorts the array with StringSort.
      myComp = new MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.StringSort);
      Array.Sort( myArr, myComp );
      Console.WriteLine( "\nAfter sorting with CompareOptions.StringSort:" );
      foreach ( String myStr in myArr )
         Console.WriteLine( myStr );

   }

}

/*
This code produces the following output.

Initially,
cant
bill's
coop
cannot
billet
can't
con
bills
co-op

After sorting without CompareOptions.StringSort:
billet
bills
bill's
cannot
cant
can't
con
coop
co-op

After sorting with CompareOptions.StringSort:
bill's
billet
bills
can't
cannot
cant
co-op
con
coop

*/
// </snippet1>
