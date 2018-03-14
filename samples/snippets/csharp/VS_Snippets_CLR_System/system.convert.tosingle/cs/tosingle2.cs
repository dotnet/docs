// <Snippet14>
using System;
using System.Globalization;

public class Temperature : IConvertible
{
   private float m_Temp;

   public Temperature(float temperature)
   {
      this.m_Temp = temperature;
   }
   
   public float Celsius
   {
      get { return this.m_Temp; }   
   }
   
   public float Kelvin
   {
      get { return this.m_Temp + 273.15f; }    
   }
   
   public float Fahrenheit
   {
      get { return (float) Math.Round(this.m_Temp * 9 / 5 + 32, 2); }
   }
   
   public override string ToString()
   {
      return m_Temp.ToString("N2") + " °C";
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
         return Convert.ToByte(this.m_Temp);
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
      return Convert.ToDecimal(this.m_Temp);
   }
   
   public double ToDouble(IFormatProvider provider)
   {
      return Convert.ToDouble(this.m_Temp);
   }   
   
   public short ToInt16(IFormatProvider provider)
   {
      if (this.m_Temp < Int16.MinValue || this.m_Temp > Int16.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int16 type.",
                                                   this.m_Temp));
      else
         return Convert.ToInt16(this.m_Temp);
   }
   
   public int ToInt32(IFormatProvider provider)
      {
      if (this.m_Temp < Int32.MinValue || this.m_Temp > Int32.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int32 type.",
                                                   this.m_Temp));
      else
         return Convert.ToInt32(this.m_Temp);
   }
   
   public long ToInt64(IFormatProvider provider)
   {
      if (this.m_Temp < Int64.MinValue || this.m_Temp > Int64.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int64 type.",
                                                   this.m_Temp));
      else
         return Convert.ToInt64(this.m_Temp);
   }
   
   public sbyte ToSByte(IFormatProvider provider)
   {
      if (this.m_Temp < SByte.MinValue || this.m_Temp > SByte.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the SByte type.",
                                                   this.m_Temp));
      else
         return Convert.ToSByte(this.m_Temp);
   }

   public float ToSingle(IFormatProvider provider)
   {
      return this.m_Temp;
   }

   public string ToString(IFormatProvider provider)
   {
      return m_Temp.ToString("N2", provider) + " °C";
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
         return Convert.ToUInt16(this.m_Temp);
   }

   public uint ToUInt32(IFormatProvider provider)
   {
      if (this.m_Temp < UInt32.MinValue || this.m_Temp > UInt32.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt32 type.",
                                                   this.m_Temp));
      else
         return Convert.ToUInt32(this.m_Temp);
   }
   
   public ulong ToUInt64(IFormatProvider provider)
   {
      if (this.m_Temp < UInt64.MinValue || this.m_Temp > UInt64.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt64 type.",
                                                   this.m_Temp));
      else
         return Convert.ToUInt64(this.m_Temp);
   }
}
// </Snippet14>

// <Snippet15>
public class Example
{
   public static void Main()
   {
      Temperature cold = new Temperature(-40);
      Temperature freezing = new Temperature(0);
      Temperature boiling = new Temperature(100);
      
      Console.WriteLine(Convert.ToInt32(cold, null));
      Console.WriteLine(Convert.ToInt32(freezing, null));
      Console.WriteLine(Convert.ToDouble(boiling, null));
   }
}
// The example dosplays the following output:
//       -40
//       0
//       100
// </Snippet15>
