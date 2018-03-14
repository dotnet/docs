using System;

public class Example
{
   public static void Main()
   {
      int value = 3;
      ShowValue(value);
   }

   // <Snippet1>
   private static void ShowValue(int _)
   {
      byte[] arr = { 0, 0, 1, 2 };
      _ = BitConverter.ToInt32(arr, 0);
      Console.WriteLine(_);
   }
   // The example displays the following output:
   //       33619968
   // </Snippet1>

   // <Snippet2>
   private static bool RoundTrips(int _)
   {
      string value = _.ToString();
      int newValue = 0;
      _ = Int32.TryParse(value, out newValue);
      return _ == newValue;
   }
   // The example displays the following compiler error:
   //      error CS0029: Cannot implicitly convert type 'bool' to 'int'   
   // </Snippet2>

   // <Snippet3>
   public void DoSomething(int _) 
   {
   	var _ = GetValue(); // Error: cannot declare local _ when one is already in scope
   }   
   // The example displays the following compiler error:
   // error CS0136: 
   //       A local or parameter named '_' cannot be declared in this scope 
   //       because that name is used in an enclosing local scope 
   //       to define a local or parameter   
   // </Snippet3>
   
   private int GetValue()
   {
      return 3;
   }
}
