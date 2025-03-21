using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Net;

class XML_Migration_Samples {

  static void Main() {
  }

public void XmlReader_Creation_Old() {
//<snippet1>
// Supply the credentials necessary to access the Web server.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = CredentialCache.DefaultCredentials;

// Create the XmlTextReader.
XmlTextReader reader = new XmlTextReader("http://serverName/data/books.xml");
reader.WhitespaceHandling = WhitespaceHandling.None;
reader.XmlResolver = resolver;
//</snippet1>
}

//==============================
//
static void XmlReader_Creation_New() {
//<snippet2>
// Supply the credentials necessary to access the Web server.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = CredentialCache.DefaultCredentials;

// Create the XmlReader.
XmlReaderSettings settings = new XmlReaderSettings();
settings.IgnoreWhitespace = true;
settings.XmlResolver = resolver;
XmlReader reader = XmlReader.Create("http://serverName/data/books.xml", settings);
//</snippet2>
}
//==============================
//
static void XML_Validation_Old() {
//<snippet3a>
XmlValidatingReader reader = new XmlValidatingReader(new XmlTextReader("books.xml"));
reader.ValidationType = ValidationType.Schema;
reader.Schemas.Add("urn:books", "books.xsd");
reader.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
while (reader.Read());
//</snippet3a>
}
//<snippet3b>
private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    Console.WriteLine($"Validation Error: {e.Message}");
}
//</snippet3b>

//==============================
//
static void XML_Validation_New() {
//<snippet4a>
XmlReaderSettings settings = new XmlReaderSettings();
settings. ValidationType = ValidationType.Schema;
settings.Schemas.Add("urn:books", "books.xsd");
settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
XmlReader reader = XmlReader.Create("books.xml",settings);
while (reader.Read());
//</snippet4a>
}
//<snippet4b>
private static void ValidationCallBack1(object sender, ValidationEventArgs e) {
    Console.WriteLine($"Validation Error: {e.Message}");
}
//</snippet4b>

//==============================
//
static void XmlWriter_Creation_Old() {
//<snippet5>
XmlTextWriter writer = new XmlTextWriter("books.xml", Encoding.Unicode);
writer.Formatting = Formatting.Indented;
//</snippet5>
}

//==============================
//
static void XmlWriter_Creation_New() {
//<snippet6>
XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;
settings.Encoding = Encoding.Unicode;
XmlWriter writer = XmlWriter.Create("books.xml", settings);
//</snippet6>
}

//==============================
//
static void XSLT_Old() {
string filename = "books.xml";
//<snippet7>
// Create the XslTransform.
XslTransform xslt = new XslTransform();

// Create a resolver and set the credentials to use.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = CredentialCache.DefaultCredentials;

// Load the style sheet.
xslt.Load("http://serverName/data/xsl/sort.xsl", resolver);

// Transform the file.
XPathDocument doc = new XPathDocument(filename);
XmlTextWriter writer = new XmlTextWriter("output.xml", null);
xslt.Transform(doc, null, writer, null);
//</snippet7>
}

//==============================
//
static void XSLT_New() {
//<snippet8>
// Create the XslCompiledTransform object.
XslCompiledTransform xslt = new XslCompiledTransform();

// Create a resolver and set the credentials to use.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = CredentialCache.DefaultCredentials;

// Load the style sheet.
xslt.Load("http://serverName/data/xsl/sort.xsl", XsltSettings.Default, resolver);

// Transform the file.
XmlWriter writer = XmlWriter.Create("output.xml");
xslt.Transform("books.xml", writer);
//</snippet8>
}

//==============================
//
static void XSLT_URI_Old() {
//<snippet9>
XslTransform xslt = new XslTransform();
xslt.Load("output.xsl");
xslt.Transform("books.xml", "books.html");
//</snippet9>
}

//==============================
//
static void XSLT_URI_New() {
//<snippet10>
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");
xslt.Transform("books.xml", "books.html");
//</snippet10>
}

//==============================
//
static void Stylesheet_Credentials_Old() {
//<snippet11>
XslTransform xslt = new XslTransform();
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = CredentialCache.DefaultCredentials;
xslt.Load("sort.xsl", resolver);
//</snippet11>
}

//==============================
//
static void Stylesheet_Credentials_New() {
//<snippet12>
XslCompiledTransform xslt = new XslCompiledTransform();
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = CredentialCache.DefaultCredentials;
xslt.Load("sort.xsl", XsltSettings.Default, resolver);
//</snippet12>
}

//==============================
//
static void XSLT_Param_Old() {
string filename = "books.xml";
//<snippet13>
XslTransform xslt = new XslTransform();
xslt.Load("order.xsl");

//Create the XsltArgumentList.
XsltArgumentList argList = new XsltArgumentList();

//Create a parameter which represents the current date and time.
DateTime d = DateTime.Now;
argList.AddParam("date", "", d.ToString());

//Create the XmlTextWriter.
XmlTextWriter writer = new XmlTextWriter("output.xml", null);

//Transform the file.
xslt.Transform(new XPathDocument(filename), argList, writer, null);
//</snippet13>
}

//==============================
//
static void XSLT_Param_New() {
string filename = "books.xml";
//<snippet14>
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("order.xsl");

// Create the XsltArgumentList.
XsltArgumentList argList = new XsltArgumentList();

// Create a parameter which represents the current date and time.
DateTime d = DateTime.Now;
argList.AddParam("date", "", d.ToString());

// Create the XmlWriter.
XmlWriter writer = XmlWriter.Create("output.xml", null);

// Transform the file.
xslt.Transform(new XPathDocument(filename), argList, writer);
//</snippet14>
}

//==============================
//
static void XSLT_Script_Old() {
//<snippet15>
XslTransform xslt = new XslTransform();
xslt.Load("output.xsl");
xslt.Transform("books.xml", "books.html");
//</snippet15>
}

//==============================
//
static void XSLT_Script_New() {
//<snippet16>
// Create the XsltSettings object with script enabled.
XsltSettings settings = new XsltSettings(false,true);

// Execute the transform.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("calc.xsl", settings, new XmlUrlResolver());
xslt.Transform("books.xml", "books.html");
//</snippet16>
}

//==============================
//
static void XSLT_Roundtrip_Old() {
//<snippet17>
// Execute the transformation.
XslTransform xslt = new XslTransform();
xslt.Load("output.xsl");
XmlReader reader = xslt.Transform(new XPathDocument("books.xml"), null, new XmlUrlResolver());

// Load the results into an XPathDocument object.
XPathDocument doc = new XPathDocument(reader);
//</snippet17>
}

//==============================
//
static void XSLT_Roundtrip_New() {
//<snippet18>
// Execute the transformation.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");
MemoryStream ms = new MemoryStream();
xslt.Transform(new XPathDocument("books.xml"), null, ms);

// Load the results into an XPathDocument object.
ms.Seek(0, SeekOrigin.Begin);
XPathDocument doc = new XPathDocument(ms);
//</snippet18>
}

//==============================
//
static void XSLT_DOM_Old() {
//<snippet19>
// Execute the transformation.
XslTransform xslt = new XslTransform();
xslt.Load("output.xsl");
XmlReader reader = xslt.Transform(new XPathDocument("books.xml"), null, new XmlUrlResolver());

// Load the results into a DOM object.
XmlDocument doc = new XmlDocument();
doc.Load(reader);
//</snippet19>
}

//==============================
//
static void XSLT_DOM_New() {
//<snippet20>
// Execute the transformation.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("output.xsl");
xslt.Transform("books.xml", "output.xml");

// Load the results into a DOM object.
XmlDocument doc = new XmlDocument();
doc.Load("output.xml");
//</snippet20>
}
}