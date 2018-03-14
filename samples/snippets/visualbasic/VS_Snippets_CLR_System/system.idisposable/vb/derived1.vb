' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Class DerivedClass : Inherits BaseClass 
   ' Flag: Has Dispose already been called?
   Dim disposed As Boolean = False
   ' Instantiate a SafeHandle instance.
   Dim handle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)

   ' Protected implementation of Dispose pattern.
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposed Then Return
      
      If disposing Then
         handle.Dispose()
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

Class BaseClass : Implements IDisposable
   ' Flag: Has Dispose already been called?
   Dim disposed As Boolean = False
   
   ' Public implementation of Dispose pattern callable by consumers.
   Public Sub Dispose() _
              Implements IDisposable.Dispose
      Dispose(True)
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

