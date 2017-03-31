// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
    public static void Main()
    {
        XmlTextReader reader = null;

        try
        {
            //Create the XML fragment to be parsed.
            string xmlFrag = "<book genre='novel' misc='sale-item &h;'></book>";

            //Create the XmlParserContext. The XmlParserContext provides the 
            //necessary DTD information so that the entity reference can be expanded.
            XmlParserContext context;
            string subset = "<!ENTITY h 'hardcover'>";
            context = new XmlParserContext(null, null, "book", null, null, subset, "", "", XmlSpace.None);

            //Create the reader. 
            reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);

            //Read the all the attributes on the book element.
            reader.MoveToContent();
            while (reader.MoveToNextAttribute())
            {
                Console.WriteLine("{0} = {1}", reader.Name, reader.Value);
            }
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }
} // End class
// </Snippet1>

