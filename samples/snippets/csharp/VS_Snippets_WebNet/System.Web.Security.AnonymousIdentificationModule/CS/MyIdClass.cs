using System;

namespace Samples.AspNet.Security
{

  public class MyIdClass
  {
    public static string GetAnonymousId()
    {
      return "(" + Guid.NewGuid().ToString() + ")" + DateTime.UtcNow.ToString();
    }

    public static void LogAnonymousId(string anonymousId)
    {
      throw new Exception(anonymousId);
    }
  }
}