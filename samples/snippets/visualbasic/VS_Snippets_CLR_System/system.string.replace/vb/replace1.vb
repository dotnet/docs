' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim s As String = "aaa"
      Console.WriteLine("The initial string: '{0}'", s)
      s = s.Replace("a", "b").Replace("b", "c").Replace("c", "d")
      Console.WriteLine("The final string: '{0}'", s)
   End Sub
End Module
' The example displays the following output:
'       The initial string: 'aaa'
'       The final string: 'ddd'
' </Snippet1>
