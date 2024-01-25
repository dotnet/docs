
using System;
using System.Configuration;

static class Program
{
    static void Main()
    {
    }
    // <Snippet1>
    static void ToggleConfigEncryption(string exeFile)
    {
        // Get the application path needed to obtain
        // the application configuration file.

        // Takes the executable file name without the
        // .config extension.
        var exePath = exeFile.Replace(".config", "");

        try
        {
            // Open the configuration file and retrieve
            // the connectionStrings section.
            Configuration config = ConfigurationManager.
                OpenExeConfiguration(exePath);

            var section =
                config.GetSection("connectionStrings")
                as ConnectionStringsSection;

            if (section != null)
            {
                if (section.SectionInformation.IsProtected)
                {
                    // Remove encryption.
                    section.SectionInformation.UnprotectSection();
                }
                else
                {
                    // Encrypt the section.
                    section.SectionInformation.ProtectSection(
                        "DataProtectionConfigurationProvider");
                }
            }
            // Save the current configuration.
            config.Save();

            Console.WriteLine("Protected={0}",
                section?.SectionInformation.IsProtected);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    // </Snippet1>
}
