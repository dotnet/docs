' Visual Basic .NET Document
Option Strict On

' <Snippet1>
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
                           Array.Exists(names, AddressOf (New StringSearcher(charToFind)).StartsWith))
      Next
   End Sub
   
End Module

Public Class StringSearcher
   Dim firstChar As Char
   
   Public Sub New(firstChar As Char)
      Me.firstChar = Char.ToUpper(firstChar)
   End Sub
   
   Public Function StartsWith(s As String) As Boolean
      If String.IsNullOrEmpty(s) Then Return False
      
      If s.Substring(0, 1).ToUpper = firstChar Then
         Return True
      Else
         Return False
      End If
   End Function
End Class
' The example displays the following output:
'       One or more names begin with 'A': True
'       One or more names begin with 'K': False
'       One or more names begin with 'W': True
'       One or more names begin with 'Z': False
' </Snippet1>
