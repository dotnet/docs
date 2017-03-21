public class Class1
{
   public static void Main()
   {
      byte positiveByte = 216;
      sbyte negativeByte = -101;
      
      
      ByteString positiveString = new ByteString();
      positiveString.Sign = (SignBit) Math.Sign(positiveByte);
      positiveString.Value = positiveByte.ToString("X2");
      
      ByteString negativeString = new ByteString();
      negativeString.Sign = (SignBit) Math.Sign(negativeByte);
      negativeString.Value = negativeByte.ToString("X2");
      
      try {
         Console.WriteLine("'{0}' converts to {1}.", positiveString.Value, Convert.ToByte(positiveString));
      }
      catch (OverflowException) {
         Console.WriteLine("0x{0} is outside the range of the Byte type.", positiveString.Value);
      }

      try {
         Console.WriteLine("'{0}' converts to {1}.", negativeString.Value, Convert.ToByte(negativeString));
      }
      catch (OverflowException) {
         Console.WriteLine("0x{0} is outside the range of the Byte type.", negativeString.Value);
      }   
   }
}
// The example displays the following output:
//       'D8' converts to 216.
//       0x9B is outside the range of the Byte type.