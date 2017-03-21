<SqlTrigger(Name:="TableAudit", Target:="[dbo].[Users]", Event:="FOR INSERT, DELETE")> _
Public Shared Sub TableAudit()
    Dim command As SqlCommand
    Dim triggContext As Microsoft.SqlServer.Server.SqlTriggerContext
    Dim reader As SqlDataReader

    triggContext = SqlContext.TriggerContext

    Select Case triggContext.TriggerAction

        ' Insert.
        Case TriggerAction.Insert
            Using connection As New SqlConnection("context connection=true")

                ' Open the context connection.
                connection.Open()

                ' Get the inserted row.
                command = New SqlCommand("SELECT * FROM INSERTED;", connection)
                reader = command.ExecuteReader()
                reader.Read()

                ' Retrieve data from inserted row.

                reader.Close()
            End Using

        ' Delete.
        Case TriggerAction.Delete
            Using connection As New SqlConnection("context connection=true")

            ' Open the context connection.
            connection.Open()

            ' Get the deleted rows.
            command = New SqlCommand("SELECT * FROM DELETED;", connection)

            reader = command.ExecuteReader()

            If reader.HasRows Then

                While reader.Read()

                    ' Retrieve data from deleted rows

                End While

                reader.Close()

           Else
               ' No rows affected.
           End If

       End Using
    End Select
End Sub 