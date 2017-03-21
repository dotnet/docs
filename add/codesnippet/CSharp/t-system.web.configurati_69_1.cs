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
  class UsingTrustLevelCollection
  {
    static void Main(string[] args)
    {
      try
      {
        // Display title.
        Console.WriteLine("ASP.NET TrustLevelCollection Info");
        Console.WriteLine();
        
        // Instantiate a new TrustLevelCollection object.
        TrustLevelCollection TrustLevelCollection1 = 
          new TrustLevelCollection();

        // Add a new TrustLevel to the collection.
        TrustLevelCollection1.Add(new TrustLevel("Level1", "Level1.config"));

        // Create a new TrustLevel object.
        TrustLevel TrustLevel2 = 
          new TrustLevel("Level2", "Level2.config");

        // Set the TrustLevel object within the collection.
        TrustLevelCollection1.Set(1, TrustLevel2);

        // Display item details of the collection.
        for (int i = 0; i < TrustLevelCollection1.Count; i++)
        {
          Console.WriteLine("Collection item {0}", i);
          Console.WriteLine("Name: {0}", 
            TrustLevelCollection1.Get(i).Name);
          Console.WriteLine("PolicyFile: {0}", 
            TrustLevelCollection1.Get(i).PolicyFile);
          Console.WriteLine();
        }
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