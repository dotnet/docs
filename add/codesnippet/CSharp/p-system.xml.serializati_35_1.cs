public class Vehicle
{
   [XmlAttribute(Form = XmlSchemaForm.Qualified)]
   public string Maker;
 
   [XmlAttribute(Form = XmlSchemaForm.Unqualified)]
   public string ModelID;
}
