    public void CreateParameterCollection(OdbcCommand command) 
    {
        OdbcParameterCollection paramCollection = command.Parameters;
        paramCollection.Add("@CategoryName", OdbcType.Char);
        paramCollection.Add("@Description", OdbcType.Char);
        paramCollection.Add("@Picture", OdbcType.Binary);
        string paramNames = "";
        for (int i=0; i < paramCollection.Count; i++)
            paramNames += paramCollection[i].ToString() + "\n";
        Console.WriteLine(paramNames);
        paramCollection.Clear();
    }