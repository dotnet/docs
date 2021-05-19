Class DerivedClassWithFinalizer : Inherits BaseClassWithFinalizer
    ' Flag: Has Dispose already been called?
    Dim disposed As Boolean = False

    ' Protected implementation of Dispose pattern.
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposed Then Return

        If disposing Then
            ' Free any other managed objects here.
            '
        End If

        ' Free any unmanaged objects here.
        '
        disposed = True

        ' Call the base class implementation.
        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
End Class

