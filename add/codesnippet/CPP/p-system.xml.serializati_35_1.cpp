public ref class Vehicle
{
public:

   [XmlAttributeAttribute(Form=XmlSchemaForm::Qualified)]
   String^ Maker;

   [XmlAttributeAttribute(Form=XmlSchemaForm::Unqualified)]
   String^ ModelID;
};
