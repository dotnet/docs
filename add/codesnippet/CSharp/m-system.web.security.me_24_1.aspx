public MembershipUser MyCreateUser(string username, string password, string email,
                                   string question, string answer)
{
  MembershipCreateStatus status;

  MembershipUser u = Membership.CreateUser(username, password, email, question, 
                                           answer, true, out status);
  if (u == null)
  {
    throw new MembershipCreateUserException(GetErrorMessage(status));
  }

  return u;
}

public string GetErrorMessage(MembershipCreateStatus status)
{
   switch (status)
   {
      case MembershipCreateStatus.DuplicateUserName:
        return "Username already exists. Please enter a different user name.";

      case MembershipCreateStatus.DuplicateEmail:
        return "A username for that e-mail address already exists. Please enter a different e-mail address.";

      case MembershipCreateStatus.InvalidPassword:
        return "The password provided is invalid. Please enter a valid password value.";

      case MembershipCreateStatus.InvalidEmail:
        return "The e-mail address provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidAnswer:
        return "The password retrieval answer provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidQuestion:
        return "The password retrieval question provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidUserName:
        return "The user name provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.ProviderError:
        return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

      case MembershipCreateStatus.UserRejected:
        return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

      default:
        return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
   }
}