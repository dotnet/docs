' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "deceive relieve achieve belief fierce receive"
      Dim pattern As String = "\w*(ie|ei)\w*"
      Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
      Console.WriteLine("Original string: " + input)
      
      Dim result As String = rgx.Replace(input, AddressOf ReverseLetter, 
                                           input.Split(" "c).Length \ 2)
      Console.WriteLine("Returned string: " + result)
   End Sub

   Public Function ReverseLetter(match As Match) As String
      Return Regex.Replace(match.Value, "([ie])([ie])", "$2$1", 
                           RegexOptions.IgnoreCase)            
   End Function
End Module
' The example displays the following output:
'    Original string: deceive relieve achieve belief fierce receive
'    Returned string: decieve releive acheive belief fierce receive
' </Snippet11>

