    public void CreateOracleParamColl(OracleCommand command) 
    {
        OracleParameterCollection paramCollection = command.Parameters;
        paramCollection.Add("pDName", OracleType.VarChar);
        paramCollection.Add("pLoc", OracleType.VarChar);
        string parameterNames = "";
        for (int i=0; i < paramCollection.Count; i++)
            parameterNames += paramCollection[i].ToString() + "\n";
        Console.WriteLine(parameterNames);
        paramCollection.Clear();
    }