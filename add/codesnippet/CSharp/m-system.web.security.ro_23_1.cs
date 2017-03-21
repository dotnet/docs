public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
{
  if (!RoleExists(rolename))
  {
    throw new ProviderException("Role does not exist.");
  }

  if (throwOnPopulatedRole && GetUsersInRole(rolename).Length > 0)
  {
    throw new ProviderException("Cannot delete a populated role.");
  }

  OdbcConnection conn = new OdbcConnection(connectionString);
  OdbcCommand cmd = new OdbcCommand("DELETE FROM Roles "  +
                                    " WHERE Rolename = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  OdbcCommand cmd2 = new OdbcCommand("DELETE FROM UsersInRoles "  +
                                     " WHERE Rolename = ? AND ApplicationName = ?", conn);

  cmd2.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
  cmd2.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  try
  {
    conn.Open();

    cmd2.ExecuteNonQuery();
    cmd.ExecuteNonQuery();
  }
  catch (OdbcException)
  {
    // Handle exception.

    return false;
  }
  finally
  {
    conn.Close();      
  }

  return true;
}