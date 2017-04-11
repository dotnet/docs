using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class MyClass
{
    [XmlArrayAttribute()]
    public string [] MyStringArray;
    [XmlArrayAttribute()]
    public int [] MyIntegerArray;
}

// </Snippet1>
