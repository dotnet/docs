using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Group
{
   // The XmlSerializer ignores this field.
   [XmlIgnore]
   public string Comment;

   // The XmlSerializer serializes this field.
   public string GroupName;
}
   
// </Snippet1>

