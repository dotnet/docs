public ref class Group
{
public:

   [XmlAttributeAttribute(DataType="string")]
   String^ Name;

   [XmlAttributeAttribute(DataType="base64Binary")]
   array<Byte>^Hex64Code;
};
