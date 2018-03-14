' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports Utilities

Module Example
   Public Sub Main()
      Dim eol As String
      If StringLibrary.Version.Major >= 2 Then
         eol = StringLibrary.GetendOfLineCharacter()
      Else
         eol = vbCrLf
      End If   
      Console.Write("The first line." + eol)
      Console.Write("The second line." + eol)
   End Sub
End Module
' </Snippet4>
