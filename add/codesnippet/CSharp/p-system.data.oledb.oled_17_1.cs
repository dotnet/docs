    public void SearchParameters() 
    {
        // ...
        // create OleDbParameterCollection parameters
        // ...
        if (!parameters.Contains("Description"))
            Console.WriteLine("ERROR: no such parameter in the collection");
        else
            Console.WriteLine("Name: " + parameters["Description"].ToString() +
                "Index: " + parameters.IndexOf("Description").ToString());
    }