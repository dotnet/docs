Module Program
    Sub Main()
        Using a As New DisposableDerived
        End Using

        Using b As New DisposableDerivedWithFinalizer
            b.Dispose()
        End Using

        Using c As New DisposableBaseWithSafeHandle
        End Using
    End Sub
End Module
