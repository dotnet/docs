public override string[] GetRolesForUser(string username)
{
  if (username == null || username == "")
    throw new ProviderException("User name cannot be empty or null.");

  string tmpRoleNames = "";

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Rolename FROM UsersInRoles "  +
                                    " WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  OdbcDataReader reader = null;

  try
  {
    conn.Open();

    reader = cmd.ExecuteReader();

    while (reader.Read())
    {
      tmpRoleNames += reader.GetString(0) + ",";
    }
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    if (reader != null) { reader.Close(); }
    conn.Close();      
  }

  if (tmpRoleNames.Length > 0)
  {
    // Remove trailing comma.
    tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
    return tmpRoleNames.Split(',');
  }

  return new string[0];
}