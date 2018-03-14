//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{

  public static void Main()
  {

     // Encode and decode a name with spaces.
     string name1 = XmlConvert.EncodeName("Order Detail");
     Console.WriteLine("Encoded name: " + name1);
     Console.WriteLine("Decoded name: " + XmlConvert.DecodeName(name1));

     // Encode and decode a local name.
     string name2 = XmlConvert.EncodeLocalName("a:book");
     Console.WriteLine("Encoded local name: " + name2);
     Console.WriteLine("Decoded local name: " + XmlConvert.DecodeName(name2));

  }
}
//</snippet1>