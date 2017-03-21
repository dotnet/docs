public override string[] GetAllRoles()
{
  string tmpRoleNames = "";

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Rolename FROM Roles "  +
                                    " WHERE ApplicationName = ?", conn);

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