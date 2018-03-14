using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class MyClass
{
   [XmlArray (IsNullable = true)]
   public string [] IsNullableIsTrueArray;

   [XmlArray (IsNullable = false)]
   public string [] IsNullableIsFalseArray;
}
   
// </Snippet1>
