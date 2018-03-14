' <Snippet4>
Imports System.Globalization

Module Example
    Public Sub Main()
      ' Define an array of string values.
      Dim values() As String = { " 987.654E-2", " 987,654E-2", _
                                 "(98765,43210)", "9,876,543.210",  _
                                 "9.876.543,210",  "98_76_54_32,19" }
      ' Create a custom culture based on the invariant culture.
      Dim ci As New CultureInfo("")
      ci.NumberFormat.NumberGroupSizes = New Integer() { 2 }
      ci.NumberFormat.NumberGroupSeparator = "_"
      
      ' Define an array of format providers.
      Dim providers() As CultureInfo = { New CultureInfo("en-US"), _
                                             New CultureInfo("nl-NL"), ci }       
      
      ' Define an array of styles.
      Dim styles() As NumberStyles = { NumberStyles.Currency, NumberStyles.Float }
      
      ' Iterate the array of format providers.
      For Each provider As CultureInfo In providers
         Console.WriteLine("Parsing using the {0} culture:", _
                           If(provider.Name = String.Empty, "Invariant", provider.Name))
         ' Parse each element in the array of string values.
         For Each value As String In values
            For Each style As NumberStyles In styles
               Try
                  Dim number As Single = Single.Parse(value, style, provider)            
                  Console.WriteLine("   {0} ({1}) -> {2}", _
                                    value, style, number)
               Catch e As FormatException
                  Console.WriteLine("   '{0}' is invalid using {1}.", value, style)            
               Catch e As OverflowException
                  Console.WriteLine("   '{0}' is out of the range of a Single.", value)
               End Try 
            Next            
         Next         
         Console.WriteLine()
      Next
   End Sub   
End Module 
' The example displays the following output:
'       Parsing using the en-US culture:
'          ' 987.654E-2' is invalid using Currency.
'           987.654E-2 (Float) -> 9.87654
'          ' 987,654E-2' is invalid using Currency.
'          ' 987,654E-2' is invalid using Float.
'          (98765,43210) (Currency) -> -9.876543E+09
'          '(98765,43210)' is invalid using Float.
'          9,876,543.210 (Currency) -> 9876543
'          '9,876,543.210' is invalid using Float.
'          '9.876.543,210' is invalid using Currency.
'          '9.876.543,210' is invalid using Float.
'          '98_76_54_32,19' is invalid using Currency.
'          '98_76_54_32,19' is invalid using Float.
'       
'       Parsing using the nl-NL culture:
'          ' 987.654E-2' is invalid using Currency.
'          ' 987.654E-2' is invalid using Float.
'          ' 987,654E-2' is invalid using Currency.
'           987,654E-2 (Float) -> 9.87654
'          (98765,43210) (Currency) -> -98765.43
'          '(98765,43210)' is invalid using Float.
'          '9,876,543.210' is invalid using Currency.
'          '9,876,543.210' is invalid using Float.
'          9.876.543,210 (Currency) -> 9876543
'          '9.876.543,210' is invalid using Float.
'          '98_76_54_32,19' is invalid using Currency.
'          '98_76_54_32,19' is invalid using Float.
'       
'       Parsing using the Invariant culture:
'          ' 987.654E-2' is invalid using Currency.
'           987.654E-2 (Float) -> 9.87654
'          ' 987,654E-2' is invalid using Currency.
'          ' 987,654E-2' is invalid using Float.
'          (98765,43210) (Currency) -> -9.876543E+09
'          '(98765,43210)' is invalid using Float.
'          9,876,543.210 (Currency) -> 9876543
'          '9,876,543.210' is invalid using Float.
'          '9.876.543,210' is invalid using Currency.
'          '9.876.543,210' is invalid using Float.
'          98_76_54_32,19 (Currency) -> 9.876543E+09
'          '98_76_54_32,19' is invalid using Float.
' </Snippet4>
