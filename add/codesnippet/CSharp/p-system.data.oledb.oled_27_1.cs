    public void CreateParamCollection(OleDbCommand command) 
    {
        OleDbParameterCollection paramCollection = command.Parameters;
        paramCollection.Add("@CategoryName", OleDbType.Char);
        paramCollection.Add("@Description", OleDbType.Char);
        paramCollection.Add("@Picture", OleDbType.Binary);
        string parameterNames = "";
        for (int i=0; i < paramCollection.Count; i++)
            parameterNames += paramCollection[i].ToString() + "\n";
        Console.WriteLine(parameterNames);
        paramCollection.Clear();
    }