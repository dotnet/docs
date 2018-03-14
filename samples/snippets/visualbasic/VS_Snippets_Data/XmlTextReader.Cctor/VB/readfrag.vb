'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    'Create the XML fragment to be parsed.
    Dim xmlFrag as string ="<book> " & _
                           "<title>Pride And Prejudice</title>" & _
                           "<bk:genre>novel</bk:genre>" & _
                           "</book>" 

    'Create the XmlNamespaceManager.
    Dim nt as NameTable = new NameTable()
    Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(nt)
    nsmgr.AddNamespace("bk", "urn:sample")

    'Create the XmlParserContext.
    Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.None)

    'Create the reader. 
    Dim reader as XmlTextReader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context)
  
    'Parse the XML.  If they exist, display the prefix and  
    'namespace URI of each element.
    while (reader.Read())
      if (reader.IsStartElement())
        if (reader.Prefix=String.Empty)
           Console.WriteLine("<{0}>", reader.LocalName)
        else
            Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName)
            Console.WriteLine(" The namespace URI is " + reader.NamespaceURI)
        end if 
      end if
    end while
  
    'Close the reader.
    reader.Close()     
  
  end sub
end class
'</snippet1>


