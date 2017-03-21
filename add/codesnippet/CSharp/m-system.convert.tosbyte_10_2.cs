public class Class1
{
   public static void Main()
   {
      sbyte positiveByte = 120;
      sbyte negativeByte = -101;
      
      
      ByteString positiveString = new ByteString();
      positiveString.Sign = (SignBit) Math.Sign(positiveByte);
      positiveString.Value = positiveByte.ToString("X2");
      
      ByteString negativeString = new ByteString();
      negativeString.Sign = (SignBit) Math.Sign(negativeByte);
      negativeString.Value = negativeByte.ToString("X2");
      
      try {
         Console.WriteLine("'{0}' converts to {1}.", positiveString.Value, Convert.ToSByte(positiveString));
      }
      catch (OverflowException) {
         Console.WriteLine("0x{0} is outside the range of the Byte type.", positiveString.Value);
      }

      try {
         Console.WriteLine("'{0}' converts to {1}.", negativeString.Value, Convert.ToSByte(negativeString));
      }
      catch (OverflowException) {
         Console.WriteLine("0x{0} is outside the range of the Byte type.", negativeString.Value);
      }   
   }
}
// The example displays the following output:
//       '78' converts to 120.
//       '9B' converts to -101.