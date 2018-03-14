// <Snippet1>
using System;
using System.Text;

public class Customer
{
   private string custName;
   private int custNumber;
   
   public Customer(string name, int number)
   {
      this.custName = name;
      this.custNumber = number;
   }
   
   public string Name
   {
      get { return this.custName; }
   }
   
   public int CustomerNumber
   {
      get { return this.custNumber; }
   }
}

public class CustomerNumberFormatter : IFormatProvider, ICustomFormatter
{   
   public object GetFormat(Type formatType)
   {
      if (formatType == typeof(ICustomFormatter))
         return this;
      return null;
   }
   
   public string Format(string format, object arg, IFormatProvider provider)
   {
      if (arg is Int32)
      {
         string custNumber = ((int) arg).ToString("D10");
         return custNumber.Substring(0, 4) + "-" + custNumber.Substring(4, 3) + 
                "-" + custNumber.Substring(7, 3);
      }
      else
      {
         return null;
      }
   }                   
}

public class Example
{
   public static void Main()
   {
      Customer customer = new Customer("A Plus Software", 903654);
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat(new CustomerNumberFormatter(), "{0}: {1}", 
                      customer.CustomerNumber, customer.Name);
      Console.WriteLine(sb.ToString());
   }
}
// The example displays the following output:
//      0000-903-654: A Plus Software
// </Snippet1>
