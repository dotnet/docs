Public NotInheritable Class Foo
    Implements IDisposable

    Private ReadOnly _bar As IDisposable

    Public Sub New()
        _bar = New Bar()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        _bar.Dispose()
    End Sub
End Class
