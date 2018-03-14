'<Snippet1>
Imports System

Namespace InSourceSuppression
    Public Class Class1

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", _
        "CA1801:ReviewUnusedParameters", MessageId:="cmdArgs")> _
        Shared Sub Main(ByVal cmdArgs() As String)

        End Sub

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", _
        "CA1806:DoNotIgnoreMethodResults", MessageId:="System.Guid")> _
        Shared Function IsValidGuid(ByVal g As String) As Boolean
            Try
                Dim instance As New Guid(g) 'Causes CA1806: DoNotIgnoreMethodResults
                Return True
            Catch e As ArgumentNullException
            Catch e As OverflowException
            Catch e As FormatException
            End Try

            Return False
        End Function
    End Class
End Namespace
'</Snippet1>