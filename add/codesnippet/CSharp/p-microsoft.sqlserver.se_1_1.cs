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