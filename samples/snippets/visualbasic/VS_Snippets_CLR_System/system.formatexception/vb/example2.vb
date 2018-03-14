' Visual Basic .NET Document
Option Strict On

' <Snippet2>
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
      
      result = String.Format("At {0:t} on {0:D}, the temperature is {1:F1} {2:G}",
                             dat, temp, scale)    
      Return result
   End Function
End Module
' The example displays output like the following:
'       At 10:40 AM on Wednesday, June 04, 2014, the temperature is 20.6 Celsius
' </Snippet2>
