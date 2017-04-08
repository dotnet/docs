using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Samples.AspNet
{
    // For Parsnip compilation sake.
    sealed class CustomizedTimeSpanMinutesConverter :
    ConfigurationConverterBase
    {
        internal bool ValidateType(object value,
            Type expected)
        {
            bool result;

            if ((value != null) &&
                (value.GetType() != expected))
                result = false;
            else
                result = true;

            return result;
        }

        public override bool CanConvertTo(
            ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(string));
        }
        public override bool CanConvertFrom(
            ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(string));
        }
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

    //<Snippet1>

    // Define a custom section.
    public sealed class CustomSection :
        ConfigurationSection
    {

        public CustomSection() 
        {
           
        }

        //<Snippet0>
        [ConfigurationProperty("fileName", DefaultValue="   default.txt  ")]
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        public String FileName
        {
            get
            {
                return (String)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }
        //</Snippet0>

        //<Snippet2>
        [ConfigurationProperty("maxIdleTime")]
        [TypeConverter(typeof(CustomizedTimeSpanMinutesConverter))]
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
        //</Snippet2>

        //<Snippet3>
        [ConfigurationProperty("timeDelay", 
            DefaultValue = "infinite")]
        [TypeConverter(typeof(InfiniteTimeSpanConverter))]
        public TimeSpan TimeDelay
        {
            get
            {
                return (TimeSpan)this["timeDelay"];
            }
            set
            {
                this["timeDelay"] = value;
            }
        }
        //</Snippet3>

        //<Snippet4>
        [ConfigurationProperty("cdStr", 
            DefaultValue = "str0, str1",
           IsRequired = true)]

        [TypeConverter(typeof(
            CommaDelimitedStringCollectionConverter))]
        public StringCollection CdStr
        {
            get
            {
                return (StringCollection)this["cdStr"];
            }

            set
            {
                this["cdStr"] = value;
            }
   
        }
        //</Snippet4>


        //<Snippet5>

        public enum Permissions
        {
            FullControl         = 0,
            Modify              = 1,
            ReadExecute         = 2,
            Read                = 3,
            Write               = 4,
            SpecialPermissions  = 5
        }

        [ConfigurationProperty("permission", DefaultValue = Permissions.Read)]
        public Permissions Permission
        {
            get
            {
                return (Permissions)this["permission"];
            }

            set
            {
                this["permission"] = value;
            }

        }
        //</Snippet5>

        
        //<Snippet6>
        [ConfigurationProperty("maxUsers", DefaultValue="infinite")]
        [TypeConverter(typeof(InfiniteIntConverter))]
        public int MaxUsers
        {
            get
            {
                return (int)this["maxUsers"];
            }
            set
            {
                this["maxUsers"] = value;
            }
        }
        //</Snippet6>

    }

}
//</Snippet1>
