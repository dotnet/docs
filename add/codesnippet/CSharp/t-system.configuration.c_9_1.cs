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

      // Create a CommaDelimitedStringCollection object.
      CommaDelimitedStringCollection myStrCollection =
        new CommaDelimitedStringCollection();

      for (int i = 0; i < authorizationRuleCollection.Count; i++)
      {
        if (authorizationRuleCollection.Get(i).Action.ToString().ToLower() 
          == "allow")
        {
          // Add values to the CommaDelimitedStringCollection object.
          myStrCollection.AddRange(
            authorizationRuleCollection.Get(i).Users.ToString().Split(
            ",".ToCharArray()));
        }
      }

      Console.WriteLine("Allowed Users: {0}",
        myStrCollection.ToString());

      // Count the elements in the collection.
      Console.WriteLine("Allowed User Count: {0}", 
        myStrCollection.Count);

      // Call the Contains method.
      Console.WriteLine("Contains 'userName1': {0}",
        myStrCollection.Contains("userName1"));

      // Determine the index of an element
      // in the collection.
      Console.WriteLine("IndexOf 'userName0': {0}",
        myStrCollection.IndexOf("userName0"));

      // Call IsModified.
      Console.WriteLine("IsModified: {0}",
        myStrCollection.IsModified);

      // Call IsReadyOnly.
      Console.WriteLine("IsReadOnly: {0}",
        myStrCollection.IsReadOnly);

      Console.WriteLine();
      Console.WriteLine("Add a user name to the collection.");
      // Insert a new element in the collection.
      myStrCollection.Insert(myStrCollection.Count, "userNameX");

      Console.WriteLine("Collection Value: {0}",
        myStrCollection.ToString());

      Console.WriteLine();
      Console.WriteLine("Remove a user name from the collection.");
      // Remove an element of the collection.
      myStrCollection.Remove("userNameX");

      Console.WriteLine("Collection Value: {0}",
        myStrCollection.ToString());

      // Display and wait
      Console.ReadLine();
    }
  }
}