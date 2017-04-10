// <Snippet1>
 using System;
 using System.Xml;
 
 public class Sample {
 
   public static void Main() {

       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<book>"+ 
                   "  <title>Pride And Prejudice</title>" +
                   "  <price/>" +
                   "</book>");     
  
       XmlElement currNode = (XmlElement) doc.DocumentElement.LastChild;
       if (currNode.IsEmpty)
         currNode.InnerXml="19.95"; 
 
       Console.WriteLine("Display the modified XML...");
       Console.WriteLine(doc.OuterXml);
 
   }
 }
   // </Snippet1>

