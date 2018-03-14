'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

     ' Encode and decode a name with spaces.
     Dim name1 as string = XmlConvert.EncodeName("Order Detail")
     Console.WriteLine("Encoded name: " + name1)
     Console.WriteLine("Decoded name: " + XmlConvert.DecodeName(name1))

     ' Encode and decode a local name.
     Dim name2 as string= XmlConvert.EncodeLocalName("a:book")
     Console.WriteLine("Encoded local name: " + name2)
     Console.WriteLine("Decoded local name: " + XmlConvert.DecodeName(name2))

  end sub
end class
'</snippet1>