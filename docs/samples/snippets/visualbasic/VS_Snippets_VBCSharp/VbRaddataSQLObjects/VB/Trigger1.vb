'------------------------------------------------------------------------------
'<Snippet3>
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Microsoft.SqlServer.Server

Partial Public Class Triggers

    <SqlTrigger(Name:="UserNameAudit", Target:="Users", Event:="FOR INSERT")>
    Public Shared Sub UserNameAudit()

        Dim triggContext As SqlTriggerContext = SqlContext.TriggerContext()
        Dim userName As New SqlParameter("@username", SqlDbType.NVarChar)

        If triggContext.TriggerAction = TriggerAction.Insert Then

            Using conn As New SqlConnection("context connection=true")

                conn.Open()
                Dim sqlComm As New SqlCommand
                Dim sqlP As SqlPipe = SqlContext.Pipe()

                sqlComm.Connection = conn
                sqlComm.CommandText = "SELECT UserName from INSERTED"

                userName.Value = sqlComm.ExecuteScalar.ToString()

                If IsEMailAddress(userName.ToString) Then
                    sqlComm.CommandText = "INSERT UsersAudit(UserName) VALUES(username)"
                    sqlP.Send(sqlComm.CommandText)
                    sqlP.ExecuteAndSend(sqlComm)
                End If
            End Using
        End If
    End Sub


    Public Shared Function IsEMailAddress(ByVal s As String) As Boolean

        Return Regex.IsMatch(s, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function
End Class
'</Snippet3>


'------------------------------------------------------------------------------
'<Snippet8>
Partial Public Class Triggers

    <SqlTrigger(Target:="authors", Event:="FOR UPDATE")>
    Public Shared Sub AuthorsUpdateTrigger()

        '...
    End Sub
End Class
'</Snippet8>


'------------------------------------------------------------------------------
'<Snippet9>
Partial Public Class Triggers

    <SqlTrigger(Name:="trig_onpubinsert", Target:="publishers", Event:="FOR INSERT")>
    Public Shared Sub PublishersInsertTrigger()

        '...
    End Sub
End Class
'</Snippet9>
