// This is the class that will be serialized.
public class XClass
{
   /* The XML element name will be XName
   instead of the default ClassName. */
   [XmlElement(ElementName = "XName")]
   public string ClassName;
} 