// <Snippet5>
using System;

public enum Continent
{
   Africa, Antarctica, Asia, Australia, Europe, 
   NorthAmerica, SouthAmerica
};

public class Example
{
   public static void Main()
   {
      // Convert a Continent to a Double.
      Continent cont = Continent.NorthAmerica;
      Console.WriteLine("{0:N2}", 
                        Convert.ChangeType(cont, typeof(Double)));
   
      // Convert a Double to a Continent.
      Double number = 6.0;
      try {
         Console.WriteLine("{0}", 
                           Convert.ChangeType(number, typeof(Continent)));
      }
      catch (InvalidCastException) {
         Console.WriteLine("Cannot convert a Double to a Continent");
      }
      
      Console.WriteLine("{0}", (Continent) number);   
   }
}
// The example displays the following output:
//       5.00
//       Cannot convert a Double to a Continent
//       SouthAmerica
// </Snippet5>
