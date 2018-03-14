// <Snippet1>
 using System;
 using System.IO;
 using System.Xml;
 
 public class Sample {
   private XmlNode currNode;
   private const String filename="space.xml";
   XmlTextReader reader=null;
   
   public static void Main() {
  
     Sample test = new Sample();
   }
   public Sample() {

       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<author>" +
                   "<first-name>Eva</first-name>"+
                   "<last-name>Corets</last-name>" + 
                   "</author>"); 
 
        
       Console.WriteLine("InnerText before...");
       Console.WriteLine(doc.DocumentElement.InnerText);
 
       // Add white space.     
       currNode=doc.DocumentElement;
       XmlWhitespace ws = doc.CreateWhitespace("\r\n");
       currNode.InsertAfter(ws, currNode.FirstChild);
 
       Console.WriteLine();
       Console.WriteLine("InnerText after...");
       Console.WriteLine(doc.DocumentElement.InnerText);
 
       // Save and then display the file.
       doc.Save(filename);
       Console.WriteLine();
       Console.WriteLine("Reading file...");
       ReadFile(filename);
 
   }
 
   // Parse the file and display each node.
   public void ReadFile(String filename) {
     try {
       reader = new XmlTextReader(filename);
       String sNodeType = null;
       while (reader.Read()) { 
        sNodeType = NodeTypeToString(reader.NodeType); 
        // Print the node type, name, and value.
        Console.WriteLine("{0}<{1}> {2}", sNodeType, reader.Name, reader.Value);
       }
     }

     finally 
     {
        if (reader != null)
          reader.Close();
     }
    }
 
    public static String NodeTypeToString(XmlNodeType nodetype) {
       String sNodeType = null;
       switch (nodetype) {
         case XmlNodeType.None:
           sNodeType = "None";
           break;
         case XmlNodeType.Element:
           sNodeType = "Element";
           break;
         case XmlNodeType.Attribute:
           sNodeType = "Attribute";
           break;
         case XmlNodeType.Text:
           sNodeType = "Text";
           break;
         case XmlNodeType.Comment:
           sNodeType = "Comment";
           break;
         case XmlNodeType.Document:
           sNodeType = "Document";
           break;
         case XmlNodeType.Whitespace:
           sNodeType = "Whitespace";
           break;
         case XmlNodeType.SignificantWhitespace:
           sNodeType = "SignificantWhitespace";
           break;
         case XmlNodeType.EndElement:
           sNodeType = "EndElement";
           break;
       }
       return sNodeType;
    }
 }
   // </Snippet1>

