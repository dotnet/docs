public override string[] FindUsersInRole(string rolename, string usernameToMatch)
{
  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Username FROM UsersInRoles  " +
                                    " WHERE Username LIKE ? AND RoleName = ? AND ApplicationName = ?", conn);
  cmd.Parameters.Add("@UsernameSearch", OdbcType.VarChar, 255).Value = usernameToMatch;
  cmd.Parameters.Add("@RoleName", OdbcType.VarChar, 255).Value = rolename;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

  string tmpUserNames = "";
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
    // Handle Exception.
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

  return null;
}