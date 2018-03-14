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
   XmlNodeType myNodeType = e.NodeType;
   Console.WriteLine(myNodeType);
}
   
// </Snippet1>
}
