// <Snippet31>
using System;
using System.Configuration;
using System.Text;

class UsingConfigurationCollectionElement
{

    // Create a custom section and save it in the 
    // application configuration file.
    static void CreateCustomSection()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Add the custom section to the application
            // configuration file.
            UrlsSection myUrlsSection = (UrlsSection)config.Sections["MyUrls"];

            if (myUrlsSection == null)
            {
                //  The configuration file does not contain the
                // custom section yet. Create it.
                myUrlsSection = new UrlsSection();

                config.Sections.Add("MyUrls", myUrlsSection);

                // Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified); 
            }
            else
                if (myUrlsSection.Urls.Count == 0)
                {

                    // The configuration file contains the
                    // custom section but its element collection is empty.
                    // Initialize the collection. 
                    UrlConfigElement url = new UrlConfigElement();
                    myUrlsSection.Urls.Add(url);

                    // Save the application configuration file.
                    myUrlsSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Modified);
                }

       
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
               config.GetSection("MyUrls") as UrlsSection;

            if (myUrlsSection == null)
                Console.WriteLine("Failed to load UrlsSection.");
            else
            {
                Console.WriteLine("Collection elements contained in the custom section collection:");
                for (int i = 0; i < myUrlsSection.Urls.Count; i++)
                {
                    Console.WriteLine("   Name={0} URL={1} Port={2}",
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

    // Add an element to the custom section collection.
    // This function uses the ConfigurationCollectionElement Add method.
    static void AddCollectionElement()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the custom configuration section.
            UrlsSection myUrlsSection = config.GetSection("MyUrls") as UrlsSection;


            // Add the element to the collection in the custom section.
            if (config.Sections["MyUrls"] != null)
            {
                UrlConfigElement urlElement = new UrlConfigElement();
                urlElement.Name = "Microsoft";
                urlElement.Url = "http://www.microsoft.com";
                urlElement.Port = 8080;
                
                // Use the ConfigurationCollectionElement Add method
                // to add the new element to the collection.
                myUrlsSection.Urls.Add(urlElement);
                
                
                // Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                

                Console.WriteLine("Added collection element to the custom section in the configuration file: {0}",
                    config.FilePath);
                Console.WriteLine();
            }
            else
                Console.WriteLine("You must create the custom section first.");

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("AddCollectionElement: {0}", err.ToString());
        }

    }

    // Remove element from the custom section collection.
    // This function uses one of the ConfigurationCollectionElement 
    // overloaded Remove methods.
    static void RemoveCollectionElement()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the custom configuration section.
            UrlsSection myUrlsSection = config.GetSection("MyUrls") as UrlsSection;


            // Remove the element from the custom section.
            if (config.Sections["MyUrls"] != null)
            {
                UrlConfigElement urlElement = new UrlConfigElement();
                urlElement.Name = "Microsoft";
                urlElement.Url = "http://www.microsoft.com";
                urlElement.Port = 8080;

                // Use one of the ConfigurationCollectionElement Remove 
                // overloaded methods to remove the element from the collection.
                myUrlsSection.Urls.Remove(urlElement);


                // Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);


                Console.WriteLine("Removed collection element from he custom section in the configuration file: {0}",
                    config.FilePath);
                Console.WriteLine();
            }
            else
                Console.WriteLine("You must create the custom section first.");

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("RemoveCollectionElement: {0}", err.ToString());
        }

    }

    // Remove the collection of elements from the custom section.
    // This function uses the ConfigurationCollectionElement Clear method.
    static void ClearCollectionElements()
    {
        try
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the custom configuration section.
            UrlsSection myUrlsSection = config.GetSection("MyUrls") as UrlsSection;


            // Remove the collection of elements from the section.
            if (config.Sections["MyUrls"] != null)
            {
                myUrlsSection.Urls.Clear();


                // Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);


                Console.WriteLine("Removed collection of elements from he custom section in the configuration file: {0}",
                    config.FilePath);
                Console.WriteLine();
            }
            else
                Console.WriteLine("You must create the custom section first.");

        }
        catch (ConfigurationErrorsException err)
        {
            Console.WriteLine("ClearCollectionElements: {0}", err.ToString());
        }

    }

    public static void UserMenu()
    {
        string applicationName =
           Environment.GetCommandLineArgs()[0] + ".exe";
        StringBuilder buffer = new StringBuilder();

        buffer.AppendLine("Application: " + applicationName);
        buffer.AppendLine("Make your selection.");
        buffer.AppendLine("?    -- Display help.");
        buffer.AppendLine("Q,q  -- Exit the application.");
        buffer.Append("1    -- Create a custom section that");
        buffer.AppendLine(" contains a collection of elements.");
        buffer.Append("2    -- Read the custom section that");
        buffer.AppendLine(" contains a collection of custom elements.");
        buffer.Append("3    -- Add a collection element to");
        buffer.AppendLine(" the custom section.");
        buffer.Append("4    -- Remove a collection element from");
        buffer.AppendLine(" the custom section.");
        buffer.Append("5    -- Clear the collection of elements from");
        buffer.AppendLine(" the custom section.");
        
        Console.Write(buffer.ToString());
    }

    // Obtain user's input and provide
    // feedback.
    static void Main(string[] args)
    {
        // Define user selection string.
        string selection;

        // Get the name of the application.
        string appName =
          Environment.GetCommandLineArgs()[0];

        // Get user selection.
        while (true)
        {

            UserMenu();
            Console.Write("> ");
            selection = Console.ReadLine();
            if (selection != string.Empty)
                break;
        }

        while (selection.ToLower() != "q")
        {
            // Process user's input.
            switch (selection)
            {
                case "1":
                    // Create a custom section and save it in the 
                    // application configuration file.
                    CreateCustomSection();
                    break;

                case "2":
                    // Read the custom section from the
                    // application configuration file.
                    ReadCustomSection();
                    break;

                case "3":
                    // Add a collection element to the
                    // custom section.
                    AddCollectionElement();
                    break;

                case "4":
                    // Remove a collection element from the
                    // custom section.
                    RemoveCollectionElement();
                    break;

                case "5":
                    // Clear the collection of elements from the
                    // custom section.
                    ClearCollectionElements();
                    break;

                default:
                    UserMenu();
                    break;
            }
            Console.Write("> ");
            selection = Console.ReadLine();
        }
    }
}
// </Snippet31>