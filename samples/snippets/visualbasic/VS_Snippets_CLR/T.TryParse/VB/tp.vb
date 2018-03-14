'<snippet1>
' This example demonstrates overloads of the TryParse method for
' several base types, and the TryParseExact method for DateTime.
' In most cases, this example uses the most complex overload; that is, the overload 
' with the most parameters for a particular type. If a complex overload specifies 
' null (Nothing in Visual Basic) for the IFormatProvider parameter, formatting 
' information is obtained from the culture associated with the current thread. 
' If a complex overload specifies the style parameter, the parameter value is 
' the default value used by the equivalent simple overload.

Imports System
Imports System.Globalization

Class Sample
   Public Shared Sub Main()
      Dim result As Boolean
      Dim ci As CultureInfo
      Dim nl As String = Environment.NewLine
      Dim msg1 As String = _
                 "This example demonstrates overloads of the TryParse method for{0}" & _
                 "several base types, as well as the TryParseExact method for DateTime.{0}"
      Dim msg2 As String = "Non-numeric types:{0}"
      Dim msg3 As String = "{0}Numeric types:{0}"
      Dim msg4 As String = "{0}The following types are not CLS-compliant:{0}"
      
      ' Non-numeric types.
      Dim booleanVal As [Boolean]
      Dim charVal As [Char]
      Dim datetimeVal As DateTime
      
      ' Numeric types.
      Dim byteVal As [Byte]
      Dim int16Val As Int16
      Dim int32Val As Int32
      Dim int64Val As Int64
      Dim decimalVal As [Decimal]
      Dim singleVal As [Single]
      Dim doubleVal As [Double]
      
      ' The following types are not CLS-compliant.
      Dim sbyteVal As SByte
      Dim uint16Val As UInt16
      Dim uint32Val As UInt32
      Dim uint64Val As UInt64
      '
      Console.WriteLine(msg1, nl)
      
      ' Non-numeric types:
      Console.WriteLine(msg2, nl)
      ' DateTime
      ' TryParse:
      ' Assume current culture is en-US, and dates of the form: MMDDYYYY.
      result = DateTime.TryParse("7/4/2004 12:34:56", datetimeVal)
      Show(result, "DateTime #1", datetimeVal.ToString())
      
      ' Use fr-FR culture, and dates of the form: DDMMYYYY.
      ci = New CultureInfo("fr-FR")
      result = DateTime.TryParse("4/7/2004 12:34:56", ci, DateTimeStyles.None, datetimeVal)
      Show(result, "DateTime #2", datetimeVal.ToString())
      
      ' TryParseExact:
      ' Use fr-FR culture. The format, "G", is short date and long time.
      result = DateTime.TryParseExact("04/07/2004 12:34:56", "G", ci, DateTimeStyles.None, datetimeVal)
      Show(result, "DateTime #3", datetimeVal.ToString())
      
      ' Assume en-US culture.
      Dim dateFormats As String() =  {"f", "F", "g", "G"}
      result = DateTime.TryParseExact("7/4/2004 12:34:56 PM", dateFormats, Nothing, DateTimeStyles.None, datetimeVal)
      Show(result, "DateTime #4", datetimeVal.ToString())
      
      Console.WriteLine()
      ' Boolean
      result = [Boolean].TryParse("true", booleanVal)
      Show(result, "Boolean", booleanVal.ToString())
      ' Char
      result = [Char].TryParse("A", charVal)
      Show(result, "Char", charVal.ToString())
      
      ' Numeric types:
      Console.WriteLine(msg3, nl)
      ' Byte
      result = [Byte].TryParse("1", NumberStyles.Integer, Nothing, byteVal)
      Show(result, "Byte", byteVal.ToString())
      ' Int16
      result = Int16.TryParse("-2", NumberStyles.Integer, Nothing, int16Val)
      Show(result, "Int16", int16Val.ToString())
      ' Int32
      result = Int32.TryParse("3", NumberStyles.Integer, Nothing, int32Val)
      Show(result, "Int32", int32Val.ToString())
      ' Int64
      result = Int64.TryParse("4", NumberStyles.Integer, Nothing, int64Val)
      Show(result, "Int64", int64Val.ToString())
      ' Decimal
      result = [Decimal].TryParse("-5.5", NumberStyles.Number, Nothing, decimalVal)
      Show(result, "Decimal", decimalVal.ToString())
      ' Single
      result = [Single].TryParse("6.6", NumberStyles.Float Or NumberStyles.AllowThousands, Nothing, singleVal)
      Show(result, "Single", singleVal.ToString())
      ' Double
      result = [Double].TryParse("-7", NumberStyles.Float Or NumberStyles.AllowThousands, Nothing, doubleVal)
      Show(result, "Double", doubleVal.ToString())
      
      ' Use the simple Double.TryParse overload, but specify an invalid value.
      result = [Double].TryParse("abc", doubleVal)
      Show(result, "Double #2", doubleVal.ToString())
      '
      Console.WriteLine(msg4, nl)
      ' SByte
      result = SByte.TryParse("-8", NumberStyles.Integer, Nothing, sbyteVal)
      Show(result, "SByte", sbyteVal.ToString())
      ' UInt16
      result = UInt16.TryParse("9", NumberStyles.Integer, Nothing, uint16Val)
      Show(result, "UInt16", uint16Val.ToString())
      ' UInt32
      result = UInt32.TryParse("10", NumberStyles.Integer, Nothing, uint32Val)
      Show(result, "UInt32", uint32Val.ToString())
      ' UInt64
      result = UInt64.TryParse("11", NumberStyles.Integer, Nothing, uint64Val)
      Show(result, "UInt64", uint64Val.ToString())
   End Sub 'Main
   
   
   Protected Shared Sub Show(parseResult As Boolean, typeName As String, parseValue As String)
      Dim msgSuccess As String = "Parse for {0} = {1}"
      Dim msgFailure As String = "** Parse for {0} failed. Invalid input."
      '
      If parseResult = True Then
         Console.WriteLine(msgSuccess, typeName, parseValue)
      Else
         Console.WriteLine(msgFailure, typeName)
      End If
   End Sub 'Show
End Class 'Sample '
'This example produces the following results:
'
'This example demonstrates overloads of the TryParse method for
'several base types, as well as the TryParseExact method for DateTime.
'
'Non-numeric types:
'
'Parse for DateTime #1 = 7/4/2004 12:34:56 PM
'Parse for DateTime #2 = 7/4/2004 12:34:56 PM
'Parse for DateTime #3 = 7/4/2004 12:34:56 PM
'Parse for DateTime #4 = 7/4/2004 12:34:56 PM
'
'Parse for Boolean = True
'Parse for Char = A
'
'Numeric types:
'
'Parse for Byte = 1
'Parse for Int16 = -2
'Parse for Int32 = 3
'Parse for Int64 = 4
'Parse for Decimal = -5.5
'Parse for Single = 6.6
'Parse for Double = -7
'** Parse for Double #2 failed. Invalid input.
'
'The following types are not CLS-compliant:
'
'Parse for SByte = -8
'Parse for UInt16 = 9
'Parse for UInt32 = 10
'Parse for UInt64 = 11
'
'</snippet1>