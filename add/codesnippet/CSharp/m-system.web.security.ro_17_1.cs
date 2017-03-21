public override void CreateRole(string rolename)
{ 
  if (rolename == null || rolename == "")
    throw new ProviderException("Role name cannot be empty or null.");
  if (rolename.Contains(","))
    throw new ArgumentException("Role names cannot contain commas.");
  if (RoleExists(rolename))
    throw new ProviderException("Role name already exists.");
  if (rolename.Length > 255)
    throw new ProviderException("Role name cannot exceed 255 characters.");

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("INSERT INTO Roles "  +
                                    " (Rolename, ApplicationName) " +
                                    " Values(?, ?)", conn);

  cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  try
  {
    conn.Open();

    cmd.ExecuteNonQuery();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();      
  }
}