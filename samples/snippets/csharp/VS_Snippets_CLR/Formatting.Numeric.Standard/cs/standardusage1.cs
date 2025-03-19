using System;

public class Example
{
   public static void Main()
   {
      ShowToString();
      ShowComposite();
      ShowCompositeWithAlignment();
   }

   private static void ShowToString()
   {
      // <Snippet10>
      decimal value = 123.456m;
      Console.WriteLine(value.ToString("C2"));
      // Displays $123.46
      // </Snippet10>
   }

   private static void ShowComposite()
   {
      // <Snippet11>
      decimal value = 123.456m;
      Console.WriteLine($"Your account balance is {0:C2}.");
      // Displays "Your account balance is $123.46."
      // </Snippet11>
   }

   private static void ShowCompositeWithAlignment()
   {
      // <Snippet12>
      decimal[] amounts = { 16305.32m, 18794.16m };
      Console.WriteLine("   Beginning Balance           Ending Balance");
      Console.WriteLine("   {0,-28:C2}{1,14:C2}", amounts[0], amounts[1]);
      // Displays:
      //        Beginning Balance           Ending Balance
      //        $16,305.32                      $18,794.16
      // </Snippet12>
   }
}
