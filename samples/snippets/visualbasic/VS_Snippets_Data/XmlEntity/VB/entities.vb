'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
 
public class Sample

  private const filename as String = "doment.xml"
 
  public shared sub Main()
      
     Dim doc as XmlDocument = new XmlDocument()
     doc.Load(filename)
 
     Console.WriteLine("Display information on all entities...")     
     Dim nMap as XmlNamedNodeMap = doc.DocumentType.Entities
     DisplayEntities(nMap)
  end sub
 
  public shared sub DisplayEntities(nMap as XmlNamedNodeMap)
     Dim i as integer   
     for i = 0 to nMap.Count - 1
        Dim ent as XmlEntity = CType(nMap.Item(i), XmlEntity)
        Console.Write("{0} ", ent.NodeType)
        Console.Write("{0} ", ent.Name)
        Console.Write("{0} ", ent.NotationName)
        Console.Write("{0} ", ent.PublicId)
        Console.Write("{0} ", ent.SystemId)
        Console.WriteLine()
     next
  end sub
end class
'</snippet1>


