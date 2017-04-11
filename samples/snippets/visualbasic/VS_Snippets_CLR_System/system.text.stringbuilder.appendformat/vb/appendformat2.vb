' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text

Module Example
   Public Sub Main()
      Dim culture As New CultureInfo("en-US")
      Dim sb As New StringBuilder()
      Dim temperatureInfo As New Dictionary(Of Date, Double) 
      temperatureInfo.Add(#6/1/2010 2:00PM#, 87.46)
      temperatureInfo.Add(#12/1/2010 10:00AM#, 36.81)
      
      sb.AppendLine("Temperature Information:").AppendLine()
      For Each item In temperatureInfo
         sb.AppendFormat(culture,
                         "Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F",
                         item.Key, item.Value).AppendLine()
      Next
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays the following output:
'       Temperature Information:
'       
'       Temperature at  2:00 PM on  6/1/2010:  87.5°F
'       Temperature at 10:00 AM on 12/1/2010:  36.8°F
' </Snippet3>
