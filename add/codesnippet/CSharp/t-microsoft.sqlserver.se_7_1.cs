[SqlTrigger(Name = @"UsersAudit", Target = "[dbo].[users]", Event = "FOR INSERT")]
public static void UsersAudit()
{
   // Get the trigger context.
   string userName;
   string realName;
   SqlCommand command;
   SqlTriggerContext triggContext = SqlContext.TriggerContext;
   SqlDataReader reader;
   
   switch (triggContext.TriggerAction)
   {
      case TriggerAction.Insert:

      // Retrieve the connection that the trigger is using.
      using (SqlConnection connection
         = new SqlConnection(@"context connection=true"))
      {
         connection.Open();
 
         // Get the inserted row.
         command = new SqlCommand(@"SELECT * FROM INSERTED;",
                                  connection);

         // Get the user name and real name of the inserted user.
         reader = command.ExecuteReader();
         reader.Read();
         userName = (string)reader[0];
         realName = (string)reader[1];
         reader.Close();

         // Insert the user name and real name into the auditing table.
         command = new SqlCommand(@"INSERT [dbo].[UserNameAudit] (userName, realName) " 
                  + @"VALUES (@userName, @realName);", connection);

         command.Parameters.Add(new SqlParameter("@userName", userName));
         command.Parameters.Add(new SqlParameter("@realName", realName));
               
         command.ExecuteNonQuery();               
            
      }
         
      break;
   }
}