' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Build a string with the elapsed time since the user last signed in with the Passport Authority.
Dim sElapsedTimeSignIn As String = "Elapsed time since SignIn: " + newPass.TimeSinceSignIn.ToString() + " seconds."