' <Snippet1>
Public NotInheritable Class Foo : Implements IDisposable
    Private ReadOnly _bar As IDisposable

    Public Sub New(ByVal bar As IDisposable)
        _bar = bar
    End Sub

    Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
        If _bar IsNot Nothing Then _bar.Dispose()
    End Sub
End Class
' </Snippet1>