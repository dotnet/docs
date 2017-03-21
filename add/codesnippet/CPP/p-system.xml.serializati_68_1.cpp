public ref class Car
{
public:

   [XmlAttributeAttribute(Namespace="Make")]
   String^ MakerName;

   [XmlAttributeAttribute(Namespace="Model")]
   String^ ModelName;
};
