//<Snippet5>
using System.Web.Security;
using System.Runtime.Serialization;

public sealed class MyCreateUserException : MembershipCreateUserException
{
  public MyCreateUserException(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }
}
//</Snippet5>


