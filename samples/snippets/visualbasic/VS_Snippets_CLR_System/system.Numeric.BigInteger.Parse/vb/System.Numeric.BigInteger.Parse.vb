' Visual Basic code for BIgInteger.Parse method
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module modMain
   Public Sub Main()
      'ParseString()
      'Console.WriteLine()
      'ParseStringWithIFormatProvider()
      'Console.WriteLine()
      'ParseWithCustomIFormatProvider()
      'Console.WriteLine()
      'ParseWithStyle()
      ParseOverload4()
   End Sub
   
   Private Sub ParseString()
      ' <Snippet1>
      Try
         ' <Snippet7>
         Dim number1 As BigInteger = BigInteger.Parse("12347534159895123")
         Dim number2 As BigInteger = BigInteger.Parse("987654321357159852")
         ' </Snippet7>
         number1 *= 3
         number2 *= 2
         Select Case BigInteger.Compare(number1, number2)
            Case -1
               Console.WriteLine("{0} is greater than {1}.", number2, number1)
            Case 0
               Console.WriteLine("{0} is equal to {1}.", number1, number2)
            Case 1
               Console.WriteLine("{0} is greater than {1}.", number1, number2)
         End Select      
      Catch e As FormatException
         Console.WriteLine("Unable to initialize integer because of invalid format in string.")
      End Try
      ' </Snippet1>     
   End Sub
   
   Private Sub ParseStringWithIFormatProvider()
      ' <Snippet4>   
      Dim fmt As New NumberFormatInfo()
      fmt.NegativeSign = "~"
      
      Dim number As BigInteger = BigInteger.Parse("~6354129876", fmt)
      ' Display value using same formatting information
      Console.WriteLine(number.ToString(fmt))
      ' Display value using formatting of current culture
      Console.WriteLine(number)
      ' </Snippet4>
   End Sub
   
   Private Sub ParseWithCustomIFormatProvider()
      ' <Snippet3>
      Dim number As BigInteger = BigInteger.Parse("~6354129876", New BigIntegerFormatProvider)
      ' Display value using same formatting information
      Console.WriteLine(number.ToString(New BigIntegerFormatProvider))
      ' Display value using formatting of current culture
      Console.WriteLine(number)
      ' </Snippet3>
   End Sub
   
   Public Sub ParseWithStyle()
      ' <Snippet5>
      Dim number As BigInteger 
      ' Method should succeed (white space and sign allowed)
      number = BigInteger.Parse("   -68054   ", NumberStyles.Integer)
      Console.WriteLine(number)
      ' Method should succeed (string interpreted as hexadecimal)
      number = BigInteger.Parse("68054", NumberStyles.AllowHexSpecifier)
      Console.WriteLine(number)
      ' Method call should fail: sign not allowed
      Try
         number = BigInteger.Parse("   -68054  ", NumberStyles.AllowLeadingWhite _
                                                  Or NumberStyles.AllowTrailingWhite)
         Console.WriteLine(number)
      Catch e As FormatException
         Console.WriteLine(e.Message)
      End Try                                                     
      ' Method call should fail: white space not allowed
      Try
         number = BigInteger.Parse("   68054  ", NumberStyles.AllowLeadingSign)
         Console.WriteLine(number)
      Catch e As FormatException
         Console.WriteLine(e.Message)
      End Try    
      '
      ' The method produces the following output:
      '
      '     -68054
      '     426068
      '     Input string was not in a correct format.
      '     Input string was not in a correct format.                                                 
      ' </Snippet5>
   End Sub
   
   Private Sub ParseOverload4()
      ' <Snippet6>
      ' Call parse with default values of style and provider
      Console.WriteLine(BigInteger.Parse("  -300   ", _
                        NumberStyles.Integer, CultureInfo.CurrentCulture))
      ' Call parse with default values of style and provider supporting tilde as negative sign
      Console.WriteLine(BigInteger.Parse("   ~300  ", _
                                         NumberStyles.Integer, New BigIntegerFormatProvider()))
      ' Call parse with only AllowLeadingWhite and AllowTrailingWhite
      ' Exception thrown because of presence of negative sign
      Try
         Console.WriteLIne(BigInteger.Parse("    ~300   ", _
                                            NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite, _
                                            New BigIntegerFormatProvider()))
      Catch e As FormatException
         Console.WriteLine("{0}: {1}   {2}", e.GetType().Name, vbCrLf, e.Message)
      End Try                                   
      ' Call parse with only AllowHexSpecifier
      ' Exception thrown because of presence of negative sign
      Try
         Console.WriteLIne(BigInteger.Parse("-3af", NumberStyles.AllowHexSpecifier, _
                                            New BigIntegerFormatProvider()))
      Catch e As FormatException
         Console.WriteLine("{0}: {1}   {2}", e.GetType().Name, vbCrLf, e.Message)
      End Try                                 
      ' Call parse with only NumberStyles.None
      ' Exception thrown because of presence of white space and sign
      Try
         Console.WriteLIne(BigInteger.Parse(" -300 ", NumberStyles.None, _
                                            New BigIntegerFormatProvider()))
      Catch e As FormatException
         Console.WriteLine("{0}: {1}   {2}", e.GetType().Name, vbCrLf, e.Message)
      End Try      
      ' <</Snippet6>                           
   End Sub
End Module

' <Snippet2>
Public Class BigIntegerFormatProvider : Implements IFormatProvider
   Public Function GetFormat(formatType As Type) As Object _
                            Implements IFormatProvider.GetFormat
      If formatType Is GetType(NumberFormatInfo) Then
         Dim numberFormat As New NumberFormatInfo
         numberFormat.NegativeSign = "~"
         Return numberFormat
      Else
         Return Nothing
      End If      
   End Function
End Class
' </Snippet2>
