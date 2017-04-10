// <Snippet17>
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
      set 
      { 
         if (value.Trim().Length > 16)
            throw new ArgumentException("The hexadecimal representation of a 64-bit integer cannot have more than 16 characters.");
         else if (! Regex.IsMatch(value, "([0-9,A-F]){1,8}", RegexOptions.IgnoreCase))
            throw new ArgumentException("The hexadecimal representation of a 64-bit integer contains invalid characters.");             
         else
            hexString = value;
      } 
      get { return hexString; }
   }
   
   // IConvertible implementations.
   public TypeCode GetTypeCode() 
   {
      return TypeCode.Object;
   }
   
   public bool ToBoolean(IFormatProvider provider)
   {
      return signBit != SignBit.Zero;
   } 
   
   public byte ToByte(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToInt64(hexString, 16))); 
      else
         try {
            return Byte.Parse(hexString, NumberStyles.HexNumber);
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToUInt64(hexString, 16)), e);
         }   
   }
   
   public char ToChar(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative) 
         throw new OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToInt64(hexString, 16)));
      
      try {
         ushort codePoint = UInt16.Parse(this.hexString, NumberStyles.HexNumber);
         return Convert.ToChar(codePoint);
      }   
      catch (OverflowException) {
         throw new OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToUInt64(hexString, 16)));
      }      
   } 
   
   public DateTime ToDateTime(IFormatProvider provider)
   {
      throw new InvalidCastException("Hexadecimal to DateTime conversion is not supported.");
   }
   
   public decimal ToDecimal(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
      {
         long hexValue = Int64.Parse(hexString, NumberStyles.HexNumber);
         return Convert.ToDecimal(hexValue);
      }   
      else
      {
         ulong hexValue = UInt64.Parse(hexString, NumberStyles.HexNumber);
         return Convert.ToDecimal(hexValue);
      }
   }
   
   public double ToDouble(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Convert.ToDouble(Int64.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToDouble(UInt64.Parse(hexString, NumberStyles.HexNumber));
   }   
   
   public short ToInt16(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToInt16(Int64.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) { 
            throw new OverflowException(String.Format("{0} is out of range of the Int16 type.", Convert.ToInt64(hexString, 16)), e);
         }
      else
         try {
            return Convert.ToInt16(UInt64.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int16 type.", Convert.ToUInt64(hexString, 16)), e);
         }
   }
   
   public int ToInt32(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToInt32(Int64.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int32 type.", Convert.ToUInt64(hexString, 16)), e);
         }   
      else
         try {
            return Convert.ToInt32(UInt64.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int32 type.", Convert.ToUInt64(hexString, 16)), e);
         }   
   }
   
   public long ToInt64(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Int64.Parse(hexString, NumberStyles.HexNumber);
      else
         try {
            return Convert.ToInt64(UInt64.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int64 type.", Convert.ToUInt64(hexString, 16)), e);
         }
   }
   
   public sbyte ToSByte(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToSByte(Int64.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                      Int64.Parse(hexString, NumberStyles.HexNumber), e));
         }
      else
         try {
            return Convert.ToSByte(UInt64.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                    UInt64.Parse(hexString, NumberStyles.HexNumber)), e);
         }   
   }

   public float ToSingle(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Convert.ToSingle(Int64.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToSingle(UInt64.Parse(hexString, NumberStyles.HexNumber));
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
   
   public ushort ToUInt16(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt16 type.", 
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)));
      else
         try {
            return Convert.ToUInt16(UInt64.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the UInt16 type.", Convert.ToUInt64(hexString, 16)), e);
         }            
   }

   public uint ToUInt32(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt32 type.", 
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)));
      else
         try {
            return Convert.ToUInt32(UInt64.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException) {
            throw new OverflowException(String.Format("{0} is outside the range of the UInt32 type.", 
                                                      UInt64.Parse(hexString, NumberStyles.HexNumber)));
         }   
   }
   
   public ulong ToUInt64(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt64 type.", 
                                                   Int64.Parse(hexString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt64(hexString, 16);
   }
}
// </Snippet17>

// <Snippet18>
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
// </Snippet18>
