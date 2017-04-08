//<Snippet7>
using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.SessionState;


namespace Samples.AspNet.Session
{

  public class GuidSessionIDManager : SessionIDManager
  {

    public override string CreateSessionID(HttpContext context)
    {
      return Guid.NewGuid().ToString();
    }


    public override bool Validate(string id)
    {
      try
      {
        Guid testGuid = new Guid(id);

        if (id == testGuid.ToString())
          return true;
      }
      catch
      {
      }

      return false;
    }
  }
}
//</Snippet7>

