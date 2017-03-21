public class Example
{
   public static void Main()
   {
      Temperature cold = new Temperature(-40);
      Temperature freezing = new Temperature(0);
      Temperature boiling = new Temperature(100);
      
      Console.WriteLine(Convert.ToDecimal(cold, null));
      Console.WriteLine(Convert.ToDecimal(freezing, null));
      Console.WriteLine(Convert.ToDecimal(boiling, null));
   }
}
// The example dosplays the following output:
//       -40
//       0
//       100