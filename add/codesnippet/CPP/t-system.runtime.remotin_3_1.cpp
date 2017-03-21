[Serializable]
[SoapTypeAttribute(XmlNamespace="MyXmlNamespace")]
public ref class TestSimpleObject
{
public:
   int member1;

   [SoapFieldAttribute(XmlElementName="MyXmlElement")] String^ member2;

   String^ member3;
   double member4;

   // A field that is not serialized.

   [NonSerialized] String^ member5;

   TestSimpleObject()
   {
      member1 = 11;
      member2 = "hello";
      member3 = "hello";
      member4 = 3.14159265;
      member5 = "hello world!";
   }
};