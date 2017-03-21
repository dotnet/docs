// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Create the writer.
XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;
settings.IndentChars = "\t";
XmlWriter writer = XmlWriter.Create("output.xml", settings);

XmlReader reader = XmlReader.Create("books.xml");
reader.MoveToContent();

// Execute the transformation.
xslt.Transform(reader, writer);
writer.Close();
reader.Close();