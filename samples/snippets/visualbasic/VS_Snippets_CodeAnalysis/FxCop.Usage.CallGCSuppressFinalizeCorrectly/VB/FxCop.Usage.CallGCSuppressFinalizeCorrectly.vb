'<Snippet1>
Imports System
Imports System.Data.SqlClient

Namespace Samples

    Public Class DatabaseConnector
        Implements IDisposable

        Private _Connection As New SqlConnection

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(True)   ' Violates rules
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

End Namespace
'</Snippet1>


