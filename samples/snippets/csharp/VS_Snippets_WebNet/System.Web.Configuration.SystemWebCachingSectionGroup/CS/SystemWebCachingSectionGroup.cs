using System;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Samples.AspNet
{
    class UsingSystemWebCachingSectionGroup
    {
        private static string msg;

        static void Main(string[] args)
        {
            string inputStr = String.Empty;

            // Define a regular expression to allow only 
            // alphanumeric inputs that are at most 20 character 
            // long. For instance "/iii:".
            Regex rex = new Regex(@"[^\/w]{1,20}");
            
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

            // Get the <caching> section group.
            SystemWebCachingSectionGroup cachingSectionGroup =
              (SystemWebCachingSectionGroup)configuration.GetSectionGroup(
              "system.web/caching");

            // </Snippet1>

            try
            {

                switch (inputStr)
                {

                    case "/cache":

                        // <Snippet2>

                        // Get the <cache> section.
                        CacheSection cache =
                            cachingSectionGroup.Cache;
                       
                        // Display one of its properties.
                        msg = String.Format(
                        "Cache disable expiration: {0}\n",
                        cache.DisableExpiration);

                        Console.Write(msg);

                    // </Snippet2>

                        break;

                    case "/outcache":

                        // <Snippet3>

                        // Get the .<outputCache> section
                        OutputCacheSection outputCache =
                            cachingSectionGroup.OutputCache;

                        // Display one of its properties.
                        msg = String.Format(
                        "Enable output cache: {0}\n",
                        outputCache.EnableOutputCache.ToString());

                        Console.Write(msg);

                        // </Snippet3>

                        break;

                    case "/outcacheset":

                        // <Snippet4>

                        // Get the .<outputCacheSettings> section
                        OutputCacheSettingsSection outputCacheSettings=
                            cachingSectionGroup.OutputCacheSettings;

                        // Display the number of existing 
                        // profiles.
                        int profilesCount = 
                            outputCacheSettings.OutputCacheProfiles.Count;
                        msg = String.Format(
                        "Number of profiles: {0}\n",
                        profilesCount.ToString());

                        Console.Write(msg);

                        // </Snippet4>

                        break;

                    case "/sql":

                        // <Snippet5>

                        // Get the .<sqlCacheDependency> section
                        SqlCacheDependencySection sqlCacheDependency =
                            cachingSectionGroup.SqlCacheDependency;

                        // Display one of its attributes.
                        msg = String.Format(
                        "Sql cache dependency enabled: {0}\n",
                        sqlCacheDependency.Enabled.ToString());

                        Console.Write(msg);

                        // </Snippet5>

                        break;

                   //  case "/all":

                        // <Snippet6>

		          // Not in use anymore.
                        // StringBuilder allSections = new StringBuilder();

                        
                        // Get the section collection.
                        //  ConfigurationSectionCollection sections=
                        //    cachingSectionGroup.Sections;

                        // Get the number of sections.
                        // int sectionsNumber = sections.Count;

                       //  System.Collections.IEnumerator ienum =
                       //     sections.AllKeys.GetEnumerator();

                        // int i = 0;
                        // allSections.AppendLine();
                        // foreach (Object section in sections)
                        // {
                        //    msg = String.Format(
                        //     "Section{0}:  {1}\n",
                        //    i, section.ToString());
                        //    allSections.AppendLine(msg);
                        //    i++;
                        // }

                        // </Snippet6>

                        // Console.Write(allSections.ToString());
                    //     break;


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
