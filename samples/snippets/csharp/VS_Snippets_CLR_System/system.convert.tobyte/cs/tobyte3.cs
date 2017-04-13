// <Snippet12>
using System;
using System.Globalization;

public enum SignBit { Negative=-1, Zero=0, Positive=1 };

public struct ByteString : IConvertible
{
   private SignBit signBit;
   private string byteString;
   
   public SignBit Sign
   { 
      set { signBit = value; }
      get { return signBit; }
   }

   public string Value
   { 
      set {
         if (value.Trim().Length > 2)
            throw new ArgumentException("The string representation of a byte cannot have more than two characters.");
         else
            byteString = value;
      }
      get { return byteString; }
   }
   
   // IConvertible implementations.
   public TypeCode GetTypeCode() {
      return TypeCode.Object;
   }
   
   public bool ToBoolean(IFormatProvider provider)
   {
      if (signBit == SignBit.Zero)
         return false;
      else
         return true;
   } 
   
   public byte ToByte(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is out of range of the Byte type.", Convert.ToSByte(byteString, 16)));
      else
         return Byte.Parse(byteString, NumberStyles.HexNumber);
   }
   
   public char ToChar(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative) { 
         throw new OverflowException(String.Format("{0} is out of range of the Char type.", Convert.ToSByte(byteString, 16)));
      }
      else {
         byte byteValue = Byte.Parse(this.byteString, NumberStyles.HexNumber);
         return Convert.ToChar(byteValue);
      }                
   } 
   
   public DateTime ToDateTime(IFormatProvider provider)
   {
      throw new InvalidCastException("ByteString to DateTime conversion is not supported.");
   }
   
   public decimal ToDecimal(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative) 
      {
         sbyte byteValue = SByte.Parse(byteString, NumberStyles.HexNumber);
         return Convert.ToDecimal(byteValue);
      }
      else 
      {
         byte byteValue = Byte.Parse(byteString, NumberStyles.HexNumber);
         return Convert.ToDecimal(byteValue);
      }
   }
   
   public double ToDouble(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToDouble(SByte.Parse(byteString, NumberStyles.HexNumber));
      else
         return Convert.ToDouble(Byte.Parse(byteString, NumberStyles.HexNumber));
   }   
   
   public short ToInt16(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Convert.ToInt16(SByte.Parse(byteString, NumberStyles.HexNumber));
      else
         return Convert.ToInt16(Byte.Parse(byteString, NumberStyles.HexNumber));
   }
   
   public int ToInt32(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         return Convert.ToInt32(SByte.Parse(byteString, NumberStyles.HexNumber));
      else
         return Convert.ToInt32(Byte.Parse(byteString, NumberStyles.HexNumber));
   }
   
   public long ToInt64(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToInt64(SByte.Parse(byteString, NumberStyles.HexNumber));
      else
         return Convert.ToInt64(Byte.Parse(byteString, NumberStyles.HexNumber));
   }
   
   public sbyte ToSByte(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         try {
            return Convert.ToSByte(Byte.Parse(byteString, NumberStyles.HexNumber));
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is outside the range of the SByte type.", 
                                                   Byte.Parse(byteString, NumberStyles.HexNumber)), e);
         }
      else   
         return SByte.Parse(byteString, NumberStyles.HexNumber);
   }

   public float ToSingle(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         return Convert.ToSingle(SByte.Parse(byteString, NumberStyles.HexNumber));
      else
         return Convert.ToSingle(Byte.Parse(byteString, NumberStyles.HexNumber));
   }

   public string ToString(IFormatProvider provider)
   {
      return "0x" + this.byteString;
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
            if (typeof(ByteString).Equals(conversionType))
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
                                                   SByte.Parse(byteString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt16(Byte.Parse(byteString, NumberStyles.HexNumber));
   }

   public UInt32 ToUInt32(IFormatProvider provider)
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt32 type.", 
                                                   SByte.Parse(byteString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt32(Byte.Parse(byteString, NumberStyles.HexNumber));
   }
   
   public UInt64 ToUInt64(IFormatProvider provider) 
   {
      if (signBit == SignBit.Negative)
         throw new OverflowException(String.Format("{0} is outside the range of the UInt64 type.", 
                                                   SByte.Parse(byteString, NumberStyles.HexNumber)));
      else
         return Convert.ToUInt64(Byte.Parse(byteString, NumberStyles.HexNumber));
   }
}
// </Snippet12>

// <Snippet13>
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
// </Snippet13>
