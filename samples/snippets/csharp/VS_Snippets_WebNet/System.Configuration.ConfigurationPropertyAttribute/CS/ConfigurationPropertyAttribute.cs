//<Snippet21>
using System;
using System.Configuration;

public class UsingConfigurationPropertyAttribute
{

    // Create a custom section and save it in the 
    // application configuration file.
    static void CreateCustomSection()
    {
        try
        {

            // Create a custom configuration section.
            UrlsSection customSection = new UrlsSection();

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Add the custom section to the application
            // configuration file.
            if (config.Sections["CustomSection"] == null)
            {
                config.Sections.Add("CustomSection", customSection);
            }

           
            // Save the application configuration file.
            customSection.SectionInformation.ForceSave = true;
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
            UrlsSection customSection =
                config.GetSection("CustomSection") as UrlsSection;
            Console.WriteLine("Reading custom section from the configuration file.");
            Console.WriteLine("Section name: {0}", customSection.Name);
            Console.WriteLine("Url: {0}", customSection.Url);
            Console.WriteLine("Port: {0}", customSection.Port);
            Console.WriteLine();
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

        Console.WriteLine("Press enter to exit.");

        Console.ReadLine();
    }
}
//</Snippet21>
