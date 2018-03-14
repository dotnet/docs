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
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;

/*

This provider works with the following schema for the table of user data.

CREATE TABLE Users
(
  PKID Guid NOT NULL PRIMARY KEY,
  Username Text (255) NOT NULL,
  ApplicationName Text (255) NOT NULL,
  Email Text (128) NOT NULL,
  Comment Text (255),
  Password Text (128) NOT NULL,
  PasswordQuestion Text (255),
  PasswordAnswer Text (128),
  IsApproved YesNo, 
  LastActivityDate DateTime,
  LastLoginDate DateTime,
  LastPasswordChangedDate DateTime,
  CreationDate DateTime, 
  IsOnLine YesNo,
  IsLockedOut YesNo,
  LastLockedOutDate DateTime,
  FailedPasswordAttemptCount Integer,
  FailedPasswordAttemptWindowStart DateTime,
  FailedPasswordAnswerAttemptCount Integer,
  FailedPasswordAnswerAttemptWindowStart DateTime
)

*/


namespace Samples.AspNet.Membership
{

public sealed class OdbcMembershipProvider: MembershipProvider
{

//
// Global generated password length, generic exception message, event log info.
//

private int newPasswordLength = 8;

//
// Used when determining encryption key values.
//

private MachineKeySection machineKey;





//
// Database connection string.
//

private ConnectionStringSettings pConnectionStringSettings;

public string ConnectionString
{
  get { return pConnectionStringSettings.ConnectionString; }
}




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
        name = "OdbcMembershipProvider";

      if (String.IsNullOrEmpty(config["description"]))
      {
        config.Remove("description");
        config.Add("description", "Sample ODBC Membership provider");
      }

      // Initialize the abstract base class.
      base.Initialize(name, config);

      pApplicationName = GetConfigValue(config["applicationName"],
                                     System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
      pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
      pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
      pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
      pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
      pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
      pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
      pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
      pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
      pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));

      string temp_format = config["passwordFormat"];
      if (temp_format == null)
      {
        temp_format = "Hashed";
      }

      switch (temp_format)
      {
        case "Hashed":
          pPasswordFormat = MembershipPasswordFormat.Hashed;
          break;
        case "Encrypted":
          pPasswordFormat = MembershipPasswordFormat.Encrypted;
          break;
        case "Clear":
          pPasswordFormat = MembershipPasswordFormat.Clear;
          break;
        default:
          throw new ProviderException("Password format not supported.");
      }

  //
  // Initialize OdbcConnection.
  //

  pConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

  if (pConnectionStringSettings == null || pConnectionStringSettings.ConnectionString.Trim() == "")
  {
    throw new ProviderException("Connection string cannot be blank.");
  }


  // Get encryption and decryption key information from the configuration.
  Configuration cfg =
    WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
  machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");
}


    //
    // A helper function to retrieve config values from the configuration file.
    //

    private string GetConfigValue(string configValue, string defaultValue)
    {
      if (configValue == null || configValue.Trim() == "")
        return defaultValue;

      return configValue;
    }


//
// System.Web.Security.MembershipProvider properties.
//

    private bool   pRequiresUniqueEmail;

    public override bool RequiresUniqueEmail
    {
      get { return pRequiresUniqueEmail; }
    }

    private int    pMaxInvalidPasswordAttempts;

    public override int MaxInvalidPasswordAttempts
    {
      get { return pMaxInvalidPasswordAttempts; }
    }

    private int    pPasswordAttemptWindow;

    public override int PasswordAttemptWindow
    {
      get { return pPasswordAttemptWindow; }
    }

    private MembershipPasswordFormat pPasswordFormat;

    public override MembershipPasswordFormat PasswordFormat
    {
      get { return pPasswordFormat; }
    }

    private int pMinRequiredNonAlphanumericCharacters;

    public override int MinRequiredNonAlphanumericCharacters
    {
      get { return pMinRequiredNonAlphanumericCharacters; }
    }

    private int pMinRequiredPasswordLength;

    public override int MinRequiredPasswordLength
    {
      get { return pMinRequiredPasswordLength; }
    }

    private string pPasswordStrengthRegularExpression;

    public override string PasswordStrengthRegularExpression
    {
      get { return pPasswordStrengthRegularExpression; }
    }


// -17>
private string pApplicationName;

public override string ApplicationName
{
  get { return pApplicationName; }
  set { pApplicationName = value; }
} 
// -17>

// - 1>
private bool pEnablePasswordReset;

public override bool EnablePasswordReset
{
  get { return pEnablePasswordReset; }
}
// - /1>

// - 2>
private bool pEnablePasswordRetrieval;

public override bool EnablePasswordRetrieval
{
  get { return pEnablePasswordRetrieval; }
}
// - /2>


// - 3>
private bool pRequiresQuestionAndAnswer;

public override bool RequiresQuestionAndAnswer
{
  get { return pRequiresQuestionAndAnswer; }
}
// - /3>


//
// System.Web.Security.MembershipProvider methods.
//

//
// MembershipProvider.ChangePassword
//

// - 4>
public override bool ChangePassword(string username, string oldPwd, string newPwd)
{
  if (!ValidateUser(username, oldPwd))
  {
    throw new MembershipPasswordException("Password validation failed.");
  }

  ValidatePasswordEventArgs args = 
    new ValidatePasswordEventArgs(username, newPwd, true);

  OnValidatingPassword(args);
  
  if (args.Cancel)
    if (args.FailureInformation != null)
      throw args.FailureInformation;
    else
      throw new Exception("Change password canceled due to new password validation failure.");


  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("UPDATE Users "+
            " SET Password = ?, LastPasswordChangedDate = ? " +
            " WHERE Username = ? AND Password = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = newPwd;
  cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now;
  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@OldPassword", OdbcType.VarChar, 128).Value = oldPwd;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;


  int rowsAffected = 0;

  try
  {
    conn.Open();

    rowsAffected = cmd.ExecuteNonQuery();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();
  }

  if (rowsAffected > 0)
  {
    return true;
  }

  return false;
}
// - /4>



//
// MembershipProvider.ChangePasswordQuestionAndAnswer
//

// - 5>
public override bool ChangePasswordQuestionAndAnswer(string username,
                                                     string password, 
                                                     string newPwdQuestion,
                                                     string newPwdAnswer)
{
  if (!ValidateUser(username, password))
  {
    return false;
  }

  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("UPDATE Users " +
                 " SET PasswordQuestion = ?, PasswordAnswer = ?" +
                 " WHERE Username = ? AND Password = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Question", OdbcType.VarChar, 255).Value = newPwdQuestion;
  cmd.Parameters.Add("@Answer", OdbcType.VarChar, 128).Value = newPwdAnswer;
  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = password;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;


  int rowsAffected = 0;

  try
  {
    conn.Open();

    rowsAffected = cmd.ExecuteNonQuery();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();
  }

  if (rowsAffected > 0)
  {
    return true;
  }

  return false;
}
// - /5>




//
// MembershipProvider.CreateUser
//

// - 6>
public override MembershipUser CreateUser(string username,
         string password,
         string email,
         string passwordQuestion,
         string passwordAnswer,
         bool isApproved,
         object providerUserKey,
         out MembershipCreateStatus status)
{
  ValidatePasswordEventArgs args = 
    new ValidatePasswordEventArgs(username, password, true);

  OnValidatingPassword(args);
  
  if (args.Cancel)
    if (args.FailureInformation != null)
      throw args.FailureInformation;
    else
      throw new Exception("Create user canceled due to password validation failure.");


  if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
  {
    status = MembershipCreateStatus.DuplicateEmail;
    return null;
  }

  MembershipUser u = GetUser(username, false);

  if (u == null)
  {
    DateTime createDate = DateTime.Now;

    if (providerUserKey == null)
    {
      providerUserKey = Guid.NewGuid();
    }
    else
    {
      if ( !(providerUserKey is Guid) )
      {
        status = MembershipCreateStatus.InvalidProviderUserKey;
        return null;
      }
    }

    OdbcConnection conn = new OdbcConnection(ConnectionString);
    OdbcCommand cmd = new OdbcCommand("INSERT INTO Users " +
          " (PKID, Username, Password, Email, PasswordQuestion, " +
          " PasswordAnswer, IsApproved," +
          " Comment, CreationDate, LastPasswordChangedDate, LastActivityDate," +
          " ApplicationName, IsLockedOut, LastLockedOutDate," +
          " FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, " +
          " FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)" +
          " Values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);

    cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey;
    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
    cmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(password);
    cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = email;
    cmd.Parameters.Add("@PasswordQuestion", OdbcType.VarChar, 255).Value = passwordQuestion;
    cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 128).Value = passwordAnswer;
    cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = isApproved;
    cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = "";
    cmd.Parameters.Add("@CreationDate", OdbcType.DateTime).Value = createDate;
    cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = createDate;
    cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = createDate;
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;
    cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = false;
    cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = createDate;
    cmd.Parameters.Add("@FailedPasswordAttemptCount", OdbcType.Int).Value = 0;
    cmd.Parameters.Add("@FailedPasswordAttemptWindowStart", OdbcType.DateTime).Value = createDate;
    cmd.Parameters.Add("@FailedPasswordAnswerAttemptCount", OdbcType.Int).Value = 0;
    cmd.Parameters.Add("@FailedPasswordAnswerAttemptWindowStart", OdbcType.DateTime).Value = createDate;

    try
    {
      conn.Open();

      int recAdded = cmd.ExecuteNonQuery();

      if (recAdded > 0)
      {
        status = MembershipCreateStatus.Success;
      }
      else
      {
        status = MembershipCreateStatus.UserRejected;
      }
    }
    catch (OdbcException)
    {
      // Handle exception.

      status = MembershipCreateStatus.ProviderError;
    }
    finally
    {
      conn.Close();
    }


    return GetUser(username, false);      
  }        
  else
  {
    status = MembershipCreateStatus.DuplicateUserName;
  }
      

  return null;
}
// - /6>



//
// MembershipProvider.DeleteUser
//

// - 7>
public override bool DeleteUser(string username, bool deleteAllRelatedData)
{

  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("DELETE FROM Users " +
                        " WHERE Username = ? AND Applicationname = ?", conn);

  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  int rowsAffected = 0;

  try
  {
    conn.Open();

    rowsAffected = cmd.ExecuteNonQuery();

    if (deleteAllRelatedData)
    {
      // Process commands to delete all data for the user in the database.
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

  if (rowsAffected > 0)
  {
    return true;
  }

  return false;
}
// - /7>




//
// MembershipProvider.GetAllUsers
//


public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM Users  " +
                                    "WHERE ApplicationName = ?", conn);
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  MembershipUserCollection users = new MembershipUserCollection();

  OdbcDataReader reader = null;
  totalRecords = 0;

  try
  {
    conn.Open();
    totalRecords = (int)cmd.ExecuteScalar();

    if (totalRecords <= 0) { return users; }

    cmd.CommandText = "SELECT Username, Email, PasswordQuestion," +
             " Comment, IsApproved, CreationDate, LastLoginDate," +
             " LastActivityDate, LastPasswordChangedDate " +
             " FROM Users  " + 
             " WHERE ApplicationName = ? " +
             " ORDER BY Username Asc";

    reader = cmd.ExecuteReader();

    int counter = 0;
    int startIndex = pageSize * pageIndex;
    int endIndex = startIndex + pageSize - 1;

    while (reader.Read())
    {
      if (counter >= startIndex)
      {
        MembershipUser u = GetUserFromReader(reader);
        users.Add(u);
      }

      if (counter >= endIndex) { cmd.Cancel(); }

      counter++;
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

  return users;
}






//
// MembershipProvider.GetNumberOfUsersOnline
//

// - 8>
public override int GetNumberOfUsersOnline()
{

  TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
  DateTime compareTime = DateTime.Now.Subtract(onlineSpan);

  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM Users " +
                         " WHERE LastActivityDate > ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@CompareDate", OdbcType.DateTime).Value = compareTime;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  int numOnline = 0;

  try
  {
    conn.Open();

    numOnline = (int)cmd.ExecuteScalar();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();
  }

  return numOnline;
}
// - /8>




//
// MembershipProvider.GetPassword
//

// - 9>
public override string GetPassword(string username, string answer)
{
  if (!EnablePasswordRetrieval)
  {
    throw new ProviderException("Password retrieval is not enabled.");
  }

  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Password, PasswordAnswer FROM Users " +
                                    " WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;


  string password = "";
  string passwordAnswer = "";
  OdbcDataReader reader = null;

  try
  {
    conn.Open();

    reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

    if (reader.HasRows)
    {
      reader.Read();
      password = reader.GetString(0);
      passwordAnswer = reader.GetString(1);
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

  if (RequiresQuestionAndAnswer && 
      String.Compare(passwordAnswer, answer, true, CultureInfo.InvariantCulture) != 0)
  {
    throw new MembershipPasswordException("Incorrect password answer.");
  }

  return password;
}
// - /9>



//
// MembershipProvider.GetUser
//

// - 10>
public override MembershipUser GetUser(string username, bool userIsOnline)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT PKID, Username, Email, PasswordQuestion," +
        " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
        " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" +
        " FROM Users  WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

  MembershipUser u = null;
  OdbcDataReader reader = null;

  try
  {
    conn.Open();

    reader = cmd.ExecuteReader();

    if (reader.HasRows)
    {
      reader.Read();
      u = GetUserFromReader(reader);
          
      if (userIsOnline)
      {
        OdbcCommand updateCmd = new OdbcCommand("UPDATE Users  " +
                  "SET LastActivityDate = ? " +
                  "WHERE Username = ? AND Applicationname = ?", conn);

        updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now;
        updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
        updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

        updateCmd.ExecuteNonQuery();
      }
    }

  }
  catch (OdbcException)
  {
    // Handle exception
  }
  finally
  {
    if (reader != null) { reader.Close(); }
    conn.Close();
  }

  return u;      
}



// - /10>



//
// MembershipProvider.GetUserNameByEmail
//

// - 11>
public override string GetUserNameByEmail(string email)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Username" +
         " FROM Users  WHERE Email = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = email;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  string username = "";

  try
  {
    conn.Open();

    username = (string)cmd.ExecuteScalar();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();
  }

  return username;
}
// - /11>





//
// MembershipProvider.ResetPassword
//


// - 12>
public override string ResetPassword(string username, string answer)
{
  if (!EnablePasswordReset)
  {
    throw new NotSupportedException("Password reset is not enabled.");
  }

  if (answer == null && RequiresQuestionAndAnswer)
  {
    throw new ProviderException("A password answer is required to reset the password.");
  }

  string newPassword =
	System.Web.Security.Membership.GeneratePassword(newPasswordLength, MinRequiredNonAlphanumericCharacters);


  ValidatePasswordEventArgs args = 
    new ValidatePasswordEventArgs(username, newPassword, true);

  OnValidatingPassword(args);
  
  if (args.Cancel)
    if (args.FailureInformation != null)
      throw args.FailureInformation;
    else
      throw new Exception("Reset password canceled due to password validation failure.");


  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("UPDATE Users " +
                " SET Password = ?, LastPasswordChangedDate = ?" +
                " WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = newPassword;
  cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now;
  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  if (RequiresQuestionAndAnswer)
  {
    cmd.CommandText += " AND PasswordAnswer = ?";
    cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 128).Value = answer;
  }

  int rowsAffected = 0;

  try
  {
    conn.Open();

    rowsAffected = cmd.ExecuteNonQuery();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();
  }

  if (rowsAffected > 0)
  {
    return newPassword;
  }
  else
  {
    throw new MembershipPasswordException("Invalid password answer for userid. Password not reset.");
  }
}
// - /12>



//
// MembershipProvider.UpdateUser
//

// - 13>
public override void UpdateUser(MembershipUser user)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("UPDATE Users " +
                                    " SET Email = ?, Comment = ?," +
                                    " IsApproved = ?" +
                                    " WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = user.Email;
  cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = user.Comment;
  cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = user.IsApproved;
  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = user.UserName;
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
// - /13>



//
// MembershipProvider.ValidateUser
//

// - 14>
public override bool ValidateUser(string username, string password)
{
  bool isValid = false;

  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Password, IsApproved FROM Users " +
                                    " WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

  OdbcDataReader reader = null;
  bool isApproved = false;
  string pwd = "";

  try
  {
    conn.Open();

    reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

    if (reader.HasRows)
    {
      reader.Read();
      pwd = reader.GetString(0);
      isApproved = reader.GetBoolean(1);
    }

    if (isApproved && (password == pwd))
    {
      isValid = true;

      OdbcCommand updateCmd = new OdbcCommand("UPDATE Users  SET LastLoginDate = ?" +
                                              " WHERE Username = ? AND ApplicationName = ?", conn);

      updateCmd.Parameters.Add("@LastLoginDate", OdbcType.DateTime).Value = DateTime.Now;
      updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
      updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

      updateCmd.ExecuteNonQuery();
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

  return isValid;
}
// - /14>

//<Snippet16>
public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM Users  " +
                                    "WHERE Username LIKE ? AND ApplicationName = ?", conn);
  cmd.Parameters.Add("@UsernameSearch", OdbcType.VarChar, 255).Value = usernameToMatch;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  MembershipUserCollection users = new MembershipUserCollection();

  OdbcDataReader reader = null;
  totalRecords = 0;

  try
  {
    conn.Open();
    totalRecords = (int)cmd.ExecuteScalar();

    if (totalRecords <= 0) { return users; }

    cmd.CommandText = "SELECT Username, Email, PasswordQuestion," +
             " Comment, IsApproved, CreationDate, LastLoginDate," +
             " LastActivityDate, LastPasswordChangedDate " +
             " FROM Users  " + 
             " WHERE Username LIKE ? AND ApplicationName = ? " +
             " ORDER BY Username Asc";

    reader = cmd.ExecuteReader();

    int counter = 0;
    int startIndex = pageSize * pageIndex;
    int endIndex = startIndex + pageSize - 1;

    while (reader.Read())
    {
      if (counter >= startIndex)
      {
        MembershipUser u = GetUserFromReader(reader);
        users.Add(u);
      }

      if (counter >= endIndex) { cmd.Cancel(); }

      counter++;
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

  return users;
}


//
// GetUserFromReader
// A helper function that takes the current row from the OdbcDataReader
// and populates a MembershipUser object with the values. Called by the 
// MembershipUser.GetUser implementation.
//

public MembershipUser GetUserFromReader(OdbcDataReader reader)
{
  object providerUserKey = reader.GetValue(0);
  string username = reader.GetString(1);
  string email = reader.GetString(2);

  string passwordQuestion = "";
  if (reader.GetValue(3) != DBNull.Value)
    passwordQuestion = reader.GetString(3);

  string comment = "";
  if (reader.GetValue(4) != DBNull.Value)
    comment = reader.GetString(4);

  bool isApproved = reader.GetBoolean(5);
  bool isLockedOut = reader.GetBoolean(6);
  DateTime creationDate = reader.GetDateTime(7);

  DateTime lastLoginDate = new DateTime();
  if (reader.GetValue(8) != DBNull.Value)
    lastLoginDate = reader.GetDateTime(8);

  DateTime lastActivityDate = reader.GetDateTime(9);
  DateTime lastPasswordChangedDate = reader.GetDateTime(10);

  DateTime lastLockedOutDate = new DateTime();
  if (reader.GetValue(11) != DBNull.Value)
    lastLockedOutDate = reader.GetDateTime(11);
      
  MembershipUser u = new MembershipUser(this.Name,
                                        username,
                                        providerUserKey,
                                        email,
                                        passwordQuestion,
                                        comment,
                                        isApproved,
                                        isLockedOut,
                                        creationDate,
                                        lastLoginDate,
                                        lastActivityDate,
                                        lastPasswordChangedDate,
                                        lastLockedOutDate);

  return u;
}
//</Snippet16>


public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM Users  " +
                                    "WHERE Email LIKE ? AND ApplicationName = ?", conn);
  cmd.Parameters.Add("@EmailSearch", OdbcType.VarChar, 255).Value = emailToMatch;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

  MembershipUserCollection users = new MembershipUserCollection();

  OdbcDataReader reader = null;
  totalRecords = 0;

  try
  {
    conn.Open();
    totalRecords = (int)cmd.ExecuteScalar();

    if (totalRecords <= 0) { return users; }

    cmd.CommandText = "SELECT Username, Email, PasswordQuestion," +
             " Comment, IsApproved, CreationDate, LastLoginDate," +
             " LastActivityDate, LastPasswordChangedDate " +
             " FROM Users  " + 
             " WHERE Email LIKE ? AND ApplicationName = ? " +
             " ORDER BY Username Asc";

    reader = cmd.ExecuteReader();

    int counter = 0;
    int startIndex = pageSize * pageIndex;
    int endIndex = startIndex + pageSize - 1;

    while (reader.Read())
    {
      if (counter >= startIndex)
      {
        MembershipUser u = GetUserFromReader(reader);
        users.Add(u);
      }

      if (counter >= endIndex) { cmd.Cancel(); }

      counter++;
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

  return users;
}


//
// MembershipProvider.UnlockUser
//

public override bool UnlockUser(string username)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("UPDATE Users  " +
                                    " SET IsLockedOut = False, LastLockedOutDate = ? " +
                                    " WHERE Username = ? AND ApplicationName = ?", conn);

  cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = DateTime.Now;
  cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
  cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

  int rowsAffected = 0;

  try
  {
    conn.Open();

    rowsAffected = cmd.ExecuteNonQuery();
  }
  catch (OdbcException)
  {
    // Handle exception.
  }
  finally
  {
    conn.Close();
  }

  if (rowsAffected > 0)
    return true;

  return false;      
}


//
// MembershipProvider.GetUser(object, bool)
//

public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
{
  OdbcConnection conn = new OdbcConnection(ConnectionString);
  OdbcCommand cmd = new OdbcCommand("SELECT PKID, Username, Email, PasswordQuestion," +
        " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
        " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" +
        " FROM Users  WHERE PKID = ?", conn);

  cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey;

  MembershipUser u = null;
  OdbcDataReader reader = null;

  try
  {
    conn.Open();

    reader = cmd.ExecuteReader();

    if (reader.HasRows)
    {
      reader.Read();
      u = GetUserFromReader(reader);
          
      if (userIsOnline)
      {
        OdbcCommand updateCmd = new OdbcCommand("UPDATE Users  " +
                  "SET LastActivityDate = ? " +
                  "WHERE PKID = ?", conn);

        updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now;
        updateCmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey;

        updateCmd.ExecuteNonQuery();
      }
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

  return u;      
}




    //
    // UpdateFailureCount
    //   A helper method that performs the checks and updates associated with
    // password failure tracking.
    //

    private void UpdateFailureCount(string username, string failureType)
    {
      OdbcConnection conn = new OdbcConnection(ConnectionString);
      OdbcCommand cmd = new OdbcCommand("SELECT FailedPasswordAttemptCount, " +
                                        "  FailedPasswordAttemptWindowStart, " +
                                        "  FailedPasswordAnswerAttemptCount, " +
                                        "  FailedPasswordAnswerAttemptWindowStart " + 
                                        "  FROM Users  " +
                                        "  WHERE Username = ? AND ApplicationName = ?", conn);

      cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

      OdbcDataReader reader = null;
      DateTime windowStart = new DateTime();
      int failureCount = 0;

      try
      {
        conn.Open();

        reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

        if (reader.HasRows)
        {
          reader.Read();

          if (failureType == "password")
          {
            failureCount = reader.GetInt32(0);
            windowStart = reader.GetDateTime(1);
          }

          if (failureType == "passwordAnswer")
          {
            failureCount = reader.GetInt32(2);
            windowStart = reader.GetDateTime(3);
          }
        }

        reader.Close();

        DateTime windowEnd = windowStart.AddMinutes(PasswordAttemptWindow);

        if (failureCount == 0 || DateTime.Now > windowEnd)
        {
          // First password failure or outside of PasswordAttemptWindow. 
          // Start a new password failure count from 1 and a new window starting now.

          if (failureType == "password")
            cmd.CommandText = "UPDATE Users  " +
                              "  SET FailedPasswordAttemptCount = ?, " +
                              "      FailedPasswordAttemptWindowStart = ? " +
                              "  WHERE Username = ? AND ApplicationName = ?";

          if (failureType == "passwordAnswer")
            cmd.CommandText = "UPDATE Users  " +
                              "  SET FailedPasswordAnswerAttemptCount = ?, " +
                              "      FailedPasswordAnswerAttemptWindowStart = ? " +
                              "  WHERE Username = ? AND ApplicationName = ?";

          cmd.Parameters.Clear();

          cmd.Parameters.Add("@Count", OdbcType.Int).Value = 1;
          cmd.Parameters.Add("@WindowStart", OdbcType.DateTime).Value = DateTime.Now;
          cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
          cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

          if (cmd.ExecuteNonQuery() < 0)
            throw new Exception("Unable to update failure count and window start.");
        }
        else
        {
          if (failureCount++ >= MaxInvalidPasswordAttempts)
          {
            // Password attempts have exceeded the failure threshold. Lock out
            // the user.

            cmd.CommandText = "UPDATE Users  " +
                              "  SET IsLockedOut = ?, LastLockedOutDate = ? " +
                              "  WHERE Username = ? AND ApplicationName = ?";

            cmd.Parameters.Clear();

            cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = true;
            cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            if (cmd.ExecuteNonQuery() < 0)
              throw new Exception("Unable to lock out user.");
          }
          else
          {
            // Password attempts have not exceeded the failure threshold. Update
            // the failure counts. Leave the window the same.

            if (failureType == "password")
              cmd.CommandText = "UPDATE Users  " +
                                "  SET FailedPasswordAttemptCount = ?" +
                                "  WHERE Username = ? AND ApplicationName = ?";

            if (failureType == "passwordAnswer")
              cmd.CommandText = "UPDATE Users  " +
                                "  SET FailedPasswordAnswerAttemptCount = ?" +
                                "  WHERE Username = ? AND ApplicationName = ?";

             cmd.Parameters.Clear();

             cmd.Parameters.Add("@Count", OdbcType.Int).Value = failureCount;
             cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
             cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

             if (cmd.ExecuteNonQuery() < 0)
               throw new Exception("Unable to update failure count.");
          }
        }
      }
      catch (OdbcException)
      {
        // Handle Exception
      }
      finally
      {
        if (reader != null) { reader.Close(); }
        conn.Close();
      }       
    }


    //
    // CheckPassword
    //   Compares password values based on the MembershipPasswordFormat.
    //

    private bool CheckPassword(string password, string dbpassword)
    {
      string pass1 = password;
      string pass2 = dbpassword;

      switch (PasswordFormat)
      {
        case MembershipPasswordFormat.Encrypted:
          pass2 = UnEncodePassword(dbpassword);
          break;
        case MembershipPasswordFormat.Hashed:
          pass1 = EncodePassword(password);
          break;
        default:
          break;
      }

      if (pass1 == pass2)
      {
        return true;
      }

      return false;
    }


    //
    // EncodePassword
    //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
    //

    private string EncodePassword(string password)
    {
      string encodedPassword = password;

      switch (PasswordFormat)
      {
        case MembershipPasswordFormat.Clear:
          break;
        case MembershipPasswordFormat.Encrypted:
          encodedPassword = 
            Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
          break;
        case MembershipPasswordFormat.Hashed:
          HMACSHA1 hash = new HMACSHA1();
          hash.Key = HexToByte(machineKey.ValidationKey);
          encodedPassword = 
            Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
          break;
        default:
          throw new ProviderException("Unsupported password format.");
      }

      return encodedPassword;
    }


    //
    // UnEncodePassword
    //   Decrypts or leaves the password clear based on the PasswordFormat.
    //

    private string UnEncodePassword(string encodedPassword)
    {
      string password = encodedPassword;

      switch (PasswordFormat)
      {
        case MembershipPasswordFormat.Clear:
          break;
        case MembershipPasswordFormat.Encrypted:
          password = 
            Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
          break;
        case MembershipPasswordFormat.Hashed:
          throw new ProviderException("Cannot unencode a hashed password.");
        default:
          throw new ProviderException("Unsupported password format.");
      }

      return password;
    }

    //
    // HexToByte
    //   Converts a hexadecimal string to a byte array. Used to convert encryption
    // key values from the configuration.
    //

    private byte[] HexToByte(string hexString)
    {
      byte[] returnBytes = new byte[hexString.Length / 2];
      for (int i = 0; i < returnBytes.Length; i++)
        returnBytes[i] = Convert.ToByte(hexString.Substring(i*2, 2), 16);
      return returnBytes;
    }



}
}
