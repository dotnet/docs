using System;
using System.Data;
using System.Data.Sql;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using System.Text.RegularExpressions;

public class CLRTriggers
{

// <Snippet1>
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
//</Snippet1>

//<Snippet2>
[SqlTrigger(Name = @"TableAudit", Target = "[dbo].[Users]", Event = "FOR INSERT, DELETE")]
public static void TableAudit()
{
    SqlCommand command = new SqlCommand();
    SqlTriggerContext triggContext = SqlContext.TriggerContext;
    SqlDataReader reader;

    switch (triggContext.TriggerAction)
    {
        // Insert.
        case TriggerAction.Insert:

            using (SqlConnection connection
                   = new SqlConnection(@"context connection=true"))
            {
                // Open the context connection.
                connection.Open();

                // Get the inserted row.
                command = new SqlCommand(@"SELECT * FROM INSERTED;",
                                         connection);
                reader = command.ExecuteReader();
                reader.Read();

                // Retrieve data from inserted row.

                reader.Close();
            }
            break;

        // Delete.
        case TriggerAction.Delete:
            using (SqlConnection connection
                   = new SqlConnection(@"context connection=true"))
            {
                // Open the context connection.
                connection.Open();

                // Get the deleted rows.
                command = new SqlCommand(@"SELECT * FROM DELETED;",
                                         connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Retrieve data from deleted rows.
                    }

                    reader.Close();

                }
                else
                {
                    // No rows affected.
                }
            }

            break;
    }
}
//</Snippet2>
}
