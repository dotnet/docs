' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim names() As String = { "Adam", "Adel", "Bridgette", "Carla",
                                "Charles", "Daniel", "Elaine", "Frances",
                                "George", "Gillian", "Henry", "Irving",
                                "James", "Janae", "Lawrence", "Miguel",
                                "Nicole", "Oliver", "Paula", "Robert",
                                "Stephen", "Thomas", "Vanessa",
                                "Veronica", "Wilberforce" }
      Dim charsToFind() As Char = { "A"c, "K"c, "W"c, "Z"c }

      For Each charToFind In charsToFind
         Console.WriteLine("One or more names begin with '{0}': {1}",
                           charToFind,
                           Array.Exists(names, Function(s)
                                                  If String.IsNullOrEmpty(s) Then Return False

                                                  If s.Substring(0, 1).ToUpper = charToFind Then
                                                     Return True
                                                  Else
                                                     Return False
                                                  End If
                                               End Function ))
      Next
   End Sub
End Module
' The example displays the following output:
'       One or more names begin with 'A': True
'       One or more names begin with 'K': False
'       One or more names begin with 'W': True
'       One or more names begin with 'Z': False
' </Snippet2>