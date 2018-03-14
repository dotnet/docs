// <Snippet1>
 using System;
 using System.IO;
 using System.Xml;
 using System.Collections;
 
 public class Sample
 {
   public static void Main()
   {

       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<book genre='novel' publicationdate='1997' " +
                   "      ISBN='1-861001-57-5'>" +
                   "  <title>Pride And Prejudice</title>" +
                   "</book>");      
 
       XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;

       Console.WriteLine("Display all the attributes for this book...");
       IEnumerator ienum = attrColl.GetEnumerator();
       while (ienum.MoveNext())
       {
         XmlAttribute attr = (XmlAttribute)ienum.Current;
         Console.WriteLine("{0} = {1}", attr.Name, attr.Value);
       }   
   } 
 }
    // </Snippet1>

