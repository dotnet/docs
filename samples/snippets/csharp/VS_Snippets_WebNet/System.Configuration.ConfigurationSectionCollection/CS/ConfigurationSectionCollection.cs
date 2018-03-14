// <Snippet1>
using System;
using System.Configuration;
using System.Collections;

namespace Samples.AspNet.Configuration
{


    // Define a custom section programmatically.
    public sealed class CustomSection :
        ConfigurationSection
    {
        // The collection (property bag) that contains 
        // the section properties.
        private static ConfigurationPropertyCollection _Properties;


        // The FileName property.
        private static readonly ConfigurationProperty _FileName =
            new ConfigurationProperty("fileName",
            typeof(string), "default.txt",
            ConfigurationPropertyOptions.IsRequired);

        // The MasUsers property.
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
                return (TimeSpan)this["maxIdleTime"];
            }
            set
            {
                this["maxIdleTime"] = value;
            }
        }


    }


    class UsingCustomSectionCollection
    {

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

        //<Snippet2>
        static void GetAllKeys()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);


                ConfigurationSectionCollection sections =
                    config.Sections;

                foreach (string key in sections.Keys)
                {
                    Console.WriteLine(
                     "Key value: {0}", key);
                }


            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        //</Snippet2>

        //<Snippet3>
        static void Clear()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                config.Sections.Clear();

                config.Save(ConfigurationSaveMode.Full);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        //</Snippet3>

        //<Snippet4>
        static void GetSection()
        {

            try
            {
                CustomSection customSection =
                    ConfigurationManager.GetSection(
                    "CustomSection") as CustomSection;

                if (customSection == null)
                    Console.WriteLine(
                        "Failed to load CustomSection.");
                else
                {
                    // Display section information
                    Console.WriteLine("Defaults:");
                    Console.WriteLine("File Name:       {0}",
                        customSection.FileName);
                    Console.WriteLine("Max Users:       {0}",
                        customSection.MaxUsers);
                    Console.WriteLine("Max Idle Time:   {0}",
                        customSection.MaxIdleTime);

                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet4>

        //<Snippet5>
        static void GetEnumerator()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);


                ConfigurationSectionCollection sections =
                    config.Sections;

                IEnumerator secEnum =
                    sections.GetEnumerator();

                //<Snippet6>
                int i = 0;
                while (secEnum.MoveNext())
                {
                    string setionName = sections.GetKey(i);
                    Console.WriteLine(
                        "Section name: {0}", setionName);
                    i += 1;
                }
                //</Snippet6>
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet5>


        //<Snippet7>
        static void GetKeys()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections =
                    config.Sections;


                foreach (string key in sections.Keys)
                {


                    Console.WriteLine(
                     "Key value: {0}", key);
                }


            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        //</Snippet7>

        //<Snippet8>
        static void GetItems()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections =
                    config.Sections;


                ConfigurationSection section1 =
                    sections["runtime"];

                ConfigurationSection section2 =
                    sections[0];

                Console.WriteLine(
                     "Section1: {0}", section1.SectionInformation.Name);

                Console.WriteLine(
                    "Section2: {0}", section2.SectionInformation.Name);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        //</Snippet8>

        //<Snippet9>
        static void Remove()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                CustomSection customSection =
                    config.GetSection(
                    "CustomSection") as CustomSection;


                if (customSection != null)
                {
                    config.Sections.Remove("CustomSection");
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
                else
                    Console.WriteLine(
                        "CustomSection does not exists.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet9>


        //<Snippet10>
        static void AddSection()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                CustomSection customSection =
                    new CustomSection();


                string index =
                    config.Sections.Count.ToString();

                customSection.FileName =
                    "newFile" + index + ".txt";

                string sectionName = "CustomSection" + index;

                TimeSpan ts = new TimeSpan(0, 15, 0);
                customSection.MaxIdleTime = ts;
                customSection.MaxUsers = 100;

                config.Sections.Add(sectionName, customSection);
                customSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet10>


        // Exercise the collection.
        // Uncomment the function you want to exercise.
        // Start with CreateSection().
        static void Main(string[] args)
        {
            CreateSection();
            // AddSection();
            // GetSection();
            // GetEnumerator();
            // GetAllKeys();
            // GetKeys();
            // GetItems();

            // Remove();
            // Clear();
        }


    }
}
// </Snippet1>
