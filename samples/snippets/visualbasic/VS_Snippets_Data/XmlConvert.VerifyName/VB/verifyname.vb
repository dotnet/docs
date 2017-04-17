'<snippet1>
Imports System
Imports System.Xml

public class Sample

  public shared sub Main()
     Dim writer as XmlTextWriter = new XmlTextWriter ("out.xml", nothing)
     Dim tag as string = "item name"
   
    try
	
     ' Write the root element.
     writer.WriteStartElement("root")

     writer.WriteStartElement(XmlConvert.VerifyName(tag))

     catch e as XmlException
        Console.WriteLine(e.Message)
        Console.WriteLine("Convert to a valid name...")
        writer.WriteStartElement(XmlConvert.EncodeName(tag))
     end try

     writer.WriteString("hammer")
     writer.WriteEndElement()

     ' Write the end tag for the root element.
     writer.WriteEndElement()
 
     writer.Close()
  
  end sub
end class
'</snippet1>