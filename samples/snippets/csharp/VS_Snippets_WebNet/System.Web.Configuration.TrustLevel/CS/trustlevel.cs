// <Snippet1>
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingTrustLevel
  {
    static void Main(string[] args)
    {
      try
      {
        // Display title.
        Console.WriteLine("ASP.NET TrustLevel Info");
        Console.WriteLine();

        // <Snippet2>
        // Instantiate a new TrustLevel object.
        TrustLevel TrustLevel1 =
          new TrustLevel("myLevel1", "myLevel1.config");
        // </Snippet2>

        // <Snippet3>
        // Get the Name of the TrustLevel object.
        Console.WriteLine("Name: {0}", TrustLevel1.Name);
        // </Snippet3>

        // <Snippet4>
        // Instantiate a new TrustLevel object.
        TrustLevel TrustLevel2 =
          new TrustLevel("myLevel2", "myLevel2.config");
        // </Snippet4>

        // <Snippet5>
        // Get the PolicyFile of the TrustLevel object.
        Console.WriteLine("PolicyFile: {0}", TrustLevel2.PolicyFile);
        // </Snippet5>
      }

      catch (Exception e)
      {
        // Unknown error.
        Console.WriteLine(e.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}
// </Snippet1>