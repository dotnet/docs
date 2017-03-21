public void ListUsers(MembershipUserCollection users)
{
  foreach (MembershipUser u in users)
    Response.Write(u.UserName + "<br />");
}