//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    class MessageVersionConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (typeof(string) == sourceType)
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (typeof(InstanceDescriptor) == destinationType)
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string messageVersion = (string)value;
                MessageVersion retval = null;
                switch (messageVersion)
                {
                    case ConfigurationStrings.Soap11WSAddressing10:
                        retval = MessageVersion.Soap11WSAddressing10;
                        break;
                    case ConfigurationStrings.Soap12WSAddressing10:
                        retval = MessageVersion.Soap12WSAddressing10;
                        break;
                    case ConfigurationStrings.Soap11WSAddressingAugust2004:
                        retval = MessageVersion.Soap11WSAddressingAugust2004;
                        break;
                    case ConfigurationStrings.Soap12WSAddressingAugust2004:
                        retval = MessageVersion.Soap12WSAddressingAugust2004;
                        break;
                    case ConfigurationStrings.Soap11:
                        retval = MessageVersion.Soap11;
                        break;
                    case ConfigurationStrings.Soap12:
                        retval = MessageVersion.Soap12;
                        break;
                    case ConfigurationStrings.None:
                        retval = MessageVersion.None;
                        break;
                    case ConfigurationStrings.Default:
                        retval = MessageVersion.Default;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("messageVersion");
                }

                return retval;
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (typeof(string) == destinationType && value is MessageVersion)
            {
                string retval = null;
                MessageVersion messageVersion = (MessageVersion)value;
                if (messageVersion == MessageVersion.Default)
                {
                    retval = ConfigurationStrings.Default;
                }
                else if (messageVersion == MessageVersion.Soap11WSAddressing10)
                {
                    retval = ConfigurationStrings.Soap11WSAddressing10;
                }
                else if (messageVersion == MessageVersion.Soap12WSAddressing10)
                {
                    retval = ConfigurationStrings.Soap12WSAddressing10;
                }
                else if (messageVersion == MessageVersion.Soap11WSAddressingAugust2004)
                {
                    retval = ConfigurationStrings.Soap11WSAddressingAugust2004;
                }
                else if (messageVersion == MessageVersion.Soap12WSAddressingAugust2004)
                {
                    retval = ConfigurationStrings.Soap12WSAddressingAugust2004;
                }
                else if (messageVersion == MessageVersion.Soap11)
                {
                    retval = ConfigurationStrings.Soap11;
                }
                else if (messageVersion == MessageVersion.Soap12)
                {
                    retval = ConfigurationStrings.Soap12;
                }
                else if (messageVersion == MessageVersion.None)
                {
                    retval = ConfigurationStrings.None;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("messageVersion");
                }
                return retval;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
