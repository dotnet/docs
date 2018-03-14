' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      Dim price As Decimal = 169.32d
      Console.WriteLine("The cost is {0:Q2}.", price)
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.FormatException: Format specifier was invalid.
'       at System.Number.FormatDecimal(Decimal value, String format, NumberFormatInfo info)
'       at System.Decimal.ToString(String format, IFormatProvider provider)
'       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
'       at System.IO.TextWriter.WriteLine(String format, Object arg0)
'       at System.IO.TextWriter.SyncTextWriter.WriteLine(String format, Object arg0)
'       at Example.Main()
' </Snippet7>

