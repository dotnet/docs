[Serializable()] 
[SoapTypeAttribute(XmlNamespace="MyXmlNamespace")]
public class TestSimpleObject  {

    public int member1;

    [SoapFieldAttribute(XmlElementName="MyXmlElement")] public string member2;

    public string member3;
    public double member4;

    // A field that is not serialized.
    [NonSerialized()] public string member5; 
    
    public TestSimpleObject() {

        member1 = 11;
        member2 = "hello";
        member3 = "hello";
        member4 = 3.14159265;
        member5 = "hello world!";
    }
}