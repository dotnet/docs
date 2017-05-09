' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As String = { " 214309 ", "1,064,181", "(0)", "10241+", _
                                 " + 21499 ", " +21499 ", "122153.00", _
                                 "1e03ff", "91300.0e-2" }
      Dim whitespace As NumberStyles =  NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite
      Dim styles() As NumberStyles = { NumberStyles.None, _
                                       whitespace, _
                                       NumberStyles.AllowLeadingSign Or NumberStyles.AllowTrailingSign Or whitespace, _
                                       NumberStyles.AllowThousands Or NumberStyles.AllowCurrencySymbol, _
                                       NumberStyles.AllowExponent Or NumberStyles.AllowDecimalPoint }

      ' Attempt to convert each number using each style combination.
      For Each value As String In values
         Console.WriteLine("Attempting to convert '{0}':", value)
         For Each style As NumberStyles In styles
            Try
               Dim number As UInteger = UInt32.Parse(value, style)
               Console.WriteLine("   {0}: {1}", style, number)
            Catch e As FormatException
               Console.WriteLine("   {0}: Bad Format", style)
            Catch e As OverflowException
               Console.WriteLine("   {0}: Overflow", value)         
            End Try         
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    Attempting to convert ' 214309 ':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: 214309
'       Integer, AllowTrailingSign: 214309
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '1,064,181':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: 1064181
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '(0)':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '10241+':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: 10241
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert ' + 21499 ':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert ' +21499 ':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: 21499
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '122153.00':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: 122153
'    
'    Attempting to convert '1e03ff':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '91300.0e-2':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: 913
' </Snippet2>
