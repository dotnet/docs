' <Snippet1>
' This example demonstrates Math.Min()
Class Sample
   Public Shared Sub Main()
      Dim str As String = "{0}: The lesser of {1,3} and {2,3} is {3}."
      Dim nl As String = Environment.NewLine
      
      Dim xByte1 As Byte = 1
      Dim xByte2 As Byte = 51
      Dim xShort1 As Short = - 2
      Dim xShort2 As Short = 52
      Dim xInt1 As Integer = - 3
      Dim xInt2 As Integer = 53
      Dim xLong1 As Long = - 4
      Dim xLong2 As Long = 54
      Dim xSingle1 As Single = 5F
      Dim xSingle2 As Single = 55F
      Dim xDouble1 As Double = 6.0
      Dim xDouble2 As Double = 56.0
      Dim xDecimal1 As [Decimal] = 7D
      Dim xDecimal2 As [Decimal] = 57D
      
      ' The following types are not CLS-compliant.
      Dim xSbyte1 As SByte = 101
      Dim xSbyte2 As SByte = 111
      Dim xUshort1 As UShort = 102
      Dim xUshort2 As UShort = 112
      Dim xUint1 As UInteger = 103
      Dim xUint2 As UInteger = 113
      Dim xUlong1 As ULong = 104
      Dim xUlong2 As ULong = 114
      
      Console.WriteLine("{0}Display the lesser of two values:{0}", nl)
      Console.WriteLine(str, "Byte   ", xByte1, xByte2, Math.Min(xByte1, xByte2))
      Console.WriteLine(str, "Int16  ", xShort1, xShort2, Math.Min(xShort1, xShort2))
      Console.WriteLine(str, "Int32  ", xInt1, xInt2, Math.Min(xInt1, xInt2))
      Console.WriteLine(str, "Int64  ", xLong1, xLong2, Math.Min(xLong1, xLong2))
      Console.WriteLine(str, "Single ", xSingle1, xSingle2, Math.Min(xSingle1, xSingle2))
      Console.WriteLine(str, "Double ", xDouble1, xDouble2, Math.Min(xDouble1, xDouble2))
      Console.WriteLine(str, "Decimal", xDecimal1, xDecimal2, Math.Min(xDecimal1, xDecimal2))
      '
      Console.WriteLine("{0}The following types are not CLS-compliant:{0}", nl)
      Console.WriteLine(str, "SByte  ", xSbyte1, xSbyte2, Math.Min(xSbyte1, xSbyte2))
      Console.WriteLine(str, "UInt16 ", xUshort1, xUshort2, Math.Min(xUshort1, xUshort2))
      Console.WriteLine(str, "UInt32 ", xUint1, xUInt2, Math.Min(xUInt1, xUInt2))
      Console.WriteLine(str, "UInt64 ", xUlong1, xUlong2, Math.Min(xUlong1, xUlong2))
   End Sub 'Main
End Class 'Sample
'
' This example produces the following results:
'
' Display the lesser of two values:
'
' Byte   : The lesser of   1 and  51 is 1.
' Int16  : The lesser of  -2 and  52 is -2.
' Int32  : The lesser of  -3 and  53 is -3.
' Int64  : The lesser of  -4 and  54 is -4.
' Single : The lesser of   5 and  55 is 5.
' Double : The lesser of   6 and  56 is 6.
' Decimal: The lesser of   7 and  57 is 7.
'
' The following types are not CLS-compliant:
' 
' SByte  : The lesser of 101 and 111 is 101.
' UInt16 : The lesser of 102 and 112 is 102.
' UInt32 : The lesser of 103 and 113 is 103.
' UInt64 : The lesser of 104 and 114 is 104.
' </Snippet1>
