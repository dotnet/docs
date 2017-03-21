// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Create the FileStream.
using (FileStream fs = new FileStream(@"c:\data\output.xml", FileMode.Create))
{
   // Execute the transformation.
   xslt.Transform(new XPathDocument("books.xml"), null, fs);
}