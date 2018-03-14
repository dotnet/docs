' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As String = { " 214 ", "1,064", "(0)", "1241+", " + 214 ", " +214 ", "2153.0", "1e03", "1300.0e-2" }
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
               Dim number As UShort = UInt16.Parse(value, style)
               Console.WriteLine("   {0}: {1}", style, number)
            Catch e As FormatException
               Console.WriteLine("   {0}: Bad Format", style)
            End Try         
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'    Attempting to convert ' 214 ':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: 214
'       Integer, AllowTrailingSign: 214
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '1,064':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: 1064
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '(0)':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '1241+':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: 1241
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert ' + 214 ':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert ' +214 ':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: 214
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: Bad Format
'    
'    Attempting to convert '2153.0':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: 2153
'    
'    Attempting to convert '1e03':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: 1000
'    
'    Attempting to convert '1300.0e-2':
'       None: Bad Format
'       AllowLeadingWhite, AllowTrailingWhite: Bad Format
'       Integer, AllowTrailingSign: Bad Format
'       AllowThousands, AllowCurrencySymbol: Bad Format
'       AllowDecimalPoint, AllowExponent: 13
' </Snippet6>
