public MembershipUser MyCreateUser(string username, string password, string email,
                                   string question, string answer)
{
  MembershipCreateStatus status;

  MembershipUser u = Membership.CreateUser(username, password, email, question, 
                                           answer, true, out status);

  if (u == null)
  {
    throw new MembershipCreateUserException(status);
  }

  return u;
}