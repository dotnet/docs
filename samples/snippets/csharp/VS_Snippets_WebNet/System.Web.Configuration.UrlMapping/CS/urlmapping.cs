using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Samples.AspNet
{
  class UsingUrlMapping
  {

    private static string shownUrl, mappedUrl, msg;
    private static UrlMapping urlMapping;


    static void Main(string[] args)
    {
      string inputStr = String.Empty;
      string optionStr = String.Empty;
      string parm1 = String.Empty;
      string parm2 = String.Empty;
    
      // Define a regular expression to allow only 
      // alphanumeric inputs that are at most 20 character 
      // long. For instance "/iii:".
      Regex rex = new Regex(@"[^\/w]{1,20}");
      parm1 = "none";
      parm2 = "false";

      // Parse the user's input.      
      if (args.Length < 1)
      {
        // No option entered.
        Console.Write("Input parameters missing.");
        return;
      }
      else
      {
        // Get the user's options.
        inputStr = args[0].ToLower();


        if (args.Length == 3)
        {
          // These to be used when serializing 
          // (writing) to the configuration file.
          parm1 = args[1].ToLower();
          parm2 = args[2].ToLower();

          if (!(rex.Match(parm1)).Success &&
            !(rex.Match(parm2)).Success)
          {
            // Wrong option format used.
            Console.Write("Input format not allowed.");
            return;
          }
        }

        if (!(rex.Match(inputStr)).Success )
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

      // Get the <urlMapping> section.
      UrlMappingsSection urlMappingSection =
        (UrlMappingsSection)configuration.GetSection(
        "system.web/urlMappings");

      // <Snippet2>

      // Get the url mapping collection.
      UrlMappingCollection urlMappings =
        urlMappingSection.UrlMappings;

      // </Snippet2>

      // </Snippet1>

      try
      {

        switch (inputStr)
        {

          case "/add":

            // <Snippet3>

            // Create a new UrlMapping object.
            urlMapping = new UrlMapping(
              "~/home.aspx", "~/default.aspx?parm1=1");
              
            // Add the urlMapping to 
            // the collection.
            urlMappings.Add(urlMapping);

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();

            // </Snippet3>

            shownUrl = urlMapping.Url;
            mappedUrl = urlMapping.MappedUrl;

            msg = String.Format(
            "Shown URL: {0}\nMapped URL:  {1}\n",
            shownUrl, mappedUrl);


            Console.Write(msg);

            break;

          case "/clear":

            // <Snippet4>

            // Clear the url mapping collection.
            urlMappings.Clear();

            // Update the configuration file.

            // Define the save modality.
            ConfigurationSaveMode saveMode =
              ConfigurationSaveMode.Minimal;

            urlMappings.EmitClear =
               Convert.ToBoolean(parm2);

            if (parm1 == "none")
            {
              if (!urlMappingSection.IsReadOnly())
                configuration.Save();
              msg = String.Format(
              "Default modality, EmitClear:      {0}",
              urlMappings.EmitClear.ToString());
            }
            else
            {
              if (parm1 == "full")
                saveMode = ConfigurationSaveMode.Full;
              else
                if (parm1 == "modified")
                  saveMode = ConfigurationSaveMode.Modified;

              if (!urlMappingSection.IsReadOnly())
                configuration.Save(saveMode);

              msg = String.Format(
               "Save modality:      {0}",
               saveMode.ToString());
            }

            // </Snippet4>

            Console.Write(msg);

            break;

          case "/removeobject":

            // <Snippet5>

            // Create a UrlMapping object.
            urlMapping = new UrlMapping(
              "~/home.aspx", "~/default.aspx?parm1=1");

            // Remove it from the collection
            // (if exists).
            urlMappings.Remove(urlMapping);

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();

            // </Snippet5>

            shownUrl = urlMapping.Url;
            mappedUrl = urlMapping.MappedUrl;

            msg = String.Format(
            "Shown URL:      {0}\nMapped URL: {1}\n",
            shownUrl, mappedUrl);

            Console.Write(msg);

            break;

          case "/removeurl":

            // <Snippet6>

            // Remove the URL with the
            // specified name from the collection
            // (if exists).
            urlMappings.Remove("~/default.aspx");

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();

            // </Snippet6>

            break;

          case "/removeindex":

            // <Snippet7>

            // Remove the URL at the 
            // specified index from the collection.
            urlMappings.RemoveAt(0);

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();

            // </Snippet7>

            break;

          case "/all":

            // <Snippet8>

            StringBuilder allUrlMappings = new StringBuilder();

            foreach (UrlMapping url_Mapping in urlMappings)
            {

              // <Snippet9>
              shownUrl = url_Mapping.Url;
              // </Snippet9>

              // <Snippet10>
              mappedUrl = url_Mapping.MappedUrl;
              // </Snippet10>

              msg = String.Format(
                    "Shown URL:  {0}\nMapped URL: {1}\n",
                    shownUrl, mappedUrl);

              allUrlMappings.AppendLine(msg);
            }

          // </Snippet8>

            Console.Write(allUrlMappings.ToString());
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
