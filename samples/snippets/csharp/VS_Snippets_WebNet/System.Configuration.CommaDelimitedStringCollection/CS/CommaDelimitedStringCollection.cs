// <Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace Samples.AspNet.Config
{
  class CommaDelimitedStrCollection
  {
    static void Main(string[] args)
    {
      // Display title and info.
      Console.WriteLine("ASP.NET Configuration Info");
      Console.WriteLine("Type: CommaDelimitedStringCollection");
      Console.WriteLine();

      // Set the path of the config file.
      string configPath = "/aspnet";

      // Get the Web application configuration object.
      Configuration config = 
        WebConfigurationManager.OpenWebConfiguration(configPath);

      // Get the section related object.
      AuthorizationSection configSection =
        (AuthorizationSection)config.GetSection("system.web/authorization");

      // Get the authorization rule collection.
      AuthorizationRuleCollection authorizationRuleCollection = 
        configSection.Rules;

      // <Snippet2>
      // Create a CommaDelimitedStringCollection object.
      CommaDelimitedStringCollection myStrCollection =
        new CommaDelimitedStringCollection();
      // </Snippet2>

      for (int i = 0; i < authorizationRuleCollection.Count; i++)
      {
        if (authorizationRuleCollection.Get(i).Action.ToString().ToLower() 
          == "allow")
        {
          // <Snippet3>
          // Add values to the CommaDelimitedStringCollection object.
          myStrCollection.AddRange(
            authorizationRuleCollection.Get(i).Users.ToString().Split(
            ",".ToCharArray()));
          // </Snippet3>
        }
      }

      Console.WriteLine("Allowed Users: {0}",
        myStrCollection.ToString());

      // <Snippet4>
      // Count the elements in the collection.
      Console.WriteLine("Allowed User Count: {0}", 
        myStrCollection.Count);
      // </Snippet4>

      // <Snippet5>
      // Call the Contains method.
      Console.WriteLine("Contains 'userName1': {0}",
        myStrCollection.Contains("userName1"));
      // </Snippet5>

      // <Snippet6>
      // Determine the index of an element
      // in the collection.
      Console.WriteLine("IndexOf 'userName0': {0}",
        myStrCollection.IndexOf("userName0"));
      // </Snippet6>

      // <Snippet7>
      // Call IsModified.
      Console.WriteLine("IsModified: {0}",
        myStrCollection.IsModified);
      // </Snippet7>

      // <Snippet8>
      // Call IsReadyOnly.
      Console.WriteLine("IsReadOnly: {0}",
        myStrCollection.IsReadOnly);
      // </Snippet8>

      Console.WriteLine();
      Console.WriteLine("Add a user name to the collection.");
      // <Snippet9>
      // Insert a new element in the collection.
      myStrCollection.Insert(myStrCollection.Count, "userNameX");
      // </Snippet9>

      Console.WriteLine("Collection Value: {0}",
        myStrCollection.ToString());

      Console.WriteLine();
      Console.WriteLine("Remove a user name from the collection.");
      // <Snippet10>
      // Remove an element of the collection.
      myStrCollection.Remove("userNameX");
      // </Snippet10>

      Console.WriteLine("Collection Value: {0}",
        myStrCollection.ToString());

      // Display and wait
      Console.ReadLine();
    }
  }
}
// </Snippet1>