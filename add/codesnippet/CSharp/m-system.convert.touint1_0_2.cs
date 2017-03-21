public class Example
{
   public static void Main()
   {
      ushort positiveValue = 32000;
      short negativeValue = -1;
      
      HexString positiveString = new HexString();
      positiveString.Sign = (SignBit) Math.Sign(positiveValue);
      positiveString.Value = positiveValue.ToString("X2");
      
      HexString negativeString = new HexString();
      negativeString.Sign = (SignBit) Math.Sign(negativeValue);
      negativeString.Value = negativeValue.ToString("X2");
      
      try {
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt16(positiveString));
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the UInt16 type.", 
                           Int16.Parse(negativeString.Value, NumberStyles.HexNumber));
      }

      try {
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt16(negativeString));
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the UInt16 type.", 
                           Int16.Parse(negativeString.Value, NumberStyles.HexNumber));
      }   
   }
}
// The example displays the following output:
//       0x7D00 converts to 32000.
//       -1 is outside the range of the UInt16 type.