// <Snippet3>
using System;
using System.Globalization;

public class Temperature : IConvertible
{
   private decimal m_Temp;

   public Temperature(decimal temperature)
   {
      this.m_Temp = temperature;
   }
   
   public decimal Celsius
   {
      get { return this.m_Temp; }   
   }
   
   public decimal Kelvin
   {
      get { return this.m_Temp + 273.15m; }    
   }
   
   public decimal Fahrenheit
   {
      get { return Math.Round((decimal) (this.m_Temp * 9 / 5 + 32), 2); }
   }
   
   public override string ToString()
   {
      return m_Temp.ToString("N2") + "°C";
   }

   // IConvertible implementations.
   public TypeCode GetTypeCode()
   {
      return TypeCode.Object;
   }
   
   public bool ToBoolean(IFormatProvider provider) 
   {
      if (m_Temp == 0)
         return false;
      else
         return true;
   } 
   
   public byte ToByte(IFormatProvider provider)
   {
      if (m_Temp < Byte.MinValue || m_Temp > Byte.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Byte type.", 
                                                   this.m_Temp));
      else
         return Decimal.ToByte(this.m_Temp);
   }
   
   public char ToChar(IFormatProvider provider)
   {
      throw new InvalidCastException("Temperature to Char conversion is not supported.");
   } 
   
   public DateTime ToDateTime(IFormatProvider provider)
   {
      throw new InvalidCastException("Temperature to DateTime conversion is not supported.");
   }
   
   public decimal ToDecimal(IFormatProvider provider)
   {
      return this.m_Temp;
   }
   
   public double ToDouble(IFormatProvider provider)
   {
      return Decimal.ToDouble(this.m_Temp);
   }   
   
   public short ToInt16(IFormatProvider provider)
   {
      if (this.m_Temp < Int16.MinValue || this.m_Temp > Int16.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int16 type.",
                                                   this.m_Temp));
      else
         return Decimal.ToInt16(this.m_Temp);
   }
   
   public int ToInt32(IFormatProvider provider)
      {
      if (this.m_Temp < Int32.MinValue || this.m_Temp > Int32.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int32 type.",
                                                   this.m_Temp));
      else
         return Decimal.ToInt32(this.m_Temp);
   }
   
   public long ToInt64(IFormatProvider provider)
   {
      if (this.m_Temp < Int64.MinValue || this.m_Temp > Int64.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int64 type.",
                                                   this.m_Temp));
      else
         return Decimal.ToInt64(this.m_Temp);
   }
   
   public sbyte ToSByte(IFormatProvider provider)
   {
      if (this.m_Temp < SByte.MinValue || this.m_Temp > SByte.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the SByte type.",
                                                   this.m_Temp));
      else
         return Decimal.ToSByte(this.m_Temp);
   }

   public float ToSingle(IFormatProvider provider)
   {
      return Decimal.ToSingle(this.m_Temp);
   }

   public string ToString(IFormatProvider provider)
   {
      return m_Temp.ToString("N2", provider) + "°C";
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
            if (typeof(Temperature).Equals(conversionType))
               return this;
            else
               throw new InvalidCastException(String.Format("Conversion to a {0} is not supported.",
                                                            conversionType.Name));
         case TypeCode.SByte:
            return this.ToSByte(null);
         case TypeCode.Single:
            return this.ToSingle(null);
         case TypeCode.String:
            return this.ToString(provider);
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
      if (this.m_Temp < UInt16.MinValue || this.m_Temp > UInt16.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt16 type.",
                                                   this.m_Temp));
      else
         return Decimal.ToUInt16(this.m_Temp);
   }

   public uint ToUInt32(IFormatProvider provider)
   {
      if (this.m_Temp < UInt32.MinValue || this.m_Temp > UInt32.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt32 type.",
                                                   this.m_Temp));
      else
         return Decimal.ToUInt32(this.m_Temp);
   }
   
   public ulong ToUInt64(IFormatProvider provider)
   {
      if (this.m_Temp < UInt64.MinValue || this.m_Temp > UInt64.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt64 type.",
                                                   this.m_Temp));
      else
         return Decimal.ToUInt64(this.m_Temp);
   }
}
// </Snippet3>

// <Snippet4>
public class Example
{
   public static void Main()
   {
      Temperature cool = new Temperature(5);
      Type[] targetTypes = { typeof(SByte), typeof(Int16), typeof(Int32),
                             typeof(Int64), typeof(Byte), typeof(UInt16),
                             typeof(UInt32), typeof(UInt64), typeof(Decimal),
                             typeof(Single), typeof(Double), typeof(String) };
      CultureInfo provider = new CultureInfo("fr-FR");
      
      foreach (Type targetType in targetTypes)
      {
         try {
            object value = Convert.ChangeType(cool, targetType, provider);
            Console.WriteLine("Converted {0} {1} to {2} {3}.",
                              cool.GetType().Name, cool.ToString(),
                              targetType.Name, value);
         }
         catch (InvalidCastException) {
            Console.WriteLine("Unsupported {0} --> {1} conversion.",
                              cool.GetType().Name, targetType.Name);
         }                     
         catch (OverflowException) {
            Console.WriteLine("{0} is out of range of the {1} type.",
                              cool, targetType.Name);
         }
      }
   }
}
// The example dosplays the following output:
//       Converted Temperature 5.00°C to SByte 5.
//       Converted Temperature 5.00°C to Int16 5.
//       Converted Temperature 5.00°C to Int32 5.
//       Converted Temperature 5.00°C to Int64 5.
//       Converted Temperature 5.00°C to Byte 5.
//       Converted Temperature 5.00°C to UInt16 5.
//       Converted Temperature 5.00°C to UInt32 5.
//       Converted Temperature 5.00°C to UInt64 5.
//       Converted Temperature 5.00°C to Decimal 5.
//       Converted Temperature 5.00°C to Single 5.
//       Converted Temperature 5.00°C to Double 5.
//       Converted Temperature 5.00°C to String 5,00°C.
// </Snippet4>
