public MembershipUser MyCreateUser(string username, string password, string email)
{
  MembershipUser u = null;

  try
  {
    u = Membership.CreateUser(username, password, email);
  }
  catch (MembershipCreateUserException e)
  {  
    throw e;
  }
  catch (Exception e)
  {  
    throw new MembershipCreateUserException("An exception occurred creating the user.", e);
  }

  return u;
}