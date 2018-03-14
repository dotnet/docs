'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
 
public class Sample

  private const filename as String = "doment.xml"
 
  public shared sub Main()
    Dim doc as XmlDocument = new XmlDocument()
    doc.Load(filename)

    Console.WriteLine("Display information on all notations...")     
    Dim nMap as XmlNamedNodeMap = doc.DocumentType.Notations
    DisplayNotations(nMap)      
  end sub
 
  public shared sub DisplayNotations(nMap as XmlNamedNodeMap)
     Dim i as integer   
     for i = 0 to nMap.Count - 1
        Dim note as XmlNotation = CType(nMap.Item(i), XmlNotation)
        Console.Write("{0} ", note.NodeType)
        Console.Write("{0} ", note.Name)
        Console.Write("{0} ", note.PublicId)
        Console.Write("{0} ", note.SystemId)
        Console.WriteLine()
     next
  end sub            
end class
'</snippet1>


