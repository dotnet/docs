public override string[] GetUsersInRole(string rolename)
{
  if (rolename == null || rolename == "")
    throw new ProviderException("Role name cannot be empty or null.");
  if (!RoleExists(rolename))
    throw new ProviderException("Role does not exist.");

  string tmpUserNames = "";

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Username FROM UsersInRoles "  +
                                    " WHERE Rolename = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  OdbcDataReader reader = null;

  try
  {
    conn.Open();

    reader = cmd.ExecuteReader();

    while (reader.Read())
    {
      tmpUserNames += reader.GetString(0) + ",";
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

  if (tmpUserNames.Length > 0)
  {
    // Remove trailing comma.
    tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1);
    return tmpUserNames.Split(',');
  }

  return new string[0];
}