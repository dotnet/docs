    static void CreateSqlParameterPrecisionScale()
    {
        SqlParameter parameter = new SqlParameter("Price", SqlDbType.Decimal);
        parameter.Value = 3.1416;
        parameter.Precision = 8;
        parameter.Scale = 4;
    }