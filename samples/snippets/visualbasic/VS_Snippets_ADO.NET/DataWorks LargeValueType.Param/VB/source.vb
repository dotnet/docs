Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()

        ' Supply any valid DocumentID value.
        ' The value 3 is supplied for demonstration purposes.
        Dim summaryString As String = GetDocumentSummary(3)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Function GetDocumentSummary( _
      ByVal documentID As Integer) As String

        ' Assumes GetConnectionString returns a valid connection string.
        Using connection As New SqlConnection(GetConnectionString())
            connection.Open()
            Dim command As SqlCommand = connection.CreateCommand()

            ' Setup the command to execute the stored procedure.
            command.CommandText = "GetDocumentSummary"
            command.CommandType = CommandType.StoredProcedure

            ' Set up the input parameter for the DocumentID.
            Dim paramID As SqlParameter = _
                New SqlParameter("@DocumentID", SqlDbType.Int)
            paramID.Value = documentID
            command.Parameters.Add(paramID)

            ' Set up the output parameter to retrieve the summary.
            Dim paramSummary As SqlParameter = _
                New SqlParameter("@DocumentSummary", _
                   SqlDbType.NVarChar, -1)
            paramSummary.Direction = ParameterDirection.Output
            command.Parameters.Add(paramSummary)

            ' Execute the stored procedure.
            command.ExecuteNonQuery()
            Console.WriteLine(paramSummary.Value)
            Return paramSummary.Value.ToString
        End Using
    End Function
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
