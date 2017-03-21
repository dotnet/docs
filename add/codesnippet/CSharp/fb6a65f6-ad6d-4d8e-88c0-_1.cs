    public override bool ChangePassword(string username, string oldPwd, string newPwd)
    {
      if (!ValidateUser(username, oldPwd))
      {
        return false;
      }

      ValidatePasswordEventArgs args =
        new ValidatePasswordEventArgs(username, newPwd, true);

      OnValidatingPassword(args);

      if (args.Cancel)
        if (args.FailureInformation != null)
          throw args.FailureInformation;
        else
          throw new MembershipPasswordException("Change password canceled due to new password validation failure.");


      OdbcConnection conn = new OdbcConnection(ConnectionString);
      OdbcCommand cmd = new OdbcCommand("UPDATE Users " +
                " SET Password = ?, LastPasswordChangedDate = ? " +
                " WHERE Username = ? AND Password = ? AND ApplicationName = ?", conn);

      cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = EncodePassword(newPwd);
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