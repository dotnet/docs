//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;

namespace Samples.AspNet
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


        [ConfigurationProperty("maxIdleTime")]
        [TypeConverter(typeof(TsMinutesConverter))]
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

    //<Snippet2>
    public sealed class TsMinutesConverter :
        ConfigurationConverterBase
    {
        internal bool ValidateType(object value, Type expected)
        {
            bool result;

            if ((value != null) &&
                (value.GetType() != expected))
                result = false;
            else
                result = true;

            return result;
        }

        //<Snippet3>
        public override bool CanConvertTo(
            ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(string));
        }
        //</Snippet3>

        //<Snippet4>
        public override bool CanConvertFrom(
            ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(string));
        }
        //</Snippet4>

        public override object ConvertTo(
            ITypeDescriptorContext ctx, CultureInfo ci,
            object value, Type type)
        {
            ValidateType(value, typeof(TimeSpan));

            long data = (long)(((TimeSpan)value).TotalMinutes);

            return data.ToString(CultureInfo.InvariantCulture);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext ctx, CultureInfo ci, object data)
        {

            long min = long.Parse((string)data,
                CultureInfo.InvariantCulture);

            return TimeSpan.FromMinutes((double)min);
        }
    }
    //</Snippet2>

    class UsingConfigutationConverterBase
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


        // Change custom section and write it to disk.
        static void SerializeCustomSection()
        {
            try
            {
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                CustomSection customSection =
                    config.Sections.Get("CustomSection")
                    as CustomSection;

                TimeSpan ts =
                    new TimeSpan(1, 30, 30);

                customSection.MaxIdleTime = ts;

                config.Save();

                string maxIdleTime =
                    customSection.MaxIdleTime.ToString();

                Console.WriteLine("New max idle time: {0}",
                    maxIdleTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        // Read custom section from disk.
        static void DeserializeCustomSection()
        {

            try
            {
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                CustomSection customSection =
                    config.Sections.Get("CustomSection")
                    as CustomSection;

                TimeSpan maxIdleTime =
                    customSection.MaxIdleTime;


                Console.WriteLine("Max idle time: {0}",
                    maxIdleTime.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


        static void Main(string[] args)
        {
            CreateSection();
            SerializeCustomSection();
            DeserializeCustomSection();

        }
    }
}
//</Snippet1>
