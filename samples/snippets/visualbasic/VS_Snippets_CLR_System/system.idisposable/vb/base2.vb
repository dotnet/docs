Public Class BaseClassWithFinalizer
    Implements IDisposable

    ' To detect redundant calls
    Private _disposedValue As Boolean

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() _
               Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not _disposedValue Then

            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO free unmanaged resources (unmanaged objects) And override finalizer
            ' TODO: set large fields to null
            _disposedValue = True
        End If
    End Sub
End Class
