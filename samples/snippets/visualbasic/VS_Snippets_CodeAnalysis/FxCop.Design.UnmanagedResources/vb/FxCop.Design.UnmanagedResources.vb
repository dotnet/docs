'<Snippet1>
Imports System

Namespace DesignLibrary

    Public Class UnmanagedResources
        Implements IDisposable

       Dim unmanagedResource As IntPtr
       Dim disposed As Boolean = False

       Sub New 
           ' Allocate the unmanaged resource ...
       End Sub

       Overloads Sub Dispose() Implements IDisposable.Dispose
           Dispose(True)
           GC.SuppressFinalize(Me)
       End Sub

       Protected Overloads Overridable Sub Dispose(disposing As Boolean)
           If Not(disposed) Then

               If(disposing) Then
                   ' Release managed resources.
               End If

               ' Free the unmanaged resource ...

               unmanagedResource = IntPtr.Zero

               disposed = True

           End If
       End Sub

       Protected Overrides Sub Finalize()
           Dispose(False)
       End Sub

    End Class

End Namespace
'</Snippet1>
