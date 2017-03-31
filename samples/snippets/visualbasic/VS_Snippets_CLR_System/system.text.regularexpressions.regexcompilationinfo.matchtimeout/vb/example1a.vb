' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports CustomRegexes
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim rgx As New DuplicateChars(TimeSpan.FromSeconds(.5))
      
      Dim values() As String = { "Greeeeeat", "seed", "deed", "beam", 
                                 "loop", "Aardvark" }
      ' Display regex information.
      Console.WriteLine("Regular Expression Pattern: {0}", rgx)
      Console.WriteLine("Regex timeout value: {0} seconds", 
                        rgx.MatchTimeout.TotalSeconds)
      Console.WriteLine()
      
      ' Display matching information.
      For Each value In values
         Dim m As Match = rgx.Match(value)
         If m.Success Then
            Console.WriteLine("'{0}' found in '{1}' at positions {2}-{3}",
                              m.Value, value, m.Index, m.Index + m.Length - 1)
         Else
            Console.WriteLine("No match found in '{0}'", value)
         End If   
      Next                                                         
   End Sub
End Module
' The example displays the following output:
'       Regular Expression Pattern: (\w)\1+
'       Regex timeout value: 0.5 seconds
'       
'       'eeeee' found in 'Greeeeeat' at positions 2-6
'       'ee' found in 'seed' at positions 1-2
'       'ee' found in 'deed' at positions 1-2
'       No match found in 'beam'
'       'oo' found in 'loop' at positions 1-2
'       'Aa' found in 'Aardvark' at positions 0-1
' </Snippet2>
