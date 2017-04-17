using System.Security.Principal;

namespace Samples.AspNet.Security
{

  public class MyPrincipal : WindowsPrincipal
  {
    public MyPrincipal(WindowsIdentity identity) : base(identity)
    {
    }

    public new string Domain
    {
      get
      {
        return this.Identity.Name.Split('\\')[0];
      }
    }

    public new string Userid
    {
      get
      {
        return this.Identity.Name.Split('\\')[1];
      }
    }
  }
}