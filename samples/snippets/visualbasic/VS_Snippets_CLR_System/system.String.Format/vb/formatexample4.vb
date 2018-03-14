' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet6>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim temperatureInfo As New Dictionary(Of Date, Double) 
      temperatureInfo.Add(#6/1/2010 2:00PM#, 87.46)
      temperatureInfo.Add(#12/1/2010 10:00AM#, 36.81)
      
      Console.WriteLine("Temperature Information:")
      Console.WriteLine()
      Dim output As String   
      For Each item In temperatureInfo
         output = String.Format("Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F", _
                                item.Key, item.Value)
         Console.WriteLine(output)
      Next
   End Sub
End Module
' The example displays the following output:
'       Temperature Information:
'       
'       Temperature at  2:00 PM on  6/1/2010:  87.5°F
'       Temperature at 10:00 AM on 12/1/2010:  36.8°F
' </Snippet6>
