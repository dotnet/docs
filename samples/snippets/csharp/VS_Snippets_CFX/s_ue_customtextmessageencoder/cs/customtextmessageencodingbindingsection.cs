
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.ComponentModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    public class CustomTextMessageEncodingElement : BindingElementExtensionElement
    {
        public CustomTextMessageEncodingElement()
        {
        }

        public override void ApplyConfiguration(BindingElement bindingElement)
        {
 	        base.ApplyConfiguration(bindingElement);
            CustomTextMessageBindingElement binding = (CustomTextMessageBindingElement)bindingElement;
            binding.MessageVersion = this.MessageVersion;
            binding.MediaType = this.MediaType;
            binding.Encoding = this.Encoding;
            this.ApplyConfiguration(binding.ReaderQuotas);
        }

        private void ApplyConfiguration(XmlDictionaryReaderQuotas readerQuotas)
        {
            if (readerQuotas == null)
                throw new ArgumentNullException("readerQuotas");
            
            if (this.ReaderQuotasElement.MaxDepth != 0)
            {
                readerQuotas.MaxDepth = this.ReaderQuotasElement.MaxDepth;
            }
            if (this.ReaderQuotasElement.MaxStringContentLength != 0)
            {
                readerQuotas.MaxStringContentLength = this.ReaderQuotasElement.MaxStringContentLength;
            }
            if (this.ReaderQuotasElement.MaxArrayLength != 0)
            {
                readerQuotas.MaxArrayLength = this.ReaderQuotasElement.MaxArrayLength;
            }
            if (this.ReaderQuotasElement.MaxBytesPerRead != 0)
            {
                readerQuotas.MaxBytesPerRead = this.ReaderQuotasElement.MaxBytesPerRead;
            }
            if (this.ReaderQuotasElement.MaxNameTableCharCount != 0)
            {
                readerQuotas.MaxNameTableCharCount = this.ReaderQuotasElement.MaxNameTableCharCount;
            }
        }

        public override Type BindingElementType
        {
            get 
            { 
                return typeof(CustomTextMessageBindingElement); 
            }
        }

        protected override BindingElement CreateBindingElement()
        {
            CustomTextMessageBindingElement binding = new CustomTextMessageBindingElement();
            this.ApplyConfiguration(binding);
            return binding;
        }

        [ConfigurationProperty(ConfigurationStrings.MessageVersion, 
            DefaultValue = ConfigurationStrings.DefaultMessageVersion)]
        [TypeConverter(typeof(MessageVersionConverter))]
        public MessageVersion MessageVersion
        {
            get { return (MessageVersion)base[ConfigurationStrings.MessageVersion]; }
            set { base[ConfigurationStrings.MessageVersion] = value; }
        }

        [ConfigurationProperty(ConfigurationStrings.MediaType, 
            DefaultValue = ConfigurationStrings.DefaultMediaType)]
        public string MediaType
        {
            get
            {
                return (string)base[ConfigurationStrings.MediaType];
            }

            set
            {
                base[ConfigurationStrings.MediaType] = value;
            }
        }

        [ConfigurationProperty(ConfigurationStrings.Encoding,
           DefaultValue = ConfigurationStrings.DefaultEncoding)]
        public string Encoding
        {
            get
            {
                return (string)base[ConfigurationStrings.Encoding];
            }

            set
            {
                base[ConfigurationStrings.Encoding] = value;
            }
        }

        [ConfigurationProperty(ConfigurationStrings.ReaderQuotas)]
        public XmlDictionaryReaderQuotasElement ReaderQuotasElement
        {
            get 
            { 
                return (XmlDictionaryReaderQuotasElement)base[ConfigurationStrings.ReaderQuotas]; 
            }
        }
    }
}
