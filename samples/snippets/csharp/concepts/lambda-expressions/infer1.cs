using System;
using System.Linq;

public class Customer
{
   public string Name;
   public string City;
}

public class Example
{
   public static void Main()
   {
      Customer[] customers = new Customer[10];
      
      // <Snippet1>
      customers.Where(c => c.City == "London");
      // </Snippet1>      
   }
}