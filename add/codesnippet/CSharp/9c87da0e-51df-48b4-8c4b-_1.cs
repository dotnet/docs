public override void AddUsersToRoles(string[]  usernames, string[] rolenames)
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
    if (username.Contains(","))
      throw new ArgumentException("User names cannot contain commas.");

    foreach (string rolename in rolenames)
    {
      if (IsUserInRole(username, rolename))
        throw new ProviderException("User is already in role.");
    }
  }


  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("INSERT INTO UsersInRoles "  +
                                    " (Username, Rolename, ApplicationName) " +
                                    " Values(?, ?, ?)", conn);

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