    public void SearchParameters() 
    {
        // ...
        // create OdbcParameterCollection parameterCollection
        // ...
        if (!parameterCollection.Contains("Description"))
            Console.WriteLine("ERROR: no such parameter in the collection");
        else
            Console.WriteLine("Name: " + parameterCollection["Description"].ToString() +
                "Index: " + parameterCollection.IndexOf("Description").ToString());
    }