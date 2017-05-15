using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public enum EmployeeStatus
{
   [XmlEnum(Name = "Single")]
   One,
   [XmlEnum(Name = "Double")]
   Two,
   [XmlEnum(Name = "Triple")]
   Three
}
   
// </Snippet1>

