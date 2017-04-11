' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim s As New String("a"c, 3)
      Console.WriteLine("The initial string: '{0}'", s)
      s = s.Replace("a"c, "b"c).Replace("b"c, "c"c).Replace("c"c, "d"c)
      Console.WriteLine("The final string: '{0}'", s)
   End Sub
End Module
' The example displays the following output:
'       The initial string: 'aaa'
'       The final string: 'ddd'
' </Snippet2>
