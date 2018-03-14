' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As String = { "1,034,562.91", "9 532 978,07" }
      Dim cultureNames() As String = { "en-US", "fr-FR", "" }
      
      For Each value In values
         For Each cultureName In cultureNames
            Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
            Dim name As String = If(culture.Name = "", "Invariant", culture.Name)
            Try
               Dim amount As Decimal = Decimal.Parse(value, culture)
               Console.WriteLine("'{0}' --> {1} ({2})", value, amount, name)
            Catch e As FormatException
               Console.WriteLine("'{0}': FormatException ({1})",
                                 value, name)
            End Try   
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       '1,034,562.91' --> 1034562.91 (en-US)
'       '1,034,562.91': FormatException (fr-FR)
'       '1,034,562.91' --> 1034562.91 (Invariant)
'       
'       '9 532 978,07': FormatException (en-US)
'       '9 532 978,07' --> 9532978.07 (fr-FR)
'       '9 532 978,07': FormatException (Invariant)
' </Snippet4>
