    public void AddSqlParameter(SqlCommand command) 
    {
        command.Parameters.Add(new SqlParameter("Description", "Beverages"));
    }