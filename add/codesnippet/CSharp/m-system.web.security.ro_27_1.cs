public override bool IsUserInRole(string username, string rolename)
{
  if (username == null || username == "")
    throw new ProviderException("User name cannot be empty or null.");
  if (rolename == null || rolename == "")
    throw new ProviderException("Role name cannot be empty or null.");

  bool userIsInRole = false;

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT COUNT(*) FROM UsersInRoles "  +
                                    " WHERE Username = ? AND Rolename = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  try
  {
    conn.Open();

    int numRecs = (int)cmd.ExecuteScalar();

    if (numRecs > 0)
    {
      userIsInRole = true;
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

  return userIsInRole;
}