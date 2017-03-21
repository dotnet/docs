  public void AddSqlParameter(SqlCommand cmd) 
  {
    SqlParameter p1 = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 16, "Description");
  }