    public void CreateSqlCommand(SqlConnection myConnection,
        string queryString, SqlParameter[] paramArray) 
    {
        SqlCommand command = new SqlCommand(queryString, myConnection);
        command.CommandText = 
            "SELECT CustomerID, CompanyName FROM Customers " 
            + "WHERE Country = @Country AND City = @City";    
        command.Parameters.Add(paramArray);

        for (int j=0; j<paramArray.Length; j++)
        {
            command.Parameters.Add(paramArray[j]) ;
        }

        string message = "";
        for (int i = 0; i < command.Parameters.Count; i++) 
        {
            message += command.Parameters[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }