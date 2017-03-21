public class Example
{
   public static void Main()
   {
      ulong positiveValue = UInt64.MaxValue - 100000;
      long negativeValue = -1;
      
      
      HexString positiveString = new HexString();
      positiveString.Sign = (SignBit) Math.Sign((decimal)positiveValue);
      positiveString.Value = positiveValue.ToString("X");
      
      HexString negativeString = new HexString();
      negativeString.Sign = (SignBit) Math.Sign(negativeValue);
      negativeString.Value = negativeValue.ToString("X");
      
      try {
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt64(positiveString));
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the UInt64 type.", 
                           Int64.Parse(positiveString.Value, NumberStyles.HexNumber));
      }                     

      try {
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt64(negativeString));
      }   
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the UInt64 type.", 
                           Int64.Parse(negativeString.Value, NumberStyles.HexNumber));
      }                           
   }
}
// The example displays the following output:
//       0xFFFFFFFFFFFE795F converts to 18446744073709451615.
//       -1 is outside the range of the UInt64 type.