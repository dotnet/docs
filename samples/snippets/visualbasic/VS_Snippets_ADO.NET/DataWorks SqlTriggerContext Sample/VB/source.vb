Option Explicit

Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

'The Partial modifier is only required on one class definition per project.
Partial Public Class CLRTriggers 
 
' <Snippet1>   
<SqlTrigger(Name:="UsersAudit", Target:="[dbo].[users]", Event:="FOR INSERT")> _
Public Shared Sub UsersAudit()
        
   Dim command As SqlCommand
   Dim triggContext As SqlTriggerContext
   Dim reader As SqlDataReader
   Dim userName As String
   Dim realName As String

         
   ' Get the trigger context.
   triggContext = SqlContext.TriggerContext        

   Select Case triggContext.TriggerAction
           
      Case TriggerAction.Insert

         ' Retrieve the connection that the trigger is using.
         Using connection As New SqlConnection("context connection=true")
            connection.Open()

            ' Get the inserted row.
            command = new SqlCommand("SELECT * FROM INSERTED;", connection)
            
            ' Get the user name and real name of the inserted user.                
            reader = command.ExecuteReader()
            reader.Read()
            userName = CType(reader(0), String)
            realName = CType(reader(1), String)

            reader.Close()

            ' Insert the user name and real name into the auditing table.
            command = New SqlCommand("INSERT [dbo].[UserNameAudit] (userName, realName) " & _
               "VALUES (@userName, @realName);", connection)

            command.Parameters.Add(new SqlParameter("@userName", userName))
            command.Parameters.Add(new SqlParameter("@realName", realName))
                 
            command.ExecuteNonQuery()
                 
          End Using
         
   End Select

End Sub
'</Snippet1>

'<Snippet2>
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
'</Snippet2>

End Class
