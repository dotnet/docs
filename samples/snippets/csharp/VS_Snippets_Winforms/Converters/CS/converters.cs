using System;
using System.ComponentModel;

namespace TypeCon
{
    public class TypeCon_Doc {

        enum Servers {Windows=1, Exchange=2, BizTalk=3};

        static void Main(string[] args)    {
            
            // ArrayConverter
            //<snippet1>
            // implemented in another file
            //</snippet1>

            //============================================================
            // BaseNumberConverter
            //<snippet2>
            // implemented in another file
            //</snippet2>

            //============================================================
            // BooleanConverter 
            // This sample converts a Boolean variable to and from a string variable.
            //<snippet3>
            bool bVal=true;
            string strA="false";
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertTo(bVal, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertFrom(strA));
            //</snippet3>

            //============================================================
            // ByteConverter - work
            // This sample converts an 8-bit unsigned integer to and from a string.
            //<snippet4>
            byte myUint = 5;
            string myUStr = "2";
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertTo(myUint, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertFrom(myUStr));    
            //</snippet4>

            //============================================================
            // CharConverter 
            // This sample converts a Char variable to and from a String.
            //<snippet5>
            Char chrA='a';
            string strB="b";
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertTo(chrA, typeof(string)));
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertFrom(strB));
            //</snippet5>

            //============================================================
            // CollectionConverter
            //<snippet6>
            // implemented in another file
            //</snippet6>
            
            //============================================================
            // ComponentConverter
            //<snippet7>
            // implemented in another file
            //</snippet7>

            //============================================================
            // CultureInfoConverter
            // This sample converts a CultureInfo object to and from a string.
            //<snippet8>
            // The sample first constructs a CultureInfo variable using the Greek culture - 'el'.
            System.Globalization.CultureInfo myCulture= new System.Globalization.CultureInfo("el");
            string myCString="Russian";
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertTo(myCulture, typeof(string)));
            // The following line will output 'ru' based on the string being converted.
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertFrom(myCString));
            //</snippet8>

            //============================================================
            // DateTimeConverter
            // This sample converts a DateTime variable to and from a String.
            //<snippet9>
            DateTime dt=new DateTime(1990,5,6);
            Console.WriteLine(TypeDescriptor.GetConverter(dt).ConvertTo(dt, typeof(string)));
            string myStr="1991-10-10";
            Console.WriteLine(TypeDescriptor.GetConverter(dt).ConvertFrom(myStr));
            //</snippet9>

            //============================================================
            // DecimalConverter
            //<snippet10>
            decimal myDec = 40;
            string myDStr = "20";
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertTo(myDec, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertFrom(myDStr));    
            //</snippet10>

            //============================================================
            // DoubleConverter
            //<snippet11>
            double myDoub = 100.55;
            string myDoStr = "4000.425";
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertTo(myDoub, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertFrom(myDoStr));    
            //</snippet11>

            //============================================================
            // EnumConverter - work
            // This converter can only convert an enumeration object to and from a string. 
            // This is declared before main()  enum Servers {Windows=1, Exchange=2, BizTalk=3};
            //<snippet12>
            Enum myServer= Servers.Exchange;
            string myServerString = "BizTalk";
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertTo(myServer, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertFrom(myServerString));    
            
            //</snippet12>

            //============================================================
            // GUIDConverter
            // This converter can only convert a globally unique identifier object to and from a string.
            //<snippet13>
            Guid myGuid = new Guid("B80D56EC-5899-459d-83B4-1AE0BB8418E4");
            string myGuidString = "1AA7F83F-C7F5-11D0-A376-00C04FC9DA04";
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertTo(myGuid, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertFrom(myGuidString));    
            //</snippet13>

            //============================================================
            // Int16Converter
            // The Int16 value type represents signed integers with values ranging from negative 32768 through positive 32767.
            // This converter can only convert a 16-bit signed integer object to and from a string.
            //<snippet14>
            short myInt16 = -10000;
            string myInt16String = "+20000";
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertTo(myInt16, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertFrom(myInt16String));    
            //</snippet14>

            //============================================================
            // Int32Converter
            // The Int32 value type represents signed integers with values ranging from negative 2,147,483,648 through positive 2,147,483,647.
            // This converter can only convert a 32-bit signed integer object to and from a string.
            //<snippet15>
            int myInt32 = -967299;
            string myInt32String = "+1345556";
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertTo(myInt32, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertFrom(myInt32String));    
            //</snippet15>

            //============================================================
            // Int64Converter - work
            // The Int64 value type represents integers with values ranging from negative 9,223,372,036,854,775,808 through positive 9,223,372,036,854,775,807.
            // This converter can only convert a 64-bit signed integer object to and from a string.
            //<snippet16>
            long myInt64 = -123456789123;
            string myInt64String = "+184467440737095551";
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertTo(myInt64, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertFrom(myInt64String));    
            //</snippet16>

            //============================================================
            // ReferenceConverter
            //<snippet17>
            // implemented in another file
            //</snippet17>

            //============================================================
            // SByteConverter
            // The SByte value type represents integers with values ranging from negative 128 to positive 127.
            // This converter can convert only an 8-bit unsigned integer object to and from a string.
            //<snippet18>
            sbyte mySByte=+121;
            string mySByteStr="-100";
            Console.WriteLine(TypeDescriptor.GetConverter(mySByte).ConvertTo(mySByte, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(mySByte).ConvertFrom(mySByteStr));    
            //</snippet18>

            //============================================================
            // SingleConverter
            // Single - ranging in value from -3.402823E+38 to -1.401298E-45 for negative values and from 1.401298E-45 to 3.402823E+38 for positive values
            // This converter can only convert a single-precision, floating point number object to and from a string.
            //<snippet19>
            Single s=3.402823E+10F;
            string mySStr="3.402823E+10";
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertTo(s, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertFrom(mySStr));    
            //</snippet19>

            //============================================================
            // StringConverter
            //cpconconvertingstringstonetframeworkdatatypes
            //<snippet20>
            //implemented in anothner file
            //</snippet20>

            //============================================================
            // TimeSpanConverter
            // This converter can only convert a TimeSpan object to and from a string.
            //<snippet21>
            TimeSpan ts=new TimeSpan(133333330);
            string myTSStr = "5000000";
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertTo(ts, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertFrom(myTSStr));    
            //</snippet21>

            //============================================================
            // TypeListConverter
            //<snippet22>
            // implemented in another file
            //</snippet22>

            //============================================================
            // UInt16Converter
            // The UInt16 value type represents unsigned integers with values ranging from 0 to 65535
            // This converter can only convert a 16-bit unsigned integer object to and from a string.
            //<snippet23>
            ushort myUInt16 = 10000;
            string myUInt16String = "20000";
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt16).ConvertTo(myUInt16, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt16).ConvertFrom(myUInt16String));    
            //</snippet23>

            //============================================================
            // UInt32Converter
            // The UInt32 value type represents unsigned integers with values ranging from 0 to 4,294,967,295.
            // This converter can only convert a 32-bit unsigned integer object to and from a string.
            //<snippet24>
            uint myUInt32 = 967299;
            string myUInt32String = "1345556";
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt32).ConvertTo(myUInt32, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt32).ConvertFrom(myUInt32String));    
            //</snippet24>

            //============================================================
            // UInt64Converter
            // The UInt64 value type represents unsigned integers with values ranging from 0 to 184,467,440,737,095,551,615.
            // This converter can only convert a 64-bit unsigned integer object to and from a string.
            //<snippet25>
            ulong myUInt64 = 123456789123;
            string myUInt64String = "184467440737095551";
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt64).ConvertTo(myUInt64, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt64).ConvertFrom(myUInt64String));    
            //</snippet25>

            //============================================================
// ExpandableObjectConverter
//<snippet26>
string strM="1,2,3,4";
System.Drawing.Printing.Margins  m= new System.Drawing.Printing.Margins(1,2,3,4);
Console.WriteLine(TypeDescriptor.GetConverter(strM).CanConvertTo(typeof(System.Drawing.Printing.Margins))); 
Console.WriteLine(TypeDescriptor.GetConverter(m).ConvertToString(m)); 
//</snippet26>

        }
    }
}
