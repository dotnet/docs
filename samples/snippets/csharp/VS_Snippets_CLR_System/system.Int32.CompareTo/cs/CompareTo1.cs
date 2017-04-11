// <Snippet1>
using System;

enum Comparison {
   LessThan=-1, Equal=0, GreaterThan=1};

public class ValueComparison
{
   public static void Main()
   {
      int mainValue = 16325;
      int zeroValue = 0;
      int negativeValue = -1934;
      int positiveValue = 903624;
      int sameValue = 16325;
         
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).",  
                        mainValue, zeroValue, 
                        mainValue.CompareTo(zeroValue), 
                        (Comparison) mainValue.CompareTo(zeroValue));
                        
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).",
                        mainValue, sameValue, 
                        mainValue.CompareTo(sameValue), 
                        (Comparison) mainValue.CompareTo(sameValue));
                        
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).", 
                        mainValue, negativeValue, 
                        mainValue.CompareTo(negativeValue), 
                        (Comparison) mainValue.CompareTo(negativeValue));
                        
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).", 
                        mainValue, positiveValue, 
                        mainValue.CompareTo(positiveValue), 
                        (Comparison) mainValue.CompareTo(positiveValue));
   }
}
// The example displays the following output:
//       Comparing 16325 and 0: 1 (GreaterThan).
//       Comparing 16325 and 16325: 0 (Equal).
//       Comparing 16325 and -1934: 1 (GreaterThan).
//       Comparing 16325 and 903624: -1 (LessThan).
// </Snippet1>
