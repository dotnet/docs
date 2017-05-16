' <Snippet1>
' This example demonstrates Math.Max()
Class Sample
   Public Shared Sub Main()
      Dim str As String = "{0}: The greater of {1,3} and {2,3} is {3}."
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
      Dim xSByte1 As SByte = 101
      Dim xSByte2 As SByte = 111
      Dim xUShort1 As UShort = 102
      Dim xUShort2 As UShort = 112
      Dim xUint1 As UInteger = 103
      Dim xUint2 As UInteger = 113
      Dim xUlong1 As ULong = 104
      Dim xUlong2 As ULong = 114
      
      Console.WriteLine("{0}Display the greater of two values:{0}", nl)
      Console.WriteLine(str, "Byte   ", xByte1, xByte2, Math.Max(xByte1, xByte2))
      Console.WriteLine(str, "Int16  ", xShort1, xShort2, Math.Max(xShort1, xShort2))
      Console.WriteLine(str, "Int32  ", xInt1, xInt2, Math.Max(xInt1, xInt2))
      Console.WriteLine(str, "Int64  ", xLong1, xLong2, Math.Max(xLong1, xLong2))
      Console.WriteLine(str, "Single ", xSingle1, xSingle2, Math.Max(xSingle1, xSingle2))
      Console.WriteLine(str, "Double ", xDouble1, xDouble2, Math.Max(xDouble1, xDouble2))
      Console.WriteLine(str, "Decimal", xDecimal1, xDecimal2, Math.Max(xDecimal1, xDecimal2))
      '
      Console.WriteLine("{0}(The following types are not CLS-compliant.){0}", nl)
      Console.WriteLine(str, "SByte  ", xSByte1, xSByte2, Math.Max(xSByte1, xSByte2))
      Console.WriteLine(str, "UInt16 ", xUShort1, xUShort2, Math.Max(xUShort1, xUShort2))
      Console.WriteLine(str, "UInt32 ", xUint1, xUint2, Math.Max(xUint1, xUint2))
      Console.WriteLine(str, "UInt64 ", xUlong1, xUlong2, Math.Max(xUlong1, xUlong2))
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'Display the greater of two values:
'
'Byte   : The greater of   1 and  51 is 51.
'Int16  : The greater of  -2 and  52 is 52.
'Int32  : The greater of  -3 and  53 is 53.
'Int64  : The greater of  -4 and  54 is 54.
'Single : The greater of   5 and  55 is 55.
'Double : The greater of   6 and  56 is 56.
'Decimal: The greater of   7 and  57 is 57.
'
' (The following types are not CLS-compliant.)
' 
' SByte  : The greater of 101 and 111 is 111.
' UInt16 : The greater of 102 and 112 is 112.
' UInt32 : The greater of 103 and 113 is 113.
' UInt64 : The greater of 104 and 114 is 114.
' </Snippet1>
