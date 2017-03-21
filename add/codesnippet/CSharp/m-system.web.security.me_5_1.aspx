public MembershipUserCollection GetUsers(bool setReadOnly)
{
  MembershipUserCollection users = Membership.GetAllUsers();
  if (setReadOnly)
    users.SetReadOnly();
  return users;
}