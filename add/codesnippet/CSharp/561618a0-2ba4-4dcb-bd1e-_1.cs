    public void SearchSqlParams() 
    {
        // ...
        // create SqlCommand command and SqlParameter param
        // ...
        if (command.Parameters.Contains(param))
            command.Parameters.Remove(param);
    }