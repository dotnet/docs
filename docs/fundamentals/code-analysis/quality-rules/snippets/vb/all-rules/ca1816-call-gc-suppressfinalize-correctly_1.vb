Imports System
Imports System.Data.SqlClient

Namespace ca1816

    '<snippet1>
    Public Class DatabaseConnector
        Implements IDisposable

        Private _Connection As New SqlConnection

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            ' Violates rules
            GC.SuppressFinalize(True)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If _Connection IsNot Nothing Then
                    _Connection.Dispose()
                    _Connection = Nothing
                End If
            End If
        End Sub

    End Class
    '</snippet1>

End Namespace

Namespace ca1816_2
    '<snippet2>
    Public Class DatabaseConnector
        Implements IDisposable

        Private _Connection As New SqlConnection

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If _Connection IsNot Nothing Then
                    _Connection.Dispose()
                    _Connection = Nothing
                End If
            End If
        End Sub

    End Class
    '</snippet2>

End Namespace
