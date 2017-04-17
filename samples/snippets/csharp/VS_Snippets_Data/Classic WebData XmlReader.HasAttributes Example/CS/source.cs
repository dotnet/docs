using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Schema;

public class Class1
{
    // <Snippet1>
    public void DisplayAttributes(XmlReader reader)
    {
        if (reader.HasAttributes)
        {
            Console.WriteLine("Attributes of <" + reader.Name + ">");
            while (reader.MoveToNextAttribute())
            {
                Console.WriteLine(" {0}={1}", reader.Name, reader.Value);
            }
        }
    }
    // </Snippet1>
}
