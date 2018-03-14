// <Snippet4>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      String[] cultureNames = { "en-US", "se-SE" };
      String[] strings1 = { "case",  "encyclopædia",  
                            "encyclopædia", "Archæology" };
      String[] strings2 = { "Case", "encyclopaedia", 
                            "encyclopedia" , "ARCHÆOLOGY" };
      StringComparison[] comparisons = (StringComparison[]) Enum.GetValues(typeof(StringComparison));
      
      foreach (var cultureName in cultureNames) {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
         Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);
         for (int ctr = 0; ctr <= strings1.GetUpperBound(0); ctr++) {
            foreach (var comparison in comparisons) 
               Console.WriteLine("   {0} = {1} ({2}): {3}", strings1[ctr],
                                 strings2[ctr], comparison, 
                                 strings1[ctr].Equals(strings2[ctr], comparison));

            Console.WriteLine();         
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    Current Culture: en-US
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
//    
//       encyclopædia = encyclopaedia (CurrentCulture): True
//       encyclopædia = encyclopaedia (CurrentCultureIgnoreCase): True
//       encyclopædia = encyclopaedia (InvariantCulture): True
//       encyclopædia = encyclopaedia (InvariantCultureIgnoreCase): True
//       encyclopædia = encyclopaedia (Ordinal): False
//       encyclopædia = encyclopaedia (OrdinalIgnoreCase): False
//    
//       encyclopædia = encyclopedia (CurrentCulture): False
//       encyclopædia = encyclopedia (CurrentCultureIgnoreCase): False
//       encyclopædia = encyclopedia (InvariantCulture): False
//       encyclopædia = encyclopedia (InvariantCultureIgnoreCase): False
//       encyclopædia = encyclopedia (Ordinal): False
//       encyclopædia = encyclopedia (OrdinalIgnoreCase): False
//    
//       Archæology = ARCHÆOLOGY (CurrentCulture): False
//       Archæology = ARCHÆOLOGY (CurrentCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (InvariantCulture): False
//       Archæology = ARCHÆOLOGY (InvariantCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (Ordinal): False
//       Archæology = ARCHÆOLOGY (OrdinalIgnoreCase): True
//    
//    
//    Current Culture: se-SE
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
//    
//       encyclopædia = encyclopaedia (CurrentCulture): False
//       encyclopædia = encyclopaedia (CurrentCultureIgnoreCase): False
//       encyclopædia = encyclopaedia (InvariantCulture): True
//       encyclopædia = encyclopaedia (InvariantCultureIgnoreCase): True
//       encyclopædia = encyclopaedia (Ordinal): False
//       encyclopædia = encyclopaedia (OrdinalIgnoreCase): False
//    
//       encyclopædia = encyclopedia (CurrentCulture): False
//       encyclopædia = encyclopedia (CurrentCultureIgnoreCase): False
//       encyclopædia = encyclopedia (InvariantCulture): False
//       encyclopædia = encyclopedia (InvariantCultureIgnoreCase): False
//       encyclopædia = encyclopedia (Ordinal): False
//       encyclopædia = encyclopedia (OrdinalIgnoreCase): False
//    
//       Archæology = ARCHÆOLOGY (CurrentCulture): False
//       Archæology = ARCHÆOLOGY (CurrentCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (InvariantCulture): False
//       Archæology = ARCHÆOLOGY (InvariantCultureIgnoreCase): True
//       Archæology = ARCHÆOLOGY (Ordinal): False
//       Archæology = ARCHÆOLOGY (OrdinalIgnoreCase): True
// </Snippet4>
