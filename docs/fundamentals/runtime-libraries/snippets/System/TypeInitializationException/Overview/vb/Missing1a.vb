' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class InfoModule
   Private firstUse As DateTime
   Private ctr As Integer = 0

   Public Sub New(dat As DateTime)
      firstUse = dat
   End Sub
   
   Public Function Increment() As Integer
      ctr += 1
      Return ctr
   End Function
   
   Public Function GetInitializationTime() As DateTime
      Return firstUse
   End Function
End Class
' </Snippet1>

