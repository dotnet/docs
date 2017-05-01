' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Enum Shade
   White = 0
   Gray = 1
   Grey = 1
   Black = 2
End Enum
' </Snippet1>

Module Example
   Public Sub Main()
      CallDefault()
      CallWithFormatString()
   End Sub
   
   Private Sub CallDefault()   
      ' <Snippet2>
      Dim shadeName As String = CType(1, Shade).ToString()      
      ' </Snippet2>
      Console.WriteLine(shadeName)
   End Sub
   
   Private Sub CallWithFormatString()
      ' <Snippet3>
      Dim shadeName As String = CType(1, Shade).ToString("F")
      ' </Snippet3>
      Console.WriteLine(shadeName)
   End Sub
End Module

