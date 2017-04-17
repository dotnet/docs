using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Remoting.Metadata;

public class Test {
   public static void Main()  {

      // Creates a new TestSimpleObject object.
      TestSimpleObject obj = new TestSimpleObject();

      // Opens a file and serializes the object into it in binary format.
      Stream stream = File.Open("data.xml", FileMode.Create);
      SoapFormatter formatter = new SoapFormatter();

      formatter.Serialize(stream, obj);
      stream.Close();
   }
}


// A test object that needs to be serialized
// <Snippet1>
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
// </Snippet1>
