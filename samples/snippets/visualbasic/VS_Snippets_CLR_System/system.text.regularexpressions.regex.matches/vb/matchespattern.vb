' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is a string."
      Dim pattern As String = "\b\w+\b"
      Dim regex As New Regex(pattern)
      
      ' <Snippet5>
      Dim match As Match = regex.Match(input)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  
      ' </Snippet5>                  
   End Sub
   
   Public Sub Main2()
      Dim input As String = "This is a string."
      Dim pattern As String = "\b\w+\b"
      Dim regex As New Regex(pattern)
      Dim startAt As Integer = 0
            
      ' <Snippet6>
      Dim match As Match = regex.Match(input, startAt)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  
      ' </Snippet6>                  
   End Sub
   
   Public Sub Main3()
      Dim input As String = "This is a string."
      Dim pattern As String = "\b\w+\b"
            
      ' <Snippet7>
      Dim match As Match = Regex.Match(input, pattern)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  
      ' </Snippet7>                  
   End Sub
   
   Public Sub Main4()
      Dim input As String = "This is a string."
      Dim pattern As String = "\b\w+\b"
      Dim options As RegexOptions = RegexOptions.None
            
      ' <Snippet8>
      Dim match As Match = Regex.Match(input, pattern, options)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  
      ' </Snippet8>                  
   End Sub

   Public Sub Main54()
      Dim input As String = "This is a string."
      Dim pattern As String = "\b\w+\b"
      Dim options As RegexOptions = RegexOptions.None
            
      ' <Snippet10>
      Try
         Dim match As Match = Regex.Match(input, pattern, options, 
                                          TimeSpan.FromSeconds(1))
         Do While match.Success
               ' Handle match here...
   
               match = match.NextMatch()
         Loop  
      Catch e As RegexMatchTimeoutException
         ' Do nothing: assume that exception represents no match.
      End Try   
      ' </Snippet10>                  
   End Sub
End Module

