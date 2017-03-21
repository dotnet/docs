    public void SearchOracleParams() 
    {
        // ...
        // create OracleParameterCollection parameters
        // ...
        if (!parameters.Contains("DName"))
            Console.WriteLine("ERROR: no such parameter in the collection");
        else
            Console.WriteLine("Name: " + parameters["DName"].ToString() +
                "Index: " + parameters.IndexOf("DName").ToString());
    }