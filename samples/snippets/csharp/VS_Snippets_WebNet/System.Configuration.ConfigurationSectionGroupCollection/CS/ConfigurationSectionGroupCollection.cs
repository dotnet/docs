// <Snippet1>
using System;
using System.Configuration;
using System.Collections;

namespace Samples.Config
{


    // Define a custom section.
    public sealed class CustomSection :
        ConfigurationSection
    {

        public CustomSection()
        { }

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
      
        [ConfigurationProperty("maxUsers", DefaultValue = (long)10000,
            IsRequired = false)]
        [LongValidator(MinValue = 1, MaxValue = 10000000,
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
       
        [ConfigurationProperty("maxIdleTime",
            DefaultValue = "0:10:0",
            IsRequired = false)]
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

    // Define a custom section group.
    public sealed class CustomSectionGroup :
        ConfigurationSectionGroup
    {

        public CustomSectionGroup()
        {
            
        }

        public CustomSection Custom
        {
            get { return (CustomSection) 
                Sections.Get("CustomSection");}
        }

    }

    class UsingCustomSectionGroupCollection
    {

      
        // Create a custom section group.
        static void CreateSectionGroup()
        {
            try
            {

                CustomSectionGroup customSectionGroup;
     
                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                // Create the section group entry  
                // in the <configSections> and the 
                // related target section in <configuration>.
                if (config.SectionGroups["CustomGroup"] == null)
                {
                    customSectionGroup = new CustomSectionGroup();
                    config.SectionGroups.Add("CustomGroup", 
                        customSectionGroup);
                    customSectionGroup.ForceDeclaration(true);
                    config.Save(ConfigurationSaveMode.Full);
                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }

        }

        //<Snippet2>
        // Get the collection group keys i.e.,
        // the group names.
        //static void GetAllKeys()
        //{

        //    try
        //    {
        //        System.Configuration.Configuration config =
        //        ConfigurationManager.OpenExeConfiguration(
        //        ConfigurationUserLevel.None);

        //        ConfigurationSectionGroupCollection groups =
        //            config.SectionGroups;
        //        groups.
        //        foreach (string name in groups.AllKeys)
        //        {
        //            Console.WriteLine(
        //             "Key value: {0}", name);
        //        }


        //    }
        //    catch (ConfigurationErrorsException err)
        //    {
        //        Console.WriteLine(err.ToString());
        //    }
        //}
        //</Snippet2>

        //<Snippet3>
        static void Clear()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                config.SectionGroups.Clear();

                config.Save(ConfigurationSaveMode.Full);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet3>

        //<Snippet4>
        static void GetGroup()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionGroup customGroup =
                    config.SectionGroups.Get("CustomGroup");


                if (customGroup == null)
                    Console.WriteLine(
                        "Failed to load CustomSection.");
                else
                {
                    // Display section information
                    Console.WriteLine("Section group name:       {0}",
                        customGroup.SectionGroupName);
                    Console.WriteLine("Name:       {0}",
                        customGroup.Name);
                    Console.WriteLine("Type:   {0}",
                        customGroup.Type);

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

                ConfigurationSectionGroupCollection groups =
                    config.SectionGroups;

                IEnumerator groupEnum =
                    groups.GetEnumerator();

                //<Snippet6>
                int i = 0;
                while (groupEnum.MoveNext())
                {
                    string groupName = groups.GetKey(i);
                    Console.WriteLine(
                        "Group name: {0}", groupName);
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
        // Get the collection keys i.e., the
        // group names.
        static void GetKeys()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionGroupCollection groups =
                    config.SectionGroups;

                foreach (string key in groups.Keys)
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

                ConfigurationSectionGroupCollection groups =
                    config.SectionGroups;

                ConfigurationSectionGroup group1 =
                    groups.Get("system.net");

                ConfigurationSectionGroup group2 =
                groups.Get("system.web");


                Console.WriteLine(
                     "Group1: {0}", group1.Name);

                Console.WriteLine(
                    "Group2: {0}", group2.Name);

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

                ConfigurationSectionGroup customGroup =
                    config.SectionGroups.Get("CustomGroup");

                if (customGroup != null)
                {
                    config.SectionGroups.Remove("CustomGroup");
                    config.Save(ConfigurationSaveMode.Full);
                }
                else
                    Console.WriteLine(
                        "CustomGroup does not exists.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet9>



        // Add custom section to the group.
        static void AddSection()
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
                ConfigurationSectionGroup customGroup;
                customGroup = config.SectionGroups.Get("CustomGroup");

                if (customGroup.Sections.Get("CustomSection") == null)
                {
                    customSection = new CustomSection();
                    customGroup.Sections.Add("CustomSection",
                        customSection);
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }

        }

        // Exercise the collection.
        // Uncomment the function you want to exercise.
        // Start with CreateSectionGroup().
        static void Main(string[] args)
        {
            CreateSectionGroup();
            AddSection();
            // GetAllKeys();
            // GetGroup();
            
            // GetEnumerator();
            
            // GetKeys();
            
            // GetItems();

            // Remove();
            // Clear();
        }


    }
}
// </Snippet1>
