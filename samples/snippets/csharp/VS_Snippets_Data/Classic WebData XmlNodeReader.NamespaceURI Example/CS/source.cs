// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlNodeReader reader = null;

    try
    {
       //Create and load the XML document.
       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<book xmlns:bk='urn:samples'> " +
                   "<title>Pride And Prejudice</title>" +
                   "<bk:genre>novel</bk:genre>" +
                   "</book>"); 

       //Load the XmlNodeReader 
       reader = new XmlNodeReader(doc);
  
       //Parse the XML.  If they exist, display the prefix and  
       //namespace URI of each node.
       while (reader.Read()){
         if (reader.IsStartElement()){
           if (reader.Prefix==String.Empty)
              Console.WriteLine("<{0}>", reader.LocalName);
           else{
               Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName);
               Console.WriteLine(" The namespace URI is " + reader.NamespaceURI);
           }
         }
       }
       
     } 
     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
  
} // End class
   // </Snippet1>

