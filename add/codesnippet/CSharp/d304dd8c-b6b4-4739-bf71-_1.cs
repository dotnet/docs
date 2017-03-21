public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
{
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