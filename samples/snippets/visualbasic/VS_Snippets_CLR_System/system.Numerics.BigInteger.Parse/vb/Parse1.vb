' Visual Basic code for BIgInteger.Parse method
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module modMain
   Public Sub Main()
      Console.WriteLine("BigInteger.Parse(String)-------------")
      ParseString()
      Console.WriteLine("----------")
      Console.WRiteLine("BigInteger.Parse(String, NumberStyles, IFormatProvider)----------")
      ParseWithStyleAndProvider()
      Console.WriteLine()
   End Sub
   
   Private Sub ParseString()
      ' <Snippet1>
      Dim stringToParse As String = String.Empty
      Try
         ' Parse two strings.
         Dim string1, string2 As String
         string1 = "12347534159895123"
         string2 = "987654321357159852"
         stringToParse = string1
         Dim number1 As BigInteger = BigInteger.Parse(stringToParse)
         Console.WriteLine("Converted '{0}' to {1:N0}.", stringToParse, number1)
         stringToParse = string2
         Dim number2 As BigInteger = BigInteger.Parse(stringToParse)
         Console.WriteLine("Converted '{0}' to {1:N0}.", stringToParse, number2)
         ' Perform arithmetic operations on the two numbers.
         number1 *= 3
         number2 *= 2
         ' Compare the numbers.
         Select Case BigInteger.Compare(number1, number2)
            Case -1
               Console.WriteLine("{0} is greater than {1}.", number2, number1)
            Case 0
               Console.WriteLine("{0} is equal to {1}.", number1, number2)
            Case 1
               Console.WriteLine("{0} is greater than {1}.", number1, number2)
         End Select      
      Catch e As FormatException
         Console.WriteLine("Unable to parse {0}.", stringToParse)
      End Try
      ' The example displays the following output:
      '    Converted '12347534159895123' to 12,347,534,159,895,123.
      '    Converted '987654321357159852' to 987,654,321,357,159,852.
      '    1975308642714319704 is greater than 37042602479685369.      
      ' </Snippet1>     
   End Sub
      
   Private Sub ParseWithStyleAndProvider()
      ' <Snippet2>
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
      ' The example displays the following output:
      '       -300
      '       -300
      '       FormatException:
      '          The value could not be parsed.
      '       FormatException:
      '          The value could not be parsed.
      '       FormatException:
      '          The value could not be parsed.            
      ' </Snippet2>                           
   End Sub
End Module


' <Snippet4>
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
' </Snippet4>

