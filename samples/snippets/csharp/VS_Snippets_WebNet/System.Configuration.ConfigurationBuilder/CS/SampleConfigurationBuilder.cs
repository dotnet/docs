using System;
using System.Configuration;
using System.Xml;

namespace Samples.AspNet.Config
{

   public class SampleConfigurationBuilder : ConfigurationBuilder
    {

        public override XmlNode ProcessRawXml(XmlNode rawXml) 
        {

            string rawXmlString = rawXml.OuterXml;

            if (String.IsNullOrEmpty(rawXmlString)) {
                return rawXml;
            }

            rawXmlString = Environment.ExpandEnvironmentVariables(rawXmlString);

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(rawXmlString);
            return doc.DocumentElement;
        }

        public override ConfigurationSection ProcessConfigurationSection(ConfigurationSection configSection) 
            => configSection;
    }
}