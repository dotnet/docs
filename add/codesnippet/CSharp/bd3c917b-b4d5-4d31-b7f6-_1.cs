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
      {
        status = MembershipCreateStatus.InvalidPassword;
        return null;
      }


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
          if (!(providerUserKey is Guid))
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
        cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 255).Value = EncodePassword(passwordAnswer);
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