Public Class DerivedClassWithFinalizer
    Inherits BaseClassWithFinalizer

    ' To detect redundant calls
    Private _disposedValue As Boolean

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not _disposedValue Then

            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO free unmanaged resources (unmanaged objects) And override a finalizer below.
            ' TODO: set large fields to null.
            _disposedValue = True
        End If

        ' Call the base class implementation.
        MyBase.Dispose(disposing)
    End Sub
End Class
