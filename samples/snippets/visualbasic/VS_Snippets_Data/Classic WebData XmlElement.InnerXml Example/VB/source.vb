' <Snippet1>
Imports System.Xml

public class Test

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<root>"& _
                "<elem>some text<child/>more text</elem>" & _
                "</root>")

    Dim elem as XmlElement
    elem = CType (doc.DocumentElement.ChildNodes.Item(0), XmlElement)

    ' Note that InnerText does not include the markup.
    Console.WriteLine("Display the InnerText of the element...")
    Console.WriteLine( elem.InnerText )

    ' InnerXml includes the markup of the element.
    Console.WriteLine("Display the InnerXml of the element...")
    Console.WriteLine(elem.InnerXml)

    ' Set InnerText to a string that includes markup.  
    ' The markup is escaped.
    elem.InnerText = "Text containing <markup/> will have char(<) and char(>) escaped."
    Console.WriteLine( elem.OuterXml )

    ' Set InnerXml to a string that includes markup.  
    'The markup is not escaped.
    elem.InnerXml = "Text containing <markup/>."
    Console.WriteLine( elem.OuterXml )
    
  end sub
end class
' This example produces the following results:
'
' Display the InnerText of the element...
' some textmore text
' Display the InnerXml of the element...
' some text<child />more text
' <elem>Text containing &lt;markup/&gt; will have char(&lt;) and char(&gt;) escaped.</elem>
' <elem>Text containing <markup />.</elem>
' </Snippet1>

