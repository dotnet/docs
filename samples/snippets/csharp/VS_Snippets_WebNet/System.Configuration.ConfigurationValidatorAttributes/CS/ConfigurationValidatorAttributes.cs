using System;
using System.Configuration;

namespace Samples.AspNet
{
    //<Snippet1>

    public class SampleSection :
        ConfigurationSection
    {
        public SampleSection()
        {

        }

        //<Snippet2>
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
        //</Snippet2>


        //<Snippet3>
        [ConfigurationProperty("alias", DefaultValue = "anotherName.txt",
            IsRequired = true, IsKey = false)]
        [StringValidator()]
        public string Alias
        {
            get
            {
                return (string)this["alias"];
            }
            set
            {
                this["alias"] = value;
            }
        }
        //</Snippet3>

        //<Snippet4>
        [ConfigurationProperty("alias2", DefaultValue = "alias.txt",
            IsRequired = true, IsKey = false)]
        [RegexStringValidator(@"\w+\S*")]
        public string Alias2
        {
            get
            {
                return (string)this["alias2"];
            }
            set
            {
                this["alias2"] = value;
            }
        }
        //</Snippet4>

        //<Snippet5> 
        [ConfigurationProperty("maxSize", DefaultValue = 1000,
            IsRequired = true)]
        [IntegerValidator()]
        public int MaxSize
        {
            get
            {
                return (int)this["maxSize"];
            }
            set
            {
                this["maxSize"] = value;
            }
        }
        //</Snippet5>

        //<Snippet6> 
        [ConfigurationProperty("maxAttempts", DefaultValue = 101,
            IsRequired = true)]
        [IntegerValidator(MinValue = 1, MaxValue = 100,
            ExcludeRange = true)]
        public int MaxAttempts
        {
            get
            {
                return (int)this["maxAttempts"];
            }
            set
            {
                this["maxAttempts"] = value;
            }
        }
        //</Snippet6>

        //<Snippet7> 
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
        //</Snippet7>

        //<Snippet8> 
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
        //</Snippet8>

        //<Snippet9> 
        [ConfigurationProperty("lastAccess",
          DefaultValue = "00:00:00",
          IsRequired = false)]
        [TimeSpanValidator()]
        public TimeSpan LastAccess
        {
            get
            {
                return (TimeSpan)this["lastAccess"];
            }
            set
            {
                this["lastAccess"] = value;
            }
        }
        //</Snippet9>


        public static void DisplayTimeSpanAbsoluteRange()
        {
            //<Snippet10>
            string absoluteMax =
                TimeSpanValidatorAttribute.TimeSpanMaxValue;
            //</Snippet10>

            //<Snippet11>
            string absoluteMin =
                TimeSpanValidatorAttribute.TimeSpanMinValue;
            //</Snippet11>

            Console.WriteLine("  Absolute max: {0}", absoluteMax);
            Console.WriteLine("  Absolute max: {0}", absoluteMin);
        }

        public static void TimeStampValidatorInstance()
        {
            //<Snippet12>

            ConfigurationValidatorBase valBase;
            TimeSpanValidatorAttribute tsValAttr;
            tsValAttr = new TimeSpanValidatorAttribute();

            TimeSpan goodValue = TimeSpan.FromMinutes(10);
            Int16 badValue = 10;

            try
            {
                valBase = tsValAttr.ValidatorInstance;
                valBase.Validate(goodValue);
                // valBase.Validate(badValue);
            }
            catch (ArgumentException e)
            {
                // Display error message.
                string msg = e.ToString();
#if DEBUG
                Console.WriteLine(msg);
#endif
            }
            //</Snippet12>

        }

        public static void IntegerValidatorInstance()
        {
            //<Snippet13>

            ConfigurationValidatorBase valBase;
            IntegerValidatorAttribute intValAttr;
            intValAttr = new IntegerValidatorAttribute();

            long badValue = 10;
            int goodValue = 10;

            try
            {
                valBase = intValAttr.ValidatorInstance;
                valBase.Validate(goodValue);
                // valBase.Validate(badValue);
            }
            catch (ArgumentException e)
            {
                // Display error message.
                string msg = e.ToString();
#if DEBUG
                Console.WriteLine(msg);
#endif
            }
            //</Snippet13>

        }

        public static void StringValidatorInstance()
        {
            //<Snippet14>

            ConfigurationValidatorBase valBase;
            StringValidatorAttribute strValAttr =
            new StringValidatorAttribute();

            long badValue = 10;
            string goodValue = "10";

            try
            {
                valBase = strValAttr.ValidatorInstance;
                valBase.Validate(goodValue);
                // valBase.Validate(badValue);
            }
            catch (ArgumentException e)
            {
                // Display error message.
                string msg = e.ToString();
#if DEBUG
                Console.WriteLine(msg);
#endif
            }
            //</Snippet14>

        }

        public static void RegexStringValidatorInstance()
        {
            //<Snippet15>

            //<Snippet16>

            ConfigurationValidatorBase valBase;

            RegexStringValidatorAttribute rstrValAttr =
            new RegexStringValidatorAttribute(@"\w+\S*");

            // Get the regular expression string.
            string regex = rstrValAttr.Regex;
            Console.WriteLine("Regular expression: {0}", regex);

            //</Snippet16>

            string badValue = "&%$bbb";
            string goodValue = "filename.txt";

            try
            {
                valBase = rstrValAttr.ValidatorInstance;
                valBase.Validate(goodValue);
                // valBase.Validate(badValue);
            }
            catch (ArgumentException e)
            {
                // Display error message.
                string msg = e.ToString();
#if DEBUG
                Console.WriteLine(msg);
#endif
            }
            //</Snippet15>

        }
    }
    //</Snippet1>

    class TestingSampleConfiguration
    {

        static void ShowDefaults()
        {
            SampleSection customSection =
               ConfigurationManager.GetSection("custom") as SampleSection;

            if (customSection == null)
                Console.WriteLine("Failed to load SsmpleSection.");
            else
            {
                Console.WriteLine("Defaults:");
                Console.WriteLine("  File Name: {0}",
                    customSection.FileName);
                Console.WriteLine("  Max Users: {0}",
                    customSection.MaxUsers);
                Console.WriteLine("  Max Idle Time: {0}",
                    customSection.MaxIdleTime);
                Console.WriteLine("  Last access: {0}",
                    customSection.LastAccess);
                Console.WriteLine("  Alias 1: {0}",
                    customSection.Alias);
                Console.WriteLine("  Alias 2: {0}",
                    customSection.Alias2);

            }
        }


        static void ShowSectionInfo()
        {
            SampleSection customSection =
              ConfigurationManager.GetSection("custom") as SampleSection;

            if (customSection == null)
                Console.WriteLine("Failed to load SampleSection.");
            else
            {
                Console.WriteLine("Section Information:");

                Console.WriteLine("  Name: {0}",
                    customSection.SectionInformation.Name);

                Console.WriteLine("  SectionName: {0}",
                    customSection.SectionInformation.SectionName);

                Console.WriteLine("  Type: {0}",
                    customSection.SectionInformation.Type);

                Console.WriteLine("  AllowDefinition: {0}",
                    customSection.SectionInformation.AllowDefinition);

                Console.WriteLine("  AllowExeDefinition: {0}",
                    customSection.SectionInformation.AllowExeDefinition);

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("[Current Defaults]");
            ShowDefaults();
            Console.WriteLine();
            //SampleSection.DisplayTimeSpanAbsoluteRange();
            //SampleSection.TimeStampValidatorInstance();
            //SampleSection.IntegerValidatorInstance();
            //SampleSection.StringValidatorInstance();
            SampleSection.RegexStringValidatorInstance();
            Console.ReadLine();
        }
    }
}
