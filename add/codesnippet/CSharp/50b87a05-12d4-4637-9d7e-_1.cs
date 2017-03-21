// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("HTML_out.xsl");

// Transform the file and output an HTML string.
string HTMLoutput;
StringWriter writer = new StringWriter();
xslt.Transform("books.xml", null, writer);
HTMLoutput = writer.ToString();
writer.Close();