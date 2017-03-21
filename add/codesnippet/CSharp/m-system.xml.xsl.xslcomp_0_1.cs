// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Execute the transform and output the results to a file.
xslt.Transform("books.xml", "books.html");