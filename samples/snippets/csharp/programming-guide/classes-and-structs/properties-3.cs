using System;

public class SaleItem
{
   string name;
   decimal cost;
   
   public SaleItem(string name, decimal cost)
   {
      this.name = name;
      this.cost = cost;
   }

   public string Name 
   {
      get => name;
      set => name = value;
   }

   public decimal Price
   {
      get => cost;
      set => cost = value; 
   }
}

class Program
{
   static void Main(string[] args)
   {
      var item = new SaleItem("Shoes", 19.95m);
      Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
   }
}
// The example displays output like the following:
//       Shoes: sells for $19.95



