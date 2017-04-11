' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module modMain
   Public Sub Main()
      TryParse1
      Console.WriteLine()
      TryParse2
   End Sub
   
   Private Sub TryParse1()
      ' <Snippet1>
      Dim number1 As BigInteger = BigInteger.Zero
      Dim number2 As BigInteger = BigInteger.Zero
      Dim succeeded1 As Boolean = BigInteger.TryParse("-12347534159895123", number1)
      Dim succeeded2 As Boolean = BigInteger.TryParse("987654321357159852", number2)
      If succeeded1 AndAlso succeeded2
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
      Else
         If Not succeeded1 Then 
            Console.WriteLine("Unable to initialize the first BigInteger value.")
         End If
         If Not succeeded2 Then
            Console.WriteLine("Unable to initialize the second BigInteger value.")
         
         End If
      End If
      ' The example displays the following output:
      '      1975308642714319704 is greater than -37042602479685369.
      ' </Snippet1>     
   End Sub
   
   Private Sub TryParse2()
      ' <Snippet2>
      Dim numericString As String
      Dim number As BigInteger = BigInteger.Zero

      ' Call parse with default values of style and provider
      numericString = "  -300   "
      If BigInteger.TryParse(numericString, NumberStyles.Integer, _
                             CultureInfo.CurrentCulture, number) Then
         Console.WriteLine("The string '{0}' parses to {1}", _
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", _
                           numericString)
      End If                                             

      ' Call parse with default values of style and provider supporting tilde as negative sign
      numericString = "  -300   "
      If BigInteger.TryParse(numericString, NumberStyles.Integer, _
                             New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("The string '{0}' parses to {1}", _
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", _
                           numericString)
      End If                                             
                             
      ' Call parse with only AllowLeadingWhite and AllowTrailingWhite
      ' Method returns false because of presence of negative sign
      numericString = "  -500   "
      If BigInteger.TryParse(numericString, _
                          NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite, _
                          New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("The string '{0}' parses to {1}", _
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", _
                           numericString)
      End If                                             
                          
      ' Call parse with AllowHexSpecifier and a hex value
      numericString = "FFAAC086455192"
      If BigInteger.TryParse(numericString, _
                          NumberStyles.AllowHexSpecifier, _
                          Nothing, number) Then
         Console.WriteLine("The string '{0}' parses to {1}, or 0x{1:x}.", _
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", _
                           numericString)
      End If                                             
      
      ' Call parse with AllowHexSpecifier and a negative hex value
      ' Conversion fails because of presence of negative sign
      numericString = "-3af"
      If BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, _
                             New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("The string '{0}' parses to {1}.", _
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", _
                           numericString)
      End If                                             

      ' Call parse with only NumberStyles.None
      ' Exception thrown because of presence of white space and sign
      numericString = " -300 "
      If BigInteger.TryParse(numericString, NumberStyles.None, _
                             New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("The string '{0}' parses to {1}", _
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", _
                           numericString)
      End If                                             
      ' <</Snippet2>                           
   End Sub
End Module

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
