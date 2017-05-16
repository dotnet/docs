using System;

namespace SDKSample
{

  // Need this to bind to, since System.DateTime is a struct (ie not a type with a default constructor)
  public class DateTime
  {
    public string Now
    {
      get { return System.DateTime.Now.ToString(); }
    }
  }
}
