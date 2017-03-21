// Enable XSLT debugging.
XslCompiledTransform xslt = new XslCompiledTransform(true);

// Load the style sheet.
xslt.Load("output.xsl");

// Create the writer.
XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent=true;
XmlWriter writer = XmlWriter.Create("output.xml", settings);

// Execute the transformation.
xslt.Transform("books.xml", writer);
writer.Close();