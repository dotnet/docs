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