public override bool RoleExists(string rolename)
{
  if (rolename == null || rolename == "")
    throw new ProviderException("Role name cannot be empty or null.");

  bool exists = false;

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT COUNT(*) FROM Roles "  +
                                    " WHERE Rolename = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  try
  {
    conn.Open();

    int numRecs = (int)cmd.ExecuteScalar();

    if (numRecs > 0)
    {
      exists = true;
    }
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();      
  }

  return exists;
}