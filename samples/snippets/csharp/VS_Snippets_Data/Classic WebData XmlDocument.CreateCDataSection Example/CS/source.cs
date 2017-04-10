// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    //Create a CData section.
    XmlCDataSection CData;
    CData = doc.CreateCDataSection("All Jane Austen novels 25% off starting 3/23!");    

    //Add the new node to the document.
    XmlElement root = doc.DocumentElement;
    root.AppendChild(CData);  
        
    Console.WriteLine("Display the modified XML...");        
    doc.Save(Console.Out);
  }
}
   // </Snippet1>

