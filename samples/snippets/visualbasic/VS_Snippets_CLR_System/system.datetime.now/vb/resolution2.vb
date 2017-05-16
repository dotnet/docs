' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.Threading

Module Example
   Public Sub Main()
      Dim output As String = ""
      For ctr As Integer = 0 To 20
         output += Date.Now.Millisecond.ToString() + vbCrLf
         ' Introduce a delay loop.
         For delay As Integer = 0 To 1000
         Next

         If ctr = 10 Then
            output += "Thread.Sleep called..." + vbCrLf
            Thread.Sleep(5)
         End If
      Next
      Console.WriteLine(output)
   End Sub
End Module
' The example displays output like the following:
'       111
'       111
'       111
'       111
'       111
'       111
'       111
'       111
'       111
'       111
'       111
'       Thread.Sleep called...
'       143
'       143
'       143
'       143
'       143
'       143
'       143
'       143
'       143
'       143
' </Snippet1>
