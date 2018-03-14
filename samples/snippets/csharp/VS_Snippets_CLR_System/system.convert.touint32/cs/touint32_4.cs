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
      set {
         if (value.Trim().Length > 8)
            throw new ArgumentException("The string representation of a 32-bit integer cannot have more than 8 characters.");
         else if (! Regex.IsMatch(value, "([0-9,A-F]){1,8}", RegexOptions.IgnoreCase))
            throw new ArgumentException("The hexadecimal representation of a 32-bit integer contains invalid characters.");             
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
         throw new OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToInt32(hexString, 16))); 
      else
         try {
            return Byte.Parse(hexString, NumberStyles.HexNumber);
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToUInt32(hexString, 16)), e);
         }   
   }
   
   public char ToChar(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative) 
         throw new OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToInt32(hexString, 16)));
      
      try {
         ushort codePoint = UInt16.Parse(this.hexString, NumberStyles.HexNumber);
         return Convert.ToChar(codePoint);
      }
      catch (OverflowException e) {
         throw new OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToUInt32(hexString, 16)), e);
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
         int hexValue = Int32.Parse(hexString, NumberStyles.HexNumber);
         return Convert.ToDecimal(hexValue);
      }
      else
      {
         uint hexValue = UInt32.Parse(hexString, NumberStyles.HexNumber);
         return Convert.ToDecimal(hexValue);
      }
   }
   
   public double ToDouble(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToDouble(Int32.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToDouble(UInt32.Parse(hexString, NumberStyles.HexNumber));
   }   
   
   public short ToInt16(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToInt16(Int32.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int16 type.", Convert.ToInt32(hexString, 16)), e);
         }
      else
         try {
            return Convert.ToInt16(UInt32.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int16 type.", Convert.ToUInt32(hexString, 16)), e);
         }
   }
   
   public int ToInt32(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Int32.Parse(hexString, NumberStyles.HexNumber);
      else
         try {
            return Convert.ToInt32(UInt32.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the Int32 type.", Convert.ToUInt32(hexString, 16)), e);
         }   
   }
   
   public long ToInt64(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Convert.ToInt64(Int32.Parse(hexString, NumberStyles.HexNumber));
      else
         return Int64.Parse(hexString, NumberStyles.HexNumber);
   }
   
   public sbyte ToSByte(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToSByte(Int32.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                      Int32.Parse(hexString, NumberStyles.HexNumber), e));
         }
      else
         try {
            return Convert.ToSByte(UInt32.Parse(hexString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                    UInt32.Parse(hexString, NumberStyles.HexNumber)), e);
         }   
   }

   public float ToSingle(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToSingle(Int32.Parse(hexString, NumberStyles.HexNumber));
      else
         return Convert.ToSingle(UInt32.Parse(hexString, NumberStyles.HexNumber));
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
                                                   Int32.Parse(hexString, NumberStyles.HexNumber)));
      else
         try {
            return Convert.ToUInt16(UInt32.Parse(hexString, NumberStyles.HexNumber));
         }   
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range of the UInt16 type.", Convert.ToUInt32(hexString, 16)), e);
         }            
   }

   public uint ToUInt32(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt32 type.", 
                                                   Int32.Parse(hexString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt32(hexString, 16);
   }
   
   public ulong ToUInt64(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt64 type.", 
                                                   Int32.Parse(hexString, NumberStyles.HexNumber)));
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
// </Snippet18>
