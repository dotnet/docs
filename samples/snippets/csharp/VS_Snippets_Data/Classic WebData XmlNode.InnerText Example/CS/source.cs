// <Snippet1>
using System;
using System.Xml;
public class Test {

  public static void Main() {
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<root>"+
                "<elem>some text<child/>more text</elem>" +
                "</root>");

    XmlNode elem = doc.DocumentElement.FirstChild;

    // Note that InnerText does not include the markup.
    Console.WriteLine("Display the InnerText of the element...");
    Console.WriteLine( elem.InnerText );

    // InnerXml includes the markup of the element.
    Console.WriteLine("Display the InnerXml of the element...");
    Console.WriteLine(elem.InnerXml);

    // Set InnerText to a string that includes markup.  
    // The markup is escaped.
    elem.InnerText = "Text containing <markup/> will have char(<) and char(>) escaped.";
    Console.WriteLine( elem.OuterXml );

    // Set InnerXml to a string that includes markup.  
    // The markup is not escaped.
    elem.InnerXml = "Text containing <markup/>.";
    Console.WriteLine( elem.OuterXml );
  }
}
// </Snippet1>

