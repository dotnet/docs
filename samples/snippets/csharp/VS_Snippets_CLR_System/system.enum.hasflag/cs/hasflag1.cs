// <Snippet2>
using System;

[Flags] public enum DinnerItems {
   None = 0,
   Entree = 1,
   Appetizer = 2,
   Side = 4,
   Dessert = 8,
   Beverage = 16, 
   BarBeverage = 32
}

public class Example
{
   public static void Main()
   {
      DinnerItems myOrder = DinnerItems.Appetizer | DinnerItems.Entree |
                            DinnerItems.Beverage | DinnerItems.Dessert;
      DinnerItems flagValue = DinnerItems.Entree | DinnerItems.Beverage;
      Console.WriteLine("{0} includes {1}: {2}", 
                        myOrder, flagValue, myOrder.HasFlag(flagValue));
   }
}
// The example displays the following output:
//    Entree, Appetizer, Dessert, Beverage includes Entree, Beverage: True
// </Snippet2>