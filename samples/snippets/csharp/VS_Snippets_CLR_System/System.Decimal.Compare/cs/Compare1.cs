// <Snippet1>
using System;

public enum Relationship
{  LessThan = -1, Equals = 0, GreaterThan = 1 }

public class Example
{
   public static void Main()
   {
      decimal value1 = Decimal.MaxValue;
      decimal value2 = value1 - .01m;
      Console.WriteLine("{0} {2} {1}", value1, value2, 
                        (Relationship) Decimal.Compare(value1, value2));   
   
      value2 = value1 / 12m - .1m;
      value1 = value1 / 12m;
      Console.WriteLine("{0} {2} {1}", value1, value2, 
                        (Relationship) Decimal.Compare(value1, value2));   
   
      value1 = value1 - .2m;
      value2 = value2 + .1m;
      Console.WriteLine("{0} {2} {1}", value1, value2, 
                        (Relationship) Decimal.Compare(value1, value2));   
   }
}
// The example displays the following output:
//     79228162514264337593543950335 Equals 79228162514264337593543950335
//     6602346876188694799461995861.2 GreaterThan 6602346876188694799461995861.1
//     6602346876188694799461995861.0 LessThan 6602346876188694799461995861.2
// </Snippet1>

