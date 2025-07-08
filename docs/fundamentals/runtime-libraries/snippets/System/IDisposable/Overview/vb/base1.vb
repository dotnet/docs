' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.IO
Imports System.Runtime.InteropServices

Class BaseClass1 : Implements IDisposable
   ' Flag: Has Dispose already been called?
   Dim disposed As Boolean = False
   ' Instantiate a FileStream instance.
   Dim fs As FileStream = New FileStream("test.txt", FileMode.OpenOrCreate)

   ' Public implementation of Dispose pattern callable by consumers.
   Public Sub Dispose() _
              Implements IDisposable.Dispose
      Dispose(disposing:=True)
      GC.SuppressFinalize(Me)
   End Sub

   ' Protected implementation of Dispose pattern.
   Protected Overridable Sub Dispose(disposing As Boolean)
      If disposed Then Return

      If disposing Then
         fs.Dispose()
         ' Free any other managed objects here.
         '
      End If

      disposed = True
   End Sub
End Class
' </Snippet3>
