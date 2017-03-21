public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
{
  foreach (string rolename in rolenames)
  {
    if (rolename == null || rolename == "")
      throw new ProviderException("Role name cannot be empty or null.");
    if (!RoleExists(rolename))
      throw new ProviderException("Role name not found.");
  }

  foreach (string username in usernames)
  {
    if (username == null || username == "")
      throw new ProviderException("User name cannot be empty or null.");

    foreach (string rolename in rolenames)
    {
      if (!IsUserInRole(username, rolename))
        throw new ProviderException("User is not in role.");
    }
  }


  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("DELETE FROM UsersInRoles "  +
                                    " WHERE Username = ? AND Rolename = ? AND ApplicationName = ?", conn);

  OdbcParameter userParm = cmd.Parameters.Add("@Username", OdbcType.VarChar, 255);
  OdbcParameter roleParm = cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255);
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  try
  {
    conn.Open();

    foreach (string username in usernames)
    {
      foreach (string rolename in rolenames)
      {
        userParm.Value = username;
        roleParm.Value = rolename;
        cmd.ExecuteNonQuery();
      }
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
}