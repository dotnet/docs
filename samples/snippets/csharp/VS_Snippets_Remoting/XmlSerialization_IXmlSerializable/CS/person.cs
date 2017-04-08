// <snippet0>
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


public class Person : IXmlSerializable
{

    // Private state

    private string personName;
       

    // Constructors

    public Person (string name)
    {
        personName = name;
    }

    public Person ()
    {
        personName = null;
    }


    // Xml Serialization Infrastructure

// <snippet1>
    public void WriteXml (XmlWriter writer)
    {
        writer.WriteString(personName);
    }
// </snippet1>

// <snippet2>
    public void ReadXml (XmlReader reader)
    {
        personName = reader.ReadString();
    }
// </snippet2>

// <snippet3>
    public XmlSchema GetSchema()
    {
        return(null);
    }
// </snippet3>

  
    // Print

    public override string ToString()
    {
        return(personName);
    }

}
// </snippet0>
