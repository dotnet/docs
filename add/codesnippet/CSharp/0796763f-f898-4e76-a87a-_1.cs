string xmlFrag ="<item rk:ID='abc-23'>hammer</item> " +
                        "<item rk:ID='r2-435'>paint</item>" +
                        "<item rk:ID='abc-39'>saw</item>";

// Create the XmlNamespaceManager.
NameTable nt = new NameTable();
XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
nsmgr.AddNamespace("rk", "urn:store-items");

// Create the XmlParserContext.
XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

// Create the reader. 
XmlReaderSettings settings = new XmlReaderSettings();
settings.ConformanceLevel = ConformanceLevel.Fragment;
XmlReader reader = XmlReader.Create(new StringReader(xmlFrag), settings, context);
