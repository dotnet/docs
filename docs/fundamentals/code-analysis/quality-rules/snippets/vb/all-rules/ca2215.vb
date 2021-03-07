Namespace ca2215

    Public Class TypeA
        Implements IDisposable

        Protected Overridable Overloads Sub Dispose(disposing As Boolean)
            If disposing Then
                ' dispose managed resources
            End If
            
            ' free native resources

        End Sub ' Dispose

        Public Overloads Sub Dispose() Implements IDisposable.Dispose

            Dispose(True)
            GC.SuppressFinalize(Me)

        End Sub ' Dispose

        ' Disposable types implement a finalizer.
        Protected Overrides Sub Finalize()

            Dispose(False)
            MyBase.Finalize()

        End Sub ' Finalize

    End Class

    Public Class TypeB
        Inherits TypeA

        Protected Overrides Sub Dispose(disposing As Boolean)

            If Not disposing Then
                MyBase.Dispose(False)
            End If

        End Sub ' Dispose

    End Class

End Namespace
