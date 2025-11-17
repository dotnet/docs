Imports System.IO

Namespace ca1816

    '<snippet1>
    Public Class MyStreamClass
        Implements IDisposable

        Private _stream As New MemoryStream

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            ' Violates rule.
            GC.SuppressFinalize(True)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If _stream IsNot Nothing Then
                    _stream.Dispose()
                    _stream = Nothing
                End If
            End If
        End Sub

    End Class
    '</snippet1>

End Namespace

Namespace ca1816_2
    '<snippet2>
    Public Class MyStreamClass
        Implements IDisposable

        Private _stream As New MemoryStream

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If _stream IsNot Nothing Then
                    _stream.Dispose()
                    _stream = Nothing
                End If
            End If
        End Sub

    End Class
    '</snippet2>

End Namespace
