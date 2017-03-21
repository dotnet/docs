public class Example
{
   public static void Main()
   {
      uint positiveValue = 320000000;
      int negativeValue = -1;
      
      HexString positiveString = new HexString();
      positiveString.Sign = (SignBit) Math.Sign(positiveValue);
      positiveString.Value = positiveValue.ToString("X4");
      
      HexString negativeString = new HexString();
      negativeString.Sign = (SignBit) Math.Sign(negativeValue);
      negativeString.Value = negativeValue.ToString("X4");
      
      try {
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt32(positiveString));
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the UInt32 type.", 
                           Int32.Parse(positiveString.Value, NumberStyles.HexNumber));
      }

      try {
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt32(negativeString));
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the UInt32 type.",
                           Int32.Parse(negativeString.Value, NumberStyles.HexNumber));
      }   
   }
}
// The example dosplays the following output:
//       0x1312D000 converts to 320000000.
//       -1 is outside the range of the UInt32 type.