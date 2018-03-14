using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;




namespace Samples.AspNet.Roles
{

  public sealed class OdbcRoleProvider: RoleProvider
  {

    //
    // Global connection string, generic exception message, event log info.
    //

    private OdbcConnection conn;

    private ConnectionStringSettings pConnectionStringSettings;
    private string connectionString;


    //
    // System.Configuration.Provider.ProviderBase.Initialize Method
    //

    public override void Initialize(string name, NameValueCollection config)
    {

      //
      // Initialize values from web.config.
      //

      if (config == null)
        throw new ArgumentNullException("config");

      if (name == null || name.Length == 0)
        name = "OdbcRoleProvider";

      if (String.IsNullOrEmpty(config["description"]))
      {
        config.Remove("description");
        config.Add("description", "Sample ODBC Role provider");
      }

      // Initialize the abstract base class.
      base.Initialize(name, config);


      if (config["applicationName"] == null || config["applicationName"].Trim() == "")
      {
        pApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
      }
      else
      {
        pApplicationName = config["applicationName"];
      }


      //
      // Initialize OdbcConnection.
      //

      pConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

      if (pConnectionStringSettings == null || connectionString.Trim() == "")
      {
        throw new ProviderException("Connection string cannot be blank.");
      }

      connectionString = pConnectionStringSettings.ConnectionString;
    }



    //
    // System.Web.Security.RoleProvider properties.
    //
    

//<Snippet1>
private string pApplicationName;

public override string ApplicationName
{
  get { return pApplicationName; }
  set { pApplicationName = value; }
} 
//</Snippet1>

    //
    // System.Web.Security.RoleProvider methods.
    //

    //
    // RoleProvider.AddUsersToRoles
    //

//<Snippet2>
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
//</Snippet2>


    //
    // RoleProvider.CreateRole
    //

//<Snippet3>
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
//</Snippet3>


    //
    // RoleProvider.DeleteRole
    //

//<Snippet4>
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
//</Snippet4>


    //
    // RoleProvider.GetAllRoles
    //

//<Snippet5>
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
//</Snippet5>


    //
    // RoleProvider.GetRolesForUser
    //

//<Snippet6>
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
//</Snippet6>


    //
    // RoleProvider.GetUsersInRole
    //

//<Snippet7>
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
//</Snippet7>


    //
    // RoleProvider.IsUserInRole
    //


//<Snippet8>
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
//</Snippet8>


    //
    // RoleProvider.RemoveUsersFromRoles
    //

//<Snippet9>
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
//</Snippet9>


    //
    // RoleProvider.RoleExists
    //

//<Snippet10>
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
//</Snippet10>

    //
    // RoleProvider.FindUsersInRole
    //

//<Snippet11>
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
//</Snippet11>


  }
}