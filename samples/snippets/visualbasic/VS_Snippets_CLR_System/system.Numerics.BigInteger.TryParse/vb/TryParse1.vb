' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module Example
   Public Sub Main()
      ' <Snippet2>
      Dim numericString As String
      Dim number As BigInteger = BigInteger.Zero
      
      ' Call TryParse with default values of style and provider.
      numericString = "  -300   "
      If BigInteger.TryParse(numericString, NumberStyles.Integer,
                             Nothing, number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If                                             
      
      ' Call TryParse with the default value of style and 
      ' a provider supporting the tilde as negative sign.
      numericString = "  -300   "
      If BigInteger.TryParse(numericString, NumberStyles.Integer,
                             New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If                                             
      
      ' Call TryParse with only AllowLeadingWhite and AllowTrailingWhite.
      ' Method returns false because of presence of negative sign.
      numericString = "  -500   "
      If BigInteger.TryParse(numericString,
                          NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite,
                          New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If                                             
      
      ' Call TryParse with AllowHexSpecifier and a hex value.
      numericString = "F14237FFAAC086455192"
      If BigInteger.TryParse(numericString,
                          NumberStyles.AllowHexSpecifier,
                          Nothing, number) Then
         Console.WriteLine("'{0}' was converted to {1} (0x{1:x}).",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If                                             
      
      ' Call TryParse with AllowHexSpecifier and a negative hex value.
      ' Conversion fails because of presence of negative sign.
      numericString = "-3af"
      If BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier,
                             New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If                                             
      
      ' Call TryParse with only NumberStyles.None.
      ' Conversion fails because of presence of white space and sign.
      numericString = " -300 "
      If BigInteger.TryParse(numericString, NumberStyles.None,
                             New BigIntegerFormatProvider(), number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If 
                                                  
      ' Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
      ' Conversion fails because the string is formatted for the en-US culture.
      numericString = "9,031,425,666,123,546.00"
      If BigInteger.TryParse(numericString, NumberStyles.Any,
                             New CultureInfo("fr-FR"), number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If
      
      ' Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
      ' Conversion succeeds because the string is properly formatted 
      ' For the fr-FR culture.
      numericString = "9 031 425 666 123 546,00"
      If BigInteger.TryParse(numericString, NumberStyles.Any,
                             New CultureInfo("fr-FR"), number) Then
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number)                             
      Else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString)
      End If
      ' The example displays the following output:
      '    '  -300   ' was converted to -300.
      '    Conversion of '  -300   ' to a BigInteger failed.
      '    Conversion of '  -500   ' to a BigInteger failed.
      '    'F14237FFAAC086455192' was converted to -69613977002644837412462 (0xf14237ffaac086455192).
      '    Conversion of '-3af' to a BigInteger failed.
      '    Conversion of ' -300 ' to a BigInteger failed.
      '    Conversion of '9,031,425,666,123,546.00' to a BigInteger failed.
      '    '9 031 425 666 123 546,00' was converted to 9031425666123546.      
      ' </Snippet2>
   End Sub
End Module

' <Snippet3>
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
' </Snippet3>