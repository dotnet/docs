    void AuthenticationService_Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        string studentid = String.Empty;
        string answer = String.Empty;

        string[] credentials =
            e.CustomCredential.Split(new char[] { ',' });
        if (credentials.Length > 0)
        {
            studentid = credentials[0];
            if (credentials.Length > 1)
            {
                answer = credentials[1];
            }
        }

        try
        {
            e.Authenticated =
                StudentAuthentication.ValidateStudentCredentials
                (e.UserName, e.Password, studentid, answer);
        }
        catch (ArgumentNullException ex)
        {
            e.Authenticated = false;
        }

        e.AuthenticationIsComplete = true;
    }