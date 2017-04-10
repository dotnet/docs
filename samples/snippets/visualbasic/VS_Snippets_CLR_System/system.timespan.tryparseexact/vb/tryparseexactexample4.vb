' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim inputs() As String = { "3", "16:42", "1:6:52:35.0625", 
                                 "1:6:52:35,0625" } 
      Dim formats() As String = { "%h", "g", "G" }
      Dim interval As TimeSpan
      Dim culture As New CultureInfo("de-DE")
      
      ' Parse each string in inputs using formats and the fr-FR culture.
      For Each input As String In inputs
         If TimeSpan.TryParseExact(input, formats, culture, 
                                   TimeSpanStyles.AssumeNegative, interval) Then
            Console.WriteLine("{0} --> {1:c}", input, interval)   
         Else
            Console.WriteLine("Unable to parse {0}", input)   
         End If            
      Next
   End Sub
End Module
' The example displays the following output:
'       3 --> -03:00:00
'       16:42 --> 16:42:00
'       Unable to parse 1:6:52:35.0625
'       1:6:52:35,0625 --> 1.06:52:35.0625000
' </Snippet4>
