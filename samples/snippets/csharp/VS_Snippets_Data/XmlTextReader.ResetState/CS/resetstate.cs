//<snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml;

public class Sample
{
  public static void Main(){

     Encoding enc = new UTF8Encoding();
     byte[] utf8Buffer = enc.GetBytes("<root> 12345 </root>"); 

     enc = new UnicodeEncoding();
     byte[] unicodeBuffer = enc.GetBytes("<?xml version='1.0' ?><unicode> root </unicode>");

     MemoryStream memStrm = new MemoryStream();
     memStrm.Write(unicodeBuffer, 0, unicodeBuffer.Length);
     memStrm.Write(utf8Buffer, 0, utf8Buffer.Length);
     memStrm.Position = 0;

     XmlTextReader reader = new XmlTextReader(memStrm);

     while(reader.Read()) {
        Console.WriteLine("NodeType: {0}", reader.NodeType);
        if (XmlNodeType.EndElement == reader.NodeType && "root" == reader.Name) {
          break;
        }

        if (XmlNodeType.EndElement == reader.NodeType) {
          reader.ResetState();
       }
    } 

  }
}
//</snippet1>

 

