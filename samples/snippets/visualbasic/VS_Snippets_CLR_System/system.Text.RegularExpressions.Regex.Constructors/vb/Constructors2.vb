' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b[at]\w+"
      Dim options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.Compiled
      Dim text As String = "The threaded application ate up the thread pool as it executed."
      Dim matches As MatchCollection

      Dim optionRegex As New Regex(pattern, options)
      Console.WriteLine("Parsing '{0}' with options {1}:", text, options.ToString())
      ' Get matches of pattern in text
      matches = optionRegex.Matches(text)
      ' Iterate matches   
      For ctr As Integer = 0 to matches.Count - 1
         Console.WriteLine("{0}. {1}", ctr, matches(ctr).Value)
      Next
   End Sub
End Module
' The example displays the following output:
'    Parsing 'The threaded application ate up the thread pool as it executed.'
'       with options IgnoreCase, Compiled:
'    0. The
'    1. threaded
'    2. application
'    3. ate
'    4. the
'    5. thread
'    6. as
' </Snippet2>
