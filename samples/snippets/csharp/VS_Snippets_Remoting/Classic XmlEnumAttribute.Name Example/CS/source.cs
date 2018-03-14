using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public enum EmployeeStatus
{
   [XmlEnum("Single")]
   One,
   [XmlEnum("Double")]
   Two,
   [XmlEnum("Triple")]
   Three
}
   
// </Snippet1>

