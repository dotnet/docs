' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.IO
Imports System.Runtime.InteropServices

Class DerivedClass2 : Inherits BaseClass2
   ' Flag: Has Dispose already been called?
   Dim disposed As Boolean = False
   ' Instantiate a FileStream instance.
   Dim fs As FileStream = New FileStream("test.txt", FileMode.OpenOrCreate)

   ' Protected implementation of Dispose pattern.
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposed Then Return

      If disposing Then
         fs.Dispose()
         ' Free any other managed objects here.
         '
      End If

      ' Free any unmanaged objects here.
      '
      disposed = True

      ' Call base class implementation.
      MyBase.Dispose(disposing)
   End Sub
End Class
' </Snippet4>

Class BaseClass2 : Implements IDisposable
   ' Flag: Has Dispose already been called?
   Dim disposed As Boolean = False

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
         ' Free any other managed objects here.
         '
      End If

      ' Free any unmanaged objects here.
      '
      disposed = True
   End Sub
End Class

