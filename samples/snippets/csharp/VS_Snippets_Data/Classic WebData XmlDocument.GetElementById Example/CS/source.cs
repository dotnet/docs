// <Snippet1>

using System;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    XmlDocument doc = new XmlDocument();
    doc.Load("ids.xml");

    //Get the first element with an attribute of type ID and value of A111.
    //This displays the node <Person SSN="A111" Name="Fred"/>.
    XmlElement elem = doc.GetElementById("A111");
    Console.WriteLine( elem.OuterXml );

    //Get the first element with an attribute of type ID and value of A222.
    //This displays the node <Person SSN="A222" Name="Tom"/>.
    elem = doc.GetElementById("A222");
    Console.WriteLine( elem.OuterXml ); 

  }
}
   // </Snippet1>

