'<snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml

public class Sample

  public shared sub Main()

     Dim enc as Encoding = new UTF8Encoding()
     Dim utf8Buffer as byte() = enc.GetBytes("<root> 12345 </root>") 

     enc = new UnicodeEncoding()
     Dim unicodeBuffer as byte() = enc.GetBytes("<?xml version='1.0' ?><unicode> root </unicode>")

     Dim memSreaderm as MemoryStream = new MemoryStream()
     memSreaderm.Write(unicodeBuffer, 0, unicodeBuffer.Length)
     memSreaderm.Write(utf8Buffer, 0, utf8Buffer.Length)
     memSreaderm.Position = 0

     Dim reader as XmlTextReader = new XmlTextReader(memSreaderm)

     while(reader.Read()) 
        Console.WriteLine("NodeType: {0}", reader.NodeType)
        if (XmlNodeType.EndElement = reader.NodeType And "root" = reader.Name) 
         exit while
        end if
        
        if (XmlNodeType.EndElement = reader.NodeType) 
          reader.ResetState()
       end if
    end while

  end sub
end class
'</snippet1>

 

