// <Snippet31>
using System;
using System.Configuration;


class UsingConfigurationCollectionAttribute
{

    // Create a custom section and save it in the 
    // application configuration file.
    static void CreateCustomSection()
    {
        try
        {

            // Create a custom configuration section.
            UrlsSection myUrlsSection = new UrlsSection();

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Add the custom section to the application
            // configuration file.
            if (config.Sections["MyUrls"] == null)
            {
                config.Sections.Add("MyUrls", myUrlsSection);
            }

           
            // Save the application configuration file.
            myUrlsSection.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("Created custom section in the application configuration file: {0}",
                config.FilePath);
            Console.WriteLine();

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("CreateCustomSection: {0}", err.ToString());
        }

    }

    static void ReadCustomSection()
    {
        try
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None) as Configuration;

            // Read and display the custom section.
            UrlsSection myUrlsSection =
               ConfigurationManager.GetSection("MyUrls") as UrlsSection;

            if (myUrlsSection == null)
                Console.WriteLine("Failed to load UrlsSection.");
            else
            {
                Console.WriteLine("URLs defined in the configuration file:");
                for (int i = 0; i < myUrlsSection.Urls.Count; i++)
                {
                    Console.WriteLine("  Name={0} URL={1} Port={2}",
                        myUrlsSection.Urls[i].Name,
                        myUrlsSection.Urls[i].Url,
                        myUrlsSection.Urls[i].Port);
                }
            }
          
        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("ReadCustomSection(string): {0}", err.ToString());
        }

    }
    
    static void Main(string[] args)
    {
       
        // Get the name of the application.
        string appName =
            Environment.GetCommandLineArgs()[0];

        // Create a custom section and save it in the 
        // application configuration file.
        CreateCustomSection();

        // Read the custom section saved in the
        // application configuration file.
        ReadCustomSection();

        Console.WriteLine();
        Console.WriteLine("Enter any key to exit.");

        Console.ReadLine();
    }
}
// </Snippet31>