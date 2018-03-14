' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Enum TemperatureScale As Integer
      Celsius
      Fahrenheit
      Kelvin
   End Enum

   Public Sub Main()
      Dim info As String = GetCurrentTemperature()
      Console.WriteLine(info)
   End Sub

   Private Function GetCurrentTemperature() As String
      Dim dat As Date = Date.Now
      Dim temp As Decimal = 20.6d
      Dim scale As TemperatureScale = TemperatureScale.Celsius
      Dim result As String 
      
      result = String.Format("At {0:t} on {1:D}, the temperature is {2:F1} {3:G}",
                             dat, temp, scale)    
      Return result
   End Function
End Module
' The example displays output like the following:
'    Unhandled Exception: System.FormatException: Format specifier was invalid.
'       at System.Number.FormatDecimal(Decimal value, String format, NumberFormatInfo info)
'       at System.Decimal.ToString(String format, IFormatProvider provider)
'       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
'       at System.String.Format(IFormatProvider provider, String format, Object[] args)
'       at Example.Main()
' </Snippet1>
