using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace Samples.AspNet
{

    // Define a custom section.
    public sealed class CustomSection :
       ConfigurationSection
    {
        public CustomSection()
        {
        }

        [ConfigurationProperty("fileName", DefaultValue = "default.txt",
                    IsRequired = true, IsKey = false)]
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\",
            MinLength = 1, MaxLength = 60)]
        public string FileName
        {
            get
            {
                return (string)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }

        [ConfigurationProperty("maxUsers", DefaultValue = (long)10,
            IsRequired = false)]
        [LongValidator(MinValue = 1, MaxValue = 100,
            ExcludeRange = false)]
        public long MaxUsers
        {
            get
            {
                return (long)this["maxUsers"];
            }
            set
            {
                this["maxUsers"] = value;
            }
        }

    }


    // Create the custom section and write it to
    // the configuration file.
    class UsingConfigurationErrorsException
    {
        // Create a custom section.
        static UsingConfigurationErrorsException()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // If the section does not exist in the configuration
            // file, create it and save it to the file.
            if (config.Sections["CustomSection"] == null)
            {
                CustomSection custSection = new CustomSection();
                config.Sections.Add("CustomSection", custSection);
                custSection =
                    config.GetSection("CustomSection") as CustomSection;
                custSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
        }
        
        // Modify a custom section and cause configuration 
        // error exceptions.
        static void ModifyCustomSection()
        {

            try
            {
                // Get the application configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                CustomSection custSection =
                   config.Sections["CustomSection"] as CustomSection;

                // Change the section properties.
                custSection.FileName = "newName.txt";
                
                // Cause an exception.
                custSection.MaxUsers = custSection.MaxUsers + 100;

                if (!custSection.ElementInformation.IsLocked)
                    config.Save();
                else
                    Console.WriteLine(
                        "Section was locked, could not update.");
            }
            catch (ConfigurationErrorsException err)
            {

                string msg = err.Message;
                Console.WriteLine("Message: {0}", msg);

                string fileName = err.Filename;
                Console.WriteLine("Filename: {0}", fileName);

                int lineNumber = err.Line;
                Console.WriteLine("Line: {0}", lineNumber.ToString());

                string bmsg = err.BareMessage;
                Console.WriteLine("BareMessage: {0}", bmsg);

                string source = err.Source;
                Console.WriteLine("Source: {0}", source);

                string st = err.StackTrace;
                Console.WriteLine("StackTrace: {0}", st);

            }
        }

        static void Main(string[] args)
        {
            ModifyCustomSection();
        }

    
    }
}