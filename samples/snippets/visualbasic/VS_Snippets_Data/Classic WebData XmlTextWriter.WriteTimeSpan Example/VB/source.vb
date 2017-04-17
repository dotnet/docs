' <Snippet1>
Imports System
Imports System.Xml

public class Sample 
 
  public shared sub Main() 
   
    Dim writer as XmlTextWriter = nothing
     
      try 
    
        writer = new XmlTextWriter (Console.Out)
 
        ' Write an element.
        writer.WriteStartElement("address")
     
        ' Write an e-mail address using entities
        ' for the @ and . characters.
        writer.WriteString("someone")
        writer.WriteCharEntity("@"c)
        writer.WriteString("example")
        writer.WriteCharEntity("."c)
        writer.WriteString("com")
        writer.WriteEndElement()        
 
    finally 
      ' Close the writer.
      if not writer is nothing
        writer.Close()
      end if
    end try 

  end sub
end class
' </Snippet1>
