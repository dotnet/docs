// <Snippet16>
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public enum SignBit { Negative=-1, Zero=0, Positive=1 };

public struct HexString : IConvertible
{
   private SignBit signBit;
   private string hexString;
   
   public SignBit Sign
   { 
      set { signBit = value; }
      get { return signBit; }
   }

   public string Value
   { 
      set {
         if (value.Trim().Length > 4)
            throw new ArgumentException("The string representation of a 160bit integer cannot have more than four characters.");
         else if (! Regex.IsMatch(value, "([0-9,A-F]){1,4}", RegexOptions.IgnoreCase))
            throw new ArgumentException("The hexadecimal representation of a 16-bit integer contains invalid characters.");
         else
            hexString = value;
      }
      get { return hexString; }
   }
   
   // IConvertible implementations.
   public TypeCode GetTypeCode() {
      return TypeCode.Object;
   }
   
   public bool ToBoolean(IFormatProvider provider)
   {
      return signBit != SignBit.Zero;
   } 
   
   public byte ToByte(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToInt16(hexString, 16)));
      else
         try {
            return Convert.ToByte(UInt16.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the UInt16 type.", Convert.ToUInt16(hexString, 16)), e);
         }
   }
   
   public char ToChar(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative) { 
         throw new OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToInt16(hexString, 16)));
      }
      
      UInt16 codePoint = UInt16.Parse(this.hexString, NumberStyles.HexNumber);
      return Convert.ToChar(codePoint);
   } 
   
   public DateTime ToDateTime(IFormatProvider provider)
   {
      throw new InvalidCastException("Hexadecimal to DateTime conversion is not supported.");
   }
   
   public decimal ToDecimal(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative) 
      {
         short hexValue = Int16.Parse(hexString, NumberStyles.HexNumber);
         return Convert.ToDecimal(hexValue);
      }
      else 
      {
         ushort hexValue = UInt16.Parse(hexString, NumberStyles.HexNumber);
         return Convert.ToDecimal(hexValue);
      }
   }
   
   public double ToDouble(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToDouble(Int16.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToDouble(UInt16.Parse(hexString, NumberStyles.HexNumber));
   }   
   
   public short ToInt16(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Int16.Parse(hexString, NumberStyles.HexNumber);
      else
         try {
            return Convert.ToInt16(UInt16.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int16 type.", 
                                                      Convert.ToUInt16(hexString, 16)), e);
         }
   }
   
   public int ToInt32(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Convert.ToInt32(Int16.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToInt32(UInt16.Parse(hexString, NumberStyles.HexNumber));
   }
   
   public long ToInt64(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToInt64(Int16.Parse(hexString, NumberStyles.HexNumber));
      else
         return Int64.Parse(hexString, NumberStyles.HexNumber);
   }
   
   public sbyte ToSByte(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToSByte(Int16.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                      Int16.Parse(hexString, NumberStyles.HexNumber), e));
         }
      else
         try {
            return Convert.ToSByte(UInt16.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                   UInt16.Parse(hexString, NumberStyles.HexNumber)), e);
         } 
   }

   public float ToSingle(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToSingle(Int16.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToSingle(UInt16.Parse(hexString, NumberStyles.HexNumber));
   }

   public string ToString(IFormatProvider provider)
   {
      return "0x" + this.hexString;
   }
   
   public object ToType(Type conversionType, IFormatProvider provider)
   {
      switch (Type.GetTypeCode(conversionType))
      {
         case TypeCode.Boolean: 
            return this.ToBoolean(null);
         case TypeCode.Byte:
            return this.ToByte(null);
         case TypeCode.Char:
            return this.ToChar(null);
         case TypeCode.DateTime:
            return this.ToDateTime(null);
         case TypeCode.Decimal:
            return this.ToDecimal(null);
         case TypeCode.Double:
            return this.ToDouble(null);
         case TypeCode.Int16:
            return this.ToInt16(null);
         case TypeCode.Int32:
            return this.ToInt32(null);
         case TypeCode.Int64:
            return this.ToInt64(null);
         case TypeCode.Object:
            if (typeof(HexString).Equals(conversionType))
               return this;
            else
               throw new InvalidCastException(String.Format("Conversion to a {0} is not supported.", conversionType.Name));
         case TypeCode.SByte:
            return this.ToSByte(null);
         case TypeCode.Single:
            return this.ToSingle(null);
         case TypeCode.String:
            return this.ToString(null);
         case TypeCode.UInt16:
            return this.ToUInt16(null);
         case TypeCode.UInt32:
            return this.ToUInt32(null);
         case TypeCode.UInt64:
            return this.ToUInt64(null);   
         default:
            throw new InvalidCastException(String.Format("Conversion to {0} is not supported.", conversionType.Name));   
      }
   }
   
   public UInt16 ToUInt16(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt16 type.", 
                                                   Int16.Parse(hexString, NumberStyles.HexNumber)));
      else
         return UInt16.Parse(hexString, NumberStyles.HexNumber);
   }

   public UInt32 ToUInt32(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt32 type.", 
                                                   Int16.Parse(hexString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt32(hexString, 16);
   }
   
   public UInt64 ToUInt64(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt64 type.", 
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt64(hexString, 16);
   }
}
// </Snippet16>

// <Snippet17>
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
// </Snippet17>
