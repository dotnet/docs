 // <Snippet1>
using System;
using System.IO;
using System.ComponentModel;
using System.Configuration;

namespace Samples.AspNet
{
  
    public sealed class UsingGenericEnumConverter
    {
        public static void GetPermission()
        {
            try
            {
                CustomSection section =
                    ConfigurationManager.GetSection("CustomSection")
                    as CustomSection;
                
                Console.WriteLine("Default Permission: {0}", 
                    section.Permission.ToString());
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetPermission()
        {
            try
            {
                System.Configuration.Configuration config =
                  ConfigurationManager.OpenExeConfiguration(
                  ConfigurationUserLevel.None);

                CustomSection section =
                    config.Sections.Get("CustomSection")
                    as CustomSection;

                section.Permission = 
                    CustomSection.Permissions.FullControl;

                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full); 
                config.Save();

                Console.WriteLine("Current Protection: {0}",
                    section.Permission.ToString());
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
// </Snippet1>
