' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b[at]\w+"
      Dim text As String = "The threaded application ate up the thread pool as it executed."
      Dim matches As MatchCollection

      Dim defaultRegex As New Regex(pattern)
      ' Get matches of pattern in text
      matches = defaultRegex.Matches(text)
      Console.WriteLine("Parsing '{0}'", text)
      ' Iterate matches
      For ctr As Integer = 0 to matches.Count - 1
         Console.WriteLine("{0}. {1}", ctr, matches(ctr).Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       Parsing 'The threaded application ate up the thread pool as it executed.'
'       0. threaded
'       1. application
'       2. ate
'       3. the
'       4. thread
'       5. as
' </Snippet1>

