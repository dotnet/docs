// <Snippet1>
using System;
using System.Xml;

public class Sample
{

    public static void Main()
    {

        XmlTextReader reader = null;

        try
        {

            // Create the string containing the XML to read.
            String xmlFrag = "<book>" +
                           "<title>Pride And Prejudice</title>" +
                           "<author>" +
                           "<first-name>Jane</first-name>" +
                           "<last-name>Austen</last-name>" +
                           "</author>" +
                           "<curr:price>19.95</curr:price>" +
                           "<misc>&h;</misc>" +
                           "</book>";

            // Create an XmlNamespaceManager to resolve namespaces.
            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            nsmgr.AddNamespace(String.Empty, "urn:samples"); //default namespace
            nsmgr.AddNamespace("curr", "urn:samples:dollar");

            // Create an XmlParserContext.  The XmlParserContext contains all the information
            // required to parse the XML fragment, including the entity information and the
            // XmlNamespaceManager to use for namespace resolution.
            XmlParserContext context;
            String subset = "<!ENTITY h 'hardcover'>";
            context = new XmlParserContext(nt, nsmgr, "book", null, null, subset, null, null, XmlSpace.None);

            // Create the reader.
            reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);

            // Parse the file and display the node values.
            while (reader.Read())
            {
                if (reader.HasValue)
                    Console.WriteLine("{0} [{1}] = {2}", reader.NodeType, reader.Name, reader.Value);
                else
                    Console.WriteLine("{0} [{1}]", reader.NodeType, reader.Name);
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

