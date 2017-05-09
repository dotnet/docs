using System.Web.Security;
using System.Security.Principal;

namespace Samples.AspNet.Security
{

  public sealed class MyFormsIdentity : IIdentity
  {
    private FormsAuthenticationTicket pTicket;

    public MyFormsIdentity(FormsAuthenticationTicket ticket)
    {
      pTicket = ticket;
    }

    public string AuthenticationType { get { return "Forms"; } }

    public bool   IsAuthenticated { get { return true; } }

    public string Name { get { return pTicket.Name; } }

    public FormsAuthenticationTicket Ticket { get { return pTicket; } }

    public string Userid
    {
      get
      {
        return pTicket.Name;
      }
    }
  }
}