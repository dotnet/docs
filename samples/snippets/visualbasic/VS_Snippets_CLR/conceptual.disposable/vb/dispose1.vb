' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()

   End Sub
End Module

Public Class Disposable : Implements IDisposable

   ' <Snippet7>
   Public Sub Dispose() _
              Implements IDisposable.Dispose
      ' Dispose of unmanaged resources.
      Dispose(True)
      ' Suppress finalization.
      GC.SuppressFinalize(Me)
   End Sub
   ' </Snippet7>

   ' <Snippet8>
   Protected Overridable Sub Dispose(disposing As Boolean)
   ' </Snippet8>   
   End Sub

End Class