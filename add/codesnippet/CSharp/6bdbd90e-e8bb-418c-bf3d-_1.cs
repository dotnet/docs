    public void CreateOdbcParameter() 
    {
        OdbcParameter parameter = new OdbcParameter("Description",OdbcType.VarChar,
            88,"Description");
        parameter.Direction = ParameterDirection.Output;
    }