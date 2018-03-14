'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

     Dim reader as XmlTextReader = new XmlTextReader("authors.xml")
     reader.WhitespaceHandling = WhitespaceHandling.None

     ' Parse the file.  Return white space only if an
     ' xml:space='preserve' attribute is found.
     while (reader.Read())
       select case reader.NodeType
         case XmlNodeType.Element:
           Console.Write("<{0}>", reader.Name)
           if (reader.XmlSpace=XmlSpace.Preserve)
             reader.WhitespaceHandling=WhitespaceHandling.Significant
           end if
         case XmlNodeType.Text:
           Console.Write(reader.Value)
         case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name)
         case XmlNodeType.SignificantWhitespace:
           Console.Write(reader.Value)        
       end select              
     end while
  end sub
end class
'</snippet1>


