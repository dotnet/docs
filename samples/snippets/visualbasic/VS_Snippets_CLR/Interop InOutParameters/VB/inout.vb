' <Snippet1>
Imports System.Runtime.InteropServices


' Declare a class member for each structure element.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
Public Class OpenFileName

   Public structSize As Integer = 0
   Public filter As String = Nothing
   Public file As String = Nothing
   ' ...

End Class 'OpenFileName

Public Class LibWrap
   ' Declare managed prototype for the unmanaged function.
   Declare Unicode Function GetOpenFileName Lib "Comdlg32.dll" ( _
      <[In](), Out()> ByVal ofn As OpenFileName) As Boolean
End Class 'LibWrap

Public Class App
    Public Shared Sub Main()

    End Sub 'Main
End Class 'App

' </Snippet1>