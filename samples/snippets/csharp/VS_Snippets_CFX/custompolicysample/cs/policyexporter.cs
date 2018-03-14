// <snippet12>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
using System.ServiceModel.Configuration;

namespace Microsoft.WCF.Documentation
{
  // <snippet13>
  public class ExporterBindingElement : BindingElement, IPolicyExportExtension
  {

    public const string name1 = "acme";
    public const string ns1 = "http://Microsoft/WCF/Documentation/CustomPolicyAssertions";

    static XmlDocument doc = new XmlDocument();
    string roadrunnerSpeed;

    public ExporterBindingElement()
    {
      Console.WriteLine("Exporter created.");
    }
    //<snippet14>
    #region IPolicyExporter Members
    public void ExportPolicy(MetadataExporter exporter, PolicyConversionContext policyContext)
    {
      if (exporter == null)
        throw new NullReferenceException("The MetadataExporter object passed to the ExporterBindingElement is null.");
      if (policyContext == null)
        throw new NullReferenceException("The PolicyConversionContext object passed to the ExporterBindingElement is null.");
      
      XmlElement elem = doc.CreateElement(name1, ns1);
      elem.InnerText = "My custom text.";
      XmlAttribute att = doc.CreateAttribute("MyCustomAttribute", ns1);
      att.Value = "ExampleValue";
      elem.Attributes.Append(att);
      XmlElement subElement = doc.CreateElement("MyCustomSubElement", ns1);
      subElement.InnerText = "Custom Subelement Text.";
      elem.AppendChild(subElement);
      policyContext.GetBindingAssertions().Add(elem);
      Console.WriteLine("The custom policy exporter was called.");
    }
    #endregion
    //</snippet14>

    public override BindingElement Clone()
    {
      // Note: All custom binding elements must return a deep clone 
      // to enable the run time to support multiple bindings using the 
      // same custom binding.
      return this;
    }

    // Call the inner property.
    public override T GetProperty<T>(BindingContext context)
    { return context.GetInnerProperty<T>(); }
  }
  // </snippet13>
  // <snippet15>
  public class ExporterBindingElementConfigurationSection : BindingElementExtensionElement
  {
    public ExporterBindingElementConfigurationSection()
    { Console.WriteLine("Exporter configuration section created."); }

    public override Type BindingElementType
    { get { return typeof(ExporterBindingElement); } }

    protected override BindingElement CreateBindingElement()
    { return new ExporterBindingElement(); }
  }
  // </snippet15>
}
// </snippet12>
