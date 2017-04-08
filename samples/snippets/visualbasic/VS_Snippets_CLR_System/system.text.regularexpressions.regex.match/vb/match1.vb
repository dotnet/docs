
' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "ablaze beagle choral dozen elementary fanatic " +
                            "glaze hunger inept jazz kitchen lemon minus " +
                            "night optical pizza quiz restoration stamina " +
                            "train unrest vertical whiz xray yellow zealous"
      Dim pattern As String = "\b\w*z+\w*\b"
      Dim m As Match = Regex.Match(input, pattern)
      Do While m.Success 
         Console.WriteLine("'{0}' found at position {1}", m.Value, m.Index)
         m = m.NextMatch()
      Loop                      
   End Sub
End Module
' The example displays the following output:
    'ablaze' found at position 0
    'dozen' found at position 21
    'glaze' found at position 46
    'jazz' found at position 65
    'pizza' found at position 104
    'quiz' found at position 110
    'whiz' found at position 157
    'zealous' found at position 174
' </Snippet1>