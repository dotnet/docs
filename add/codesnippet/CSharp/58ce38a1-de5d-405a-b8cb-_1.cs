// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Create the writer.
XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;
settings.IndentChars = "\t";
XmlWriter writer = XmlWriter.Create("output.xml", settings);

// Execute the transformation.
xslt.Transform(new XPathDocument("books.xml"), writer);
writer.Close();