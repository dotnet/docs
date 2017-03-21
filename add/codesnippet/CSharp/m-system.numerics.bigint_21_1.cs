public class BigIntegerFormatProvider : IFormatProvider
{
   public object GetFormat(Type formatType) 
   {
      if (formatType == typeof(NumberFormatInfo)) 
      {
         NumberFormatInfo numberFormat = new NumberFormatInfo();
         numberFormat.NegativeSign = "~";
         return numberFormat;
      }
      else
      {
         return null;
      }      
   }
}