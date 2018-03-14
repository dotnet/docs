// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Collections;

public class Sample {

  public static void Main() {
  
     XmlDocument doc = new XmlDocument();
     doc.Load("2books.xml");
                         
     //Get and display all the book titles.
     XmlElement root = doc.DocumentElement;
     XmlNodeList elemList = root.GetElementsByTagName("title");
     IEnumerator ienum = elemList.GetEnumerator();          
     while (ienum.MoveNext()) {   
       XmlNode title = (XmlNode) ienum.Current;
       Console.WriteLine(title.InnerText);
     }    
    
  }
}
 // </Snippet1>

