// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main(){
  
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");      

    //Create an attribute collection.
    XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;

    //Declare the array.
    XmlAttribute[] array = new XmlAttribute[2];
    int index=0;

    //Copy all the attributes into the array.
    attrColl.CopyTo(array, index);

    Console.WriteLine("Display all the attributes in the array..");
    foreach (XmlAttribute attr in array){
      Console.WriteLine("{0} = {1}",attr.Name,attr.Value);
    } 
  
  }
}
// </Snippet1>

