' <Snippet1>
' This example demonstrates Math.Sign()
Class Sample
   Public Shared Sub Main()
      Dim str As String = "{0}: {1,3} is {2} zero."
      Dim nl As String = Environment.NewLine
      
      Dim xByte1 As Byte = 0
      Dim xShort1 As Short = -2
      Dim xInt1 As Integer = -3
      Dim xLong1 As Long = -4
      Dim xSingle1 As Single = 0F
      Dim xDouble1 As Double = 6.0
      Dim xDecimal1 As [Decimal] = -7D
      
      ' The following type is not CLS-compliant.
      Dim xSbyte1 As SByte = -101
      
      Console.WriteLine("{0}Test the sign of the following types of values:", nl)
      Console.WriteLine(str, "Byte   ", xByte1, Test(Math.Sign(xByte1)))
      Console.WriteLine(str, "Int16  ", xShort1, Test(Math.Sign(xShort1)))
      Console.WriteLine(str, "Int32  ", xInt1, Test(Math.Sign(xInt1)))
      Console.WriteLine(str, "Int64  ", xLong1, Test(Math.Sign(xLong1)))
      Console.WriteLine(str, "Single ", xSingle1, Test(Math.Sign(xSingle1)))
      Console.WriteLine(str, "Double ", xDouble1, Test(Math.Sign(xDouble1)))
      Console.WriteLine(str, "Decimal", xDecimal1, Test(Math.Sign(xDecimal1)))
      '
      Console.WriteLine("{0}The following type is not CLS-compliant.", nl)
      Console.WriteLine(str, "SByte  ", xSbyte1, Test(Math.Sign(xSbyte1)))
   End Sub 'Main
   '
   Public Shared Function Test([compare] As Integer) As [String]
      If [compare] = 0 Then
         Return "equal to"
      ElseIf [compare] < 0 Then
         Return "less than"
      Else
         Return "greater than"
      End If
   End Function 'Test
End Class 'Sample 
'
'This example produces the following results:
'
'Test the sign of the following types of values:
'Byte   :   0 is equal to zero.
'Int16  :  -2 is less than zero.
'Int32  :  -3 is less than zero.
'Int64  :  -4 is less than zero.
'Single :   0 is equal to zero.
'Double :   6 is greater than zero.
'Decimal:  -7 is less than zero.
'
'The following type is not CLS-compliant.
'SByte  : -101 is less than zero.
' </Snippet1>
