using System;

public class Product
{
   private string productName;
   private int onHand;
   private decimal cost;

   public Product(string name)
   {
      this.productName = name;
   }

   public int Quantity
   {
      get { return this.onHand; }
      set { this.onHand = value; }
   }

   public decimal Price
   {
      get { return this.cost; }
      set { this.cost = value; }
   }

   public decimal Value
   {
      get { return this.cost * this.onHand; }
   }

   public string Name
   {
      get { return this.productName; }
   }

   public override string ToString()
   {
      return this.productName;
   }
}

public class Example2
{
   public static void Main()
   {
      Product item1 = new Product("WidgetA");
      item1.Quantity = 17;
      item1.Price = 6.32m;
      DateTime thatDate = new DateTime(2009, 5, 1);
      string result;
      // <Snippet14>
      result = String.Format("On {0:d}, the inventory of {1} was worth {2:C2}.",
                             thatDate, item1, item1.Value);
      Console.WriteLine(result);
      // The example displays output like the following if run on a system
      // whose current culture is en-US:
      //       On 5/1/2009, the inventory of WidgetA was worth $107.44.
      // </Snippet14>
   }
}
