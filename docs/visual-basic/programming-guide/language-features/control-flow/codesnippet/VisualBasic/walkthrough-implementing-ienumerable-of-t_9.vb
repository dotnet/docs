    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' Dispose of managed resources.
            End If
            _current = Nothing
            _sr.Close()
            _sr.Dispose()
        End If

        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub