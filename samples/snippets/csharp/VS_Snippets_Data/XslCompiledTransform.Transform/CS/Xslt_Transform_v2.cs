using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Net;

class XslCompiledTransform_Samples {

   static void Main() {
	
    }

 // Transform files
static void XslCompiledTransform_Transform1() {
//<snippet1>
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Execute the transform and output the results to a file.
xslt.Transform("books.xml", "books.html");
//</snippet1>
}

//==============================//
// Transform URI and XmlWriter
static void XslCompiledTransform_Transform2() {
//<snippet2>
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Create the writer.
XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;
settings.IndentChars = "\t";
XmlWriter writer = XmlWriter.Create("output.xml", settings);

// Execute the transformation.
xslt.Transform("books.xml", writer);
writer.Close();
//</snippet2>
}

//==============================//
// Transform URI and TextWriter
static void XslCompiledTransform_Transform3()  {
//<snippet3>
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("HTML_out.xsl");

// Transform the file and output an HTML string.
string HTMLoutput;
StringWriter writer = new StringWriter();
xslt.Transform("books.xml", null, writer);
HTMLoutput = writer.ToString();
writer.Close();
//</snippet3>
}

//==============================//		
// Transform with document function
static void XslCompiledTransform_Transform4()  {
	string UserName = "username";
	string SecurelyStoredPassword = "psswd";
	string Domain= "domain";

//<snippet4>
// Create a resolver and specify the necessary credentials.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
resolver.Credentials = myCred;

XsltSettings settings = new XsltSettings();
settings.EnableDocumentFunction = true;
  
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("http://serverName/data/xsl/sort.xsl", settings, resolver);

// Transform the file.
using (XmlReader reader = XmlReader.Create("books.xml"))
{
   using (XmlWriter writer = XmlWriter.Create("output.xml")) 
   {
      xslt.Transform(reader, null, writer, resolver);
   }
}
//</snippet4>
}

//==============================//
// Transform XPathDocument and XmlWriter
static void XslCompiledTransform_Transform5()   {
//<snippet5>
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
//</snippet5>
}

//==============================//
// Transform XPathDocument and FileStream
static void XslCompiledTransform_Transform6()  {
//<snippet6>
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");

// Create the FileStream.
using (FileStream fs = new FileStream(@"c:\data\output.xml", FileMode.Create))
{
   // Execute the transformation.
   xslt.Transform(new XPathDocument("books.xml"), null, fs);
}
//</snippet6>
}

//==============================//
// Transform XmlReader and XmlWriter
static void XslCompiledTransform_Transform7()  {
//<snippet7>
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
//</snippet7>
  }

//==============================//
// Print Names of Temp Files
static void Print_TempFiles()
{
    //<snippet8>
    // Create the XslCompiledTransform object.
    XslCompiledTransform xslt = new XslCompiledTransform(true);

    // Load the style sheet and enable scripts.
    // Temporary files are created only for style sheets with <msxsl:script> blocks.
    xslt.Load("output.xsl", XsltSettings.TrustedXslt, new XmlUrlResolver());

    // Transform the file.
    xslt.Transform("books.xml", "output.xml");

    // Output names of temporary files.
    foreach (string filename in xslt.TemporaryFiles)
        Console.WriteLine(filename);
    //</snippet8>
}

}