// This is the class that will be serialized.
public ref class XClass
{
public:
   /* The XML element name will be XName
   instead of the default ClassName. */
   [XmlElement(ElementName="XName")]
   String^ ClassName;
};