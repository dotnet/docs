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
      
      ' Parse each string in inputs using formats and the de-DE culture.
      For Each input As String In inputs
         Try
            interval = TimeSpan.ParseExact(input, formats, culture, 
                                           TimeSpanStyles.AssumeNegative)
            Console.WriteLine("{0} --> {1:c}", input, interval)   
         Catch e As FormatException
            Console.WriteLine("{0} --> Bad Format", input)   
         Catch e As OverflowException
            Console.WriteLine("{0} --> Overflow", input)   
         End Try            
      Next
   End Sub
End Module
' The example displays the following output:
'       3 --> -03:00:00
'       16:42 --> 16:42:00
'       1:6:52:35.0625 --> Bad Format
'       1:6:52:35,0625 --> 1.06:52:35.0625000
' </Snippet4>
