using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Sample
{
// <Snippet1>
private void serializer_UnknownNode
(object sender, XmlNodeEventArgs e)
{
   object o = e.ObjectBeingDeserialized;
   Console.WriteLine("Object being deserialized: " 
   + o.ToString());
       
}
   
// </Snippet1>
}
