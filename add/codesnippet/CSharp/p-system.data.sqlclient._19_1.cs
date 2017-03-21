    static void CreateSqlParameterSize()
    {
        string description = "12 foot scarf - multiple colors, one previous owner";
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar);
        parameter.Direction = ParameterDirection.InputOutput;
        parameter.Size = description.Length;
        parameter.Value = description;
    }