    static private string CreateSqlParameters(int documentID)
    {
        // Assumes GetConnectionString returns a valid connection string to the
        // AdventureWorks sample database on an instance of SQL Server 2005.
        using (SqlConnection connection =
                   new SqlConnection(GetConnectionString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            try
            {
                // Setup the command to execute the stored procedure.
                command.CommandText = "GetDocumentSummary";
                command.CommandType = CommandType.StoredProcedure;

                // Create the input parameter for the DocumentID.
                SqlParameter paramID =
                    new SqlParameter("@DocumentID", SqlDbType.Int);
                paramID.Value = documentID;
                command.Parameters.Add(paramID);

                // Create the output parameter to retrieve the summary.
                SqlParameter paramSummary =
                    new SqlParameter("@DocumentSummary", SqlDbType.NVarChar, -1);
                paramSummary.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramSummary);

                // List the parameters and some of properties.
                SqlParameterCollection paramCollection = command.Parameters;
                string parameterList = "";
                for (int i = 0; i < paramCollection.Count; i++)
                {
                    parameterList += String.Format("  {0}, {1}, {2}\n",
                        paramCollection[i], paramCollection[i].DbType,
                        paramCollection[i].Direction);
                }
                Console.WriteLine("Parameter Collection:\n" + parameterList);

                // Execute the stored procedure; retrieve
                // and display the output parameter value.
                command.ExecuteNonQuery();
                Console.WriteLine((String)(paramSummary.Value));
                return (String)(paramSummary.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }