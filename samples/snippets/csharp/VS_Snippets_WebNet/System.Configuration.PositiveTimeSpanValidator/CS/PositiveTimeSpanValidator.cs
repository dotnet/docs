// <Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace Samples.AspNet
{
    // Implements a custom validator attribute. 
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CustomValidatorAttribute :
        ConfigurationValidatorAttribute
    {
        public CustomValidatorAttribute()
        {
        }

        public CustomValidatorAttribute(Type validator)
            : base(validator)
        {
        }

        new public Type ValidatorType
        {
            get
            { return GetType(); }
        }


        public override ConfigurationValidatorBase ValidatorInstance
        {
            get
            {
                // <Snippet2>
                // Create validator.
                return new PositiveTimeSpanValidator();
                // </Snippet2>
            }
        }
    }

    // Implements a custom section class.
    public class SampleSection : ConfigurationSection
    {
        [ConfigurationProperty("name", DefaultValue = "MyBuildRoutine",
                   IsRequired = true)]
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\",
      MinLength = 1, MaxLength = 60)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("BuildStartTime", IsRequired = true,
          DefaultValue = "09:00:00")]
        public TimeSpan BuildStartTime
        {
            get
            {
                TimeSpanConverter myTSC = new TimeSpanConverter();
                return (TimeSpan)this["BuildStartTime"];
            }
            set
            {
                this["BuildStartTime"] = value.ToString();
            }
        }

        [ConfigurationProperty("BuildEndTime", IsRequired = true,
          DefaultValue = "17:00:00")]
        public TimeSpan BuildEndTime
        {
            get
            {
                TimeSpanConverter myTSC = new TimeSpanConverter();
                return (TimeSpan)this["BuildEndTime"];
            }
            set
            {
                this["BuildEndTime"] = value.ToString();
            }

        }
    }

    // Implements the console user interface.
    class TestingCustomValidatorAttribute
    {
        // Shows how to use the ValidatorInstance method.
        public static void GetCustomValidatorInstance()
        {
            ConfigurationValidatorBase valBase;
            CustomValidatorAttribute customValAttr;
            customValAttr = new CustomValidatorAttribute();

            SampleSection sampleSection =
              ConfigurationManager.GetSection("MyDailyProcess") as SampleSection;

            TimeSpanConverter myTSC = new TimeSpanConverter();
            TimeSpan StartTimeSpan = (TimeSpan)myTSC.ConvertFromString(sampleSection.BuildStartTime.ToString());
            TimeSpan EndTimeSpan = (TimeSpan)myTSC.ConvertFromString(sampleSection.BuildEndTime.ToString());
            TimeSpan resultTimeSpan = EndTimeSpan - StartTimeSpan;

            try
            {
                // <Snippet3>
                // Determine if the Validator can validate
                // the type it contains.
                valBase = customValAttr.ValidatorInstance;
                if (valBase.CanValidate(resultTimeSpan.GetType()))
                {
                    // <Snippet4>
                    // Validate the TimeSpan using a
                    // custom PositiveTimeSpanValidator.
                    valBase.Validate(resultTimeSpan);
                    // </Snippet4>
                }
                // </Snippet3>
            }
            catch (ArgumentException e)
            {
                // Store error message.
                string msg = e.Message.ToString();
#if DEBUG
                Console.WriteLine("Error: {0}", msg);
#endif
            }
        }

        // Create required sections.
        static void CreateSection()
        {
            // Get the current configuration (file).
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);

            // Define the sample section.
            SampleSection sampleSection;

            // Create the handler section named MyDailyProcess 
            // in the <configSections>. Also, create the 
            // <MyDailyProcess> target section
            // in <configuration>.
            if (config.Sections["MyDailyProcess"] == null)
            {
                sampleSection = new SampleSection();
                config.Sections.Add("MyDailyProcess", sampleSection);
                sampleSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
        }

        static void DisplaySectionProperties()
        {
            SampleSection sampleSection =
               ConfigurationManager.GetSection("MyDailyProcess") as SampleSection;

            if (sampleSection == null)
                Console.WriteLine("Failed to load section.");
            else
            {
                Console.WriteLine("Defaults:");
                Console.WriteLine("  Name: {0}", sampleSection.Name);
                Console.WriteLine("  BuildStartTime: {0}", sampleSection.BuildStartTime);
                Console.WriteLine("  BuildEndTime: {0}", sampleSection.BuildEndTime);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("[Create a section]");
            CreateSection();

            Console.WriteLine("[Display section information]");
            DisplaySectionProperties();

            // Show how to use the ValidatorInstance method.
            GetCustomValidatorInstance();

            // Display and wait.
            Console.ReadLine();
        }
    }
}
// </Snippet1>