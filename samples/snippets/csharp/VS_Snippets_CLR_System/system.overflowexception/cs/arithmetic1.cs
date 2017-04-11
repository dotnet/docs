using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      int value = 780000000;
      checked {
      try {
         // Square the original value.
         int square = value * value; 
         Console.WriteLine("{0} ^ 2 = {1}", value, square);
      }
      catch (OverflowException) {
         double square = Math.Pow(value, 2);
         Console.WriteLine("Exception: {0} > {1:E}.", 
                           square, Int32.MaxValue);
      } }
      // The example displays the following output:
      //       Exception: 6.084E+17 > 2.147484E+009.
      // </Snippet1>

      Cast();
      Unchecked();
   }

   private static void Cast()
   {      
      // <Snippet2>
      byte value = 241;
      checked {
      try {
         sbyte newValue = (sbyte) value;
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                           value.GetType().Name, value, 
                           newValue.GetType().Name, newValue);
      }
      catch (OverflowException) {
         Console.WriteLine("Exception: {0} > {1}.", value, SByte.MaxValue);
      } }                            
      // The example displays the following output:
      //       Exception: 241 > 127.
      // </Snippet2>
   }

   private static void Unchecked()
   {
      // <Snippet3>
      byte value = 241;
      try {
         sbyte newValue = (sbyte) value;
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                           value.GetType().Name, value, 
                           newValue.GetType().Name, newValue);
      }
      catch (OverflowException) {
         Console.WriteLine("Exception: {0} > {1}.", value, SByte.MaxValue);
      }
      // The example displays the following output:
      //       Converted the Byte value 241 to the SByte value -15.
      // </Snippet3>
   }
}
