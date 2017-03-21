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

    public void WriteXml (XmlWriter writer)
    {
        writer.WriteString(personName);
    }

    public void ReadXml (XmlReader reader)
    {
        personName = reader.ReadString();
    }

    public XmlSchema GetSchema()
    {
        return(null);
    }

  
    // Print

    public override string ToString()
    {
        return(personName);
    }

}