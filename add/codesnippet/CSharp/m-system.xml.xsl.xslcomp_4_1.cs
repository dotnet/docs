// Create a reader that contains the style sheet.
XmlReader reader = XmlReader.Create("titles.xsl");
reader.ReadToDescendant("xsl:stylesheet");

// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load(reader);