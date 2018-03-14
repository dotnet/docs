// <Snippet1>
 using System;
 using System.Xml;
 
 public class Sample {
   
   public static void Main() {

       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<author xml:space='preserve'>" +
                   "<first-name>Eva</first-name>"+
                   "<last-name>Corets</last-name>" + 
                   "</author>"); 
         
       Console.WriteLine("InnerText before...");
       Console.WriteLine(doc.DocumentElement.InnerText);
 
       // Add white space.     
       XmlNode currNode = doc.DocumentElement;
       XmlSignificantWhitespace sigws = doc.CreateSignificantWhitespace("\t");
       currNode.InsertAfter(sigws, currNode.FirstChild);
 
       Console.WriteLine();
       Console.WriteLine("InnerText after...");
       Console.WriteLine(doc.DocumentElement.InnerText);
 
   } 
 }
   // </Snippet1>

