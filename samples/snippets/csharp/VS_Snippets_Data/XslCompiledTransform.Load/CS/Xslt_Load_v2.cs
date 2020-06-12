using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Net;

class XslCompiledTransformLoad {

  static void Main() {
  }

// Load with XPathDocument.
static void XslCompiledTransform_Load1() {
//<snippet1>
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load(new XPathDocument("http://serverName/data/xsl/sort.xsl"));
//</snippet1>
}

//==============================//
// Load URI with XmlResolver
static void XslCompiledTransform_Load2() {
//<snippet2>
// Create the XslCompiledTransform object.
XslCompiledTransform xslt = new XslCompiledTransform();

// Create a resolver and set the credentials to use.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
resolver.Credentials = CredentialCache.DefaultCredentials;

// Load the style sheet.
xslt.Load("http://serverName/data/xsl/sort.xsl", null, resolver);
//</snippet2>
}
//==============================//
// Load reader with resolver & settings
static void XslCompiledTransform_Load3() {
//<snippet3>
// Create the XslCompiledTransform object.
XslCompiledTransform xslt = new XslCompiledTransform();

// Create a resolver and set the credentials to use.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
resolver.Credentials = CredentialCache.DefaultCredentials;

XmlReader reader = XmlReader.Create("http://serverName/data/xsl/sort.xsl");

// Create the XsltSettings object with script enabled.
XsltSettings settings = new XsltSettings(false,true);

// Load the style sheet.
xslt.Load(reader, settings, resolver);
//</snippet3>
}

//==============================//
// Load with XPathDocument and credentials
static void XslCompiledTransform_Load4() {

	string UserName = "username";
	string SecurelyStoredPassword = "psswd";
	string Domain= "domain";

//<snippet4>
// Create a resolver and specify the necessary credentials.
XmlUrlResolver resolver = new XmlUrlResolver();
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);
resolver.Credentials = myCred;

// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load(new XPathDocument("http://serverName/data/xsl/sort.xsl"), XsltSettings.Default, resolver);
//</snippet4>
}

//==============================//
// Load with XmlReader
static void XslCompiledTransform_Load5() {
//<snippet5>
// Create a reader that contains the style sheet.
XmlReader reader = XmlReader.Create("titles.xsl");
reader.ReadToDescendant("xsl:stylesheet");

// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load(reader);
//</snippet5>
}

//==============================//
// Load with script enabled.
static void XslCompiledTransform_Load6() {
//<snippet6>
// Create the XsltSettings object with script enabled.
XsltSettings settings = new XsltSettings(false,true);

// Create the XslCompiledTransform object and load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("sort.xsl", settings, new XmlUrlResolver());
//</snippet6>
}

//==============================//
// Load with default XSLT settings.
static void XslCompiledTransform_Load7() {
//<snippet7>
// Create the XslCompiledTransform object and load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("sort.xsl", XsltSettings.Default, new XmlUrlResolver());
//</snippet7>
}

//==============================//
// Load with trusted XSLT settings.
static void XslCompiledTransform_Load8() {

	string UserName = "username";
	string SecurelyStoredPassword = "psswd";
	string Domain= "domain";

//<snippet8>
// Create a resolver and specify the necessary credentials.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);
resolver.Credentials = myCred;

// Create the XslCompiledTransform object and load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("http://serverName/data/script.xsl", XsltSettings.TrustedXslt, resolver);	
//</snippet8>
}

//==============================//
// Load with script enabled.
static void XslCompiledTransform_Load9() {
//<snippet9>
// Create the XsltSettings object with script enabled.
XsltSettings settings = new XsltSettings();
settings.EnableScript = true;

// Create a resolver that will be used to resolve the style sheet.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");

// Create the XslCompiledTransform object and load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("http://serverName/data/sort.xsl", settings, resolver);
//</snippet9>
    }
//==============================//
//
static void XslCompiledTransform_Debug() {
//<snippet10>
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
//</snippet10>
}

//==============================//
// Load w/ credential cache.
static void Cache() {

	string UserName = "username";
	string SecurelyStoredPassword = "psswd";
	string Domain= "domain";

//<snippet11>
// Create the credentials.
NetworkCredential myCred = new NetworkCredential(UserName,SecurelyStoredPassword,Domain);
CredentialCache myCache = new CredentialCache();
myCache.Add(new Uri("http://www.contoso.com/"), "Basic", myCred);
myCache.Add(new Uri("http://app.contoso.com/"), "Basic", myCred);

// Set the credentials on the XmlUrlResolver object.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = myCache;

// Compile the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("http://serverName/data/xsl/order.xsl",XsltSettings.Default, resolver);	
//</snippet11>
}
}