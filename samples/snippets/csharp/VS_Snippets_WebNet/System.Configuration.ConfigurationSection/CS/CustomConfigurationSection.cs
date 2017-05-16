
using System;
using System.Configuration;
using System.Collections;
using System.Reflection;

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace Samples.AspNet
{


    //<Snippet1>
    // Define a custom section.
    // The CustomSection type allows to define a custom section 
    // programmatically.
    public sealed class CustomSection : 
        ConfigurationSection
    {
        // The collection (property bag) that contains 
        // the section properties.
        private static ConfigurationPropertyCollection _Properties;
        
        // Internal flag to disable 
        // property setting.
        private static bool _ReadOnly;

        // The FileName property.
        private static readonly ConfigurationProperty _FileName =
            new ConfigurationProperty("fileName", 
            typeof(string),"default.txt", 
            ConfigurationPropertyOptions.IsRequired);

        // The MaxUsers property.
        private static readonly ConfigurationProperty _MaxUsers =
            new ConfigurationProperty("maxUsers", 
            typeof(long), (long)1000, 
            ConfigurationPropertyOptions.None);
        
        // The MaxIdleTime property.
        private static readonly ConfigurationProperty _MaxIdleTime =
            new ConfigurationProperty("maxIdleTime", 
            typeof(TimeSpan), TimeSpan.FromMinutes(5), 
            ConfigurationPropertyOptions.IsRequired);

        // CustomSection constructor.
        public CustomSection()
        {
            // Property initialization
            _Properties = 
                new ConfigurationPropertyCollection();

            _Properties.Add(_FileName);
            _Properties.Add(_MaxUsers);
            _Properties.Add(_MaxIdleTime);
       }

      
        // This is a key customization. 
        // It returns the initialized property bag.
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _Properties;
            }
        }


        private new bool IsReadOnly
        {
            get
            {
                return _ReadOnly;
            }
        }

        // Use this to disable property setting.
        private void ThrowIfReadOnly(string propertyName)
        {
            if (IsReadOnly)
                throw new ConfigurationErrorsException(
                    "The property " + propertyName + " is read only.");
        }


        //<Snippet4>
        // Customizes the use of CustomSection
        // by setting _ReadOnly to false.
        // Remember you must use it along with ThrowIfReadOnly.
        protected override object GetRuntimeObject()
        {
            // To enable property setting just assign true to
            // the following flag.
            _ReadOnly = true;
            return base.GetRuntimeObject();
        }

        //</Snippet4>

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
                // With this you disable the setting.
                // Remember that the _ReadOnly flag must
                // be set to true in the GetRuntimeObject.
                ThrowIfReadOnly("FileName");
                this["fileName"] = value;
            }
        }

        [LongValidator(MinValue = 1, MaxValue = 1000000,
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

        [TimeSpanValidator(MinValueString = "0:0:30",
            MaxValueString = "5:00:0",
            ExcludeRange = false)]
        public TimeSpan MaxIdleTime
        {
            get
            {
                return  (TimeSpan)this["maxIdleTime"];
            }
            set
            {
                this["maxIdleTime"] = value;
            }
        }
       
        
    }
    //</Snippet1>
    
    class TestingCustomSection
    {


        //<Snippet2>

        // Create a custom section.
        static void CreateSection()
        {
            try
            {

                CustomSection customSection;

                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                // Create the section entry  
                // in the <configSections> and the 
                // related target section in <configuration>.
                if (config.Sections["CustomSection"] == null)
                {
                    customSection = new CustomSection();
                    config.Sections.Add("CustomSection", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }

        }

        //</Snippet2>

        //<Snippet5>

        static void ChangeDefaults()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                CustomSection customSection =
                    config.Sections["CustomSection"] as CustomSection;

                // This will fail if the ReadOnly flag is
                // set to true in GetRuntimeObject.
                customSection.FileName = "newFile.txt";

                TimeSpan ts = new TimeSpan(0, 15, 0);
                customSection.MaxIdleTime += ts;
                customSection.MaxUsers += 100;

                if (!customSection.ElementInformation.IsLocked)
                {
                    config.Save();
                    ConfigurationManager.RefreshSection("CustomSection");
                }
                else
                    Console.WriteLine("Section was locked, could not update.");
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        //</Snippet5>

        //<Snippet3>

        static void DisplayCustomSectionInformation()
        {

            try
            {
                CustomSection customSection;

                customSection =
                    ConfigurationManager.GetSection("CustomSection") as CustomSection;

                if (customSection == null)
                    Console.WriteLine("Failed to load " + "CustomSection" + ".");
                else
                {
                    // Display specific information
                    Console.WriteLine("Defaults:");
                    Console.WriteLine("File Name:       {0}", customSection.FileName);
                    Console.WriteLine("Max Users:       {0}", customSection.MaxUsers);
                    Console.WriteLine("Max Idle Time:   {0}", customSection.MaxIdleTime);

                    // Display generic information
                    Console.WriteLine("Generic information:");
                    Console.WriteLine("AllowExeDefinition:  {0}",
                        customSection.SectionInformation.AllowExeDefinition.ToString());
                    Console.WriteLine("IsLocked:            {0}",
                        customSection.SectionInformation.IsLocked.ToString());

                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
            
        }

        //</Snippet3>

        static void Main(string[] args)
        {
            Console.WriteLine("[Create a custom section]");
            CreateSection();
            Console.WriteLine("[Display the section information]");
            DisplayCustomSectionInformation();
            Console.WriteLine("[Change the section defaults]");
            ChangeDefaults();
            Console.WriteLine("[Display the new section information]");
            DisplayCustomSectionInformation();
        }

            
    }
}
