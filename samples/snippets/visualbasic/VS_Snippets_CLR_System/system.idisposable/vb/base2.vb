﻿Class BaseClassWithFinalizer : Implements IDisposable
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

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
End Class
