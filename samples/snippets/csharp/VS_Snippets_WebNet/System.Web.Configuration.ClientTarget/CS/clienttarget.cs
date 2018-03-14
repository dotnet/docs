using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Samples.AspNet
{
  class UsingClientTarget
  {

    private static string alias, userAgent, msg;
    private static ClientTarget clientTarget;


    static void Main(string[] args)
    {
       string inputStr = String.Empty;
       string option = String.Empty;

      // Define a regular expression to allow only 
      // alphanumeric inputs that are at most 20 characters 
      // long. For instance "/iii:".
      Regex rex = new Regex(@"[^\/w]{1,20}");

      // Parse the user's input.      
      if (args.Length < 1)
      {
        // No option entered.
        Console.Write("Input parameter missing.");
        return;
      }
      else
      {
        // Get the user's option.
        inputStr = args[0].ToLower();
        if (!(rex.Match(inputStr)).Success)
        {
          // Wrong option format used.
          Console.Write("Input format not allowed.");
          return;
        }
      }

      // <Snippet1>

      // Get the Web application configuration.
      System.Configuration.Configuration configuration =
          WebConfigurationManager.OpenWebConfiguration(
          "/aspnetTest");

      // Get the <clientTarget> section.
      ClientTargetSection clientTargetSection =
        (ClientTargetSection)configuration.GetSection(
        "system.web/clientTarget");

      // <Snippet2>

      // Get the client target collection.
      ClientTargetCollection clientTargets =
        clientTargetSection.ClientTargets;

      // </Snippet2>

      // </Snippet1>

      try
      {

        switch (inputStr)
        {

          case "/alias":

            // <Snippet3>

            // Get the first client target 
            // in the collection.
            clientTarget = clientTargets[0];
            
            // Get the alias.
            alias = clientTarget.Alias;

            msg = String.Format(
                  "Alias:      {0}\n",
                  alias);
            
            // </Snippet3>

            Console.Write(msg);
      
            break;

          case "/useragent":

            // <Snippet4>
 
            // Get the first client target 
            // in the collection.
            clientTarget = clientTargets[0];

            // Get he user agent.
            userAgent = clientTarget.UserAgent;

            msg = String.Format(
                  "User Agent: {0}\n",
                  userAgent);

            // </Snippet4>
            
            Console.Write(msg);

            break;

          case "/add":

            // <Snippet5>

            // Create a new ClientTarget object.
            clientTarget = new ClientTarget(
              "my alias", "My User Agent"); 
              
            // Add the clientTarget to 
            // the collection.
            clientTargets.Add(clientTarget);

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();

            // </Snippet5>

            alias = clientTarget.Alias;
            userAgent = clientTarget.UserAgent;

            msg = String.Format(
                  "Alias:      {0}\nUser Agent: {1}\n",
                  alias, userAgent);

            
            Console.Write(msg);

            break;

          case "/clear":

            // <Snippet6>
 
            // Clear the client target collection.
            clientTargets.Clear();

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();

            // </Snippet6>

            break;

          case "/remove1":

            // <Snippet7>

            // Create a ClientTarget object.
            clientTarget = new ClientTarget(
              "my alias", "My User Agent");

            // Remove it from the collection
            // (if exists).
            clientTargets.Remove(clientTarget);

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();

            // </Snippet7>

            alias = clientTarget.Alias;
            userAgent = clientTarget.UserAgent;

            msg = String.Format(
                  "Alias:      {0}\nUser Agent: {1}\n",
                  alias, userAgent);

            Console.Write(msg);

            break;
          
          case "/remove2":

            // <Snippet8>

            // Remove the client target with the
            // specified alias from the collection
            // (if exists).
            clientTargets.Remove("my alias");

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();

            // </Snippet8>

            break;

          case "/remove3":

            // <Snippet9>

            // Remove the client target at the 
            // specified index from the collection.
            clientTargets.RemoveAt(0);

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();

            // </Snippet9>

            break;

          case "/all":
            StringBuilder allClientTargets = new StringBuilder();
           
            foreach (ClientTarget clTarget in clientTargets)
            {
              alias = clTarget.Alias;
              userAgent = clTarget.UserAgent;

              msg = String.Format(
                    "Alias:      {0}\nUser Agent: {1}\n",
                    alias, userAgent);
              
              allClientTargets.AppendLine(msg);
            }

            Console.Write(allClientTargets.ToString());
            break;


          default:
            // Option is not allowed..
            Console.Write("Input not allowed.");
            break;
        }
      }
      catch (ArgumentException e)
      {
        // Never display this. Use it for 
        // debugging purposes.
        msg = e.ToString();
      }
    }
  }
}
