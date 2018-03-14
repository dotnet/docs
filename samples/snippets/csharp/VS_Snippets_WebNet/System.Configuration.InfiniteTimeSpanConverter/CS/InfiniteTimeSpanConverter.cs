 // <Snippet1>
using System;
using System.IO;
using System.ComponentModel;
using System.Configuration;

namespace Samples.AspNet
{
  
    public sealed class UsingInfiniteTimeSpanConverter
    {
        public static void GetTimeDelay()
        {
            try
            {
                CustomSection section =
                    ConfigurationManager.GetSection("CustomSection")
                    as CustomSection;
                
                Console.WriteLine("timeDelay: {0}", 
                    section.TimeDelay.ToString());
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetTimeDelay()
        {
            try
            {
                System.Configuration.Configuration config =
                  ConfigurationManager.OpenExeConfiguration(
                  ConfigurationUserLevel.None);

                CustomSection section =
                    config.Sections.Get("CustomSection")
                    as CustomSection;

                TimeSpan td = 
                    new TimeSpan();

                td =
                    TimeSpan.FromMinutes(
                    DateTime.Now.Minute);

                section.TimeDelay = td;

                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full); 
                config.Save();

                Console.WriteLine("timeDelay: {0}",
                    section.TimeDelay.ToString());
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
// </Snippet1>
