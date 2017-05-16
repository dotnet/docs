Imports System
Imports System.ComponentModel

Namespace ConvertersVB
   
 Public Class TypeCon_Doc


            Enum Servers
                Windows = 1
                Exchange = 2
                BizTalk = 3 '
            End Enum 'Servers

        Shared Sub Main()

            ' ArrayConverter
            '<snippet1>
            ' implemented in another file
            '</snippet1>
            '============================================================
            ' BaseNumberConverter
            '<snippet2>
            ' implemented in another file
            '</snippet2>
            '============================================================
            ' BooleanConverter 
            ' This sample converts a Boolean variable to and from a string variable.
            '<snippet3>
            Dim bVal As Boolean = True
            Dim strA As String = "false"
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertTo(bVal, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertFrom(strA))
            '</snippet3>
            '============================================================
            ' ByteConverter
            ' This sample converts an 8-bit unsigned integer to and from a string.
            '<snippet4>
            Dim myUint As Byte = 5 
            Dim myUStr As String = "2"
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertTo(myUint, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertFrom(myUStr))
            '</snippet4>
            '============================================================
            ' CharConverter 
            ' This sample converts a Char variable to and from a String.
            '<snippet5>
            Dim chrA As [Char] = "a"c
            Dim strB As String = "b"
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertTo(chrA, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertFrom(strB))
            '</snippet5>
            '============================================================
            ' CollectionConverter
            '<snippet6>
            ' implemented in another file
            '</snippet6>
            '============================================================
            ' ComponentConverter
            '<snippet7>
            ' implemented in another file
            '</snippet7>
            '============================================================
            ' CultureInfoConverter
            ' This sample converts a CultureInfo object to and from a string.
            '<snippet8>
            ' The sample first constructs a CultureInfo variable using the Greek culture - 'el'.
            Dim myCulture As New System.Globalization.CultureInfo("el")
            Dim myCString As String = "Russian"
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertTo(myCulture, GetType(String)))
            ' The following line will output 'ru' based on the string being converted.
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertFrom(myCString))
            '</snippet8>
            '============================================================
            ' DateTimeConverter
            ' This sample converts a DateTime variable to and from a String.
            '<snippet9>
            Dim dt As New DateTime(1990, 5, 6)
            Console.WriteLine(TypeDescriptor.GetConverter(dt).ConvertTo(dt, GetType(String)))
            Dim myStr As String = "1991-10-10"
            Console.WriteLine(TypeDescriptor.GetConverter(dt).ConvertFrom(myStr))
            '</snippet9>
            '============================================================
            ' DecimalConverter
            '<snippet10>
            Dim myDec As Decimal = 40
            Dim myDStr As String = "20"
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertTo(myDec, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertFrom(myDStr))
            '</snippet10>
            '============================================================
            ' DoubleConverter
            '<snippet11>
            Dim myDoub As Double = 100.55
            Dim myDoStr As String = "4000.425"
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertTo(myDoub, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertFrom(myDoStr))
            '</snippet11>
            '============================================================
            ' EnumConverter - work
            ' This converter can only convert an enumeration object to and from a string. 
            ' This is declared before main()  enum Servers {Windows=1, Exchange=2, BizTalk=3};
            '<snippet12>
            Dim myServer As Servers = Servers.Exchange
            Dim myServerString As string = "BizTalk"
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertTo(myServer, GetType(String))) 
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertFrom(myServerString))	
            			
            '</snippet12>
            '============================================================
            ' GUIDConverter
            ' This converter can only convert a globally unique identifier object to and from a string.
            '<snippet13>
            Dim myGuid As New Guid("B80D56EC-5899-459d-83B4-1AE0BB8418E4")
            Dim myGuidString As String = "1AA7F83F-C7F5-11D0-A376-00C04FC9DA04"
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertTo(myGuid, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertFrom(myGuidString))
            '</snippet13>
            '============================================================
            ' Int16Converter
            ' The Int16 value type represents signed integers with values ranging from negative 32768 through positive 32767.
            ' This converter can only convert a 16-bit signed integer object to and from a string.
            '<snippet14>
            Dim myInt16 As Short = -10000
            Dim myInt16String As String = "+20000"
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertTo(myInt16, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertFrom(myInt16String))
            '</snippet14>
            '============================================================
            ' Int32Converter
            ' The Int32 value type represents signed integers with values ranging from negative 2,147,483,648 through positive 2,147,483,647.
            ' This converter can only convert a 32-bit signed integer object to and from a string.
            '<snippet15>
            Dim myInt32 As Integer = -967299
            Dim myInt32String As String = "+1345556"
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertTo(myInt32, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertFrom(myInt32String))
            '</snippet15>
            '============================================================
            ' Int64Converter - work
            ' The Int64 value type represents integers with values ranging from negative 9,223,372,036,854,775,808 through positive 9,223,372,036,854,775,807.
            ' This converter can only convert a 64-bit signed integer object to and from a string.
            '<snippet16>
            Dim myInt64 As Long = -123456789123
            Dim myInt64String As String = "+184467440737095551"
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertTo(myInt64, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertFrom(myInt64String))
            '</snippet16>
            '============================================================
            ' ReferenceConverter
            '<snippet17>
            ' implemented in another file
            '</snippet17>
            '============================================================
            ' SByteConverter
            ' The SByte value type represents integers with values ranging from negative 128 to positive 127.
            ' This converter can convert only an 8-bit unsigned integer object to and from a string.
	    ' sbyte not supported in vb.net
            '<snippet18>
'This data type is not supported in Visual Basic.
            '</snippet18>
            '============================================================
            ' SingleConverter
            ' Single - ranging in value from -3.402823E+38 to -1.401298E-45 for negative values and from 1.401298E-45 to 3.402823E+38 for positive values
            ' This converter can only convert a single-precision, floating point number object to and from a string.
            '<snippet19>
            Dim s As [Single] = 3.402823E+10F
            Dim mySStr As String = "3.402823E+10"
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertTo(s, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertFrom(mySStr))
            '</snippet19>
            '============================================================
            ' StringConverter
            'cpconconvertingstringstonetframeworkdatatypes
            '<snippet20>
            'implemented in anothner file
            '</snippet20>
            '============================================================
            ' TimeSpanConverter
            ' This converter can only convert a TimeSpan object to and from a string.
            '<snippet21>
            Dim ts As New TimeSpan(133333330)
            Dim myTSStr As String = "5000000"
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertTo(ts, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertFrom(myTSStr))
            '</snippet21>
            '============================================================
            ' TypeListConverter
            '<snippet22>
            ' implemented in another file
            '</snippet22>
            '============================================================
            ' UInt16Converter
            ' The UInt16 value type represents unsigned integers with values ranging from 0 to 65535
            ' This converter can only convert a 16-bit unsigned integer object to and from a string.
	    ' UInt16 is not supported in VB.NET
            '<snippet23>
'This data type is not supported in Visual Basic.
            '</snippet23>
            '==========================================================
            ' UInt32Converter
            ' The UInt32 value type represents unsigned integers with values ranging from 0 to 4,294,967,295.
            ' This converter can only convert a 32-bit unsigned integer object to and from a string.
	    ' UInt32 is not supported in VB.NET
            '<snippet24>
'This data type is not supported in Visual Basic.
            '</snippet24>
            '============================================================
            ' UInt64Converter
            ' The UInt64 value type represents unsigned integers with values ranging from 0 to 184,467,440,737,095,551,615.
            ' This converter can only convert a 64-bit unsigned integer object to and from a string.
	    ' UInt64 is not supported in VB.NET
            '<snippet25>
'This data type is not supported in Visual Basic.
            '</snippet25>
	    '============================================================
' ExpandableObjectConverter	   
'<snippet26>
Dim strM As String
strM = "1,2,3,4"
            Dim m As New System.Drawing.Printing.Margins(1, 2, 3, 4)
Console.WriteLine(TypeDescriptor.GetConverter(strM).CanConvertTo(GetType(System.Drawing.Printing.Margins)))
Console.WriteLine(TypeDescriptor.GetConverter(m).ConvertToString(m))
'</snippet26>

	    '============================================================

        End Sub 'Main 
    End Class
    End Namespace 'TypeCon 
