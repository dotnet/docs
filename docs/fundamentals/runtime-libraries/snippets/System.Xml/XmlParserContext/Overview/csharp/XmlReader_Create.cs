using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Net;

class XmlReaderSettings_Examples
{
    static void Main()
    {
    }

    //
    static void String_Fragment()
    {
        //<snippet1>
        string xmlFrag = """
            <item rk:ID='abc-23'>hammer</item>
            <item rk:ID='r2-435'>paint</item>
            <item rk:ID='abc-39'>saw</item>
            """;

        // Create the XmlNamespaceManager.
        NameTable nt = new NameTable();
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
        nsmgr.AddNamespace("rk", "urn:store-items");

        // Create the XmlParserContext.
        XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

        // Create the reader.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ConformanceLevel = ConformanceLevel.Fragment;
        XmlReader reader = XmlReader.Create(new StringReader(xmlFrag), settings, context);
        //</snippet1>
    }

    // Load URI with XmlResolver
    static void Settings_Resolver()
    {
        string UserName = "username";
        string SecurelyStoredPassword = "psswd";
        string Domain = "domain";

        //<snippet2>
        // Create an XmlUrlResolver with the credentials necessary to access the Web server.
        var resolver = new XmlUrlResolver();
        var myCred = new NetworkCredential(UserName, SecurelyStoredPassword, Domain);
        resolver.Credentials = myCred;

        var settings = new XmlReaderSettings();
        settings.XmlResolver = resolver;

        // Create the reader.
        XmlReader reader = XmlReader.Create("http://serverName/data/books.xml", settings);
        //</snippet2>
    }

    // DTD Validation
    static void Settings_ProhibitDtd()
    {
        //<snippet3>
        // Set the validation settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.DtdProcessing = DtdProcessing.Parse;
        settings.ValidationType = ValidationType.DTD;
        settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create("itemDTD.xml", settings);

        // Parse the file.
        while (reader.Read()) { }
        //</snippet3>
    }

    // <snippet4>
    // Display any validation errors.
    private static void ValidationCallBack(object sender, ValidationEventArgs e)
    {
        Console.WriteLine($"Validation Error: {e.Message}");
    }
    //</snippet4>

    // Wrapped Reader
    static void WrappedReader_Settings()
    {
        // <snippet5>
        // Create the XmlNodeReader object.
        XmlDocument doc = new XmlDocument();
        doc.Load("books.xml");
        XmlNodeReader nodeReader = new XmlNodeReader(doc);

        // Set the validation settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas.Add("urn:bookstore-schema", "books.xsd");
        settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

        // Create a validating reader that wraps the XmlNodeReader object.
        XmlReader reader = XmlReader.Create(nodeReader, settings);
        // Parse the XML file.
        while (reader.Read()) ;

        //</snippet5>
    }

    static void URI()
    {
        // <snippet6>
        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create("books.xml");
        //</snippet6>
    }

    static void XML_String()
    {
        // <snippet7>
        string xmlData = """
            <item productID='124390'>
                <price>5.95</price>
            </item>
            """;

        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create(new StringReader(xmlData));
        //</snippet7>
    }

    static void FileStream()
    {
        // <snippet8>
        FileStream fs = new FileStream(
            @"C:\data\books.xml",
            FileMode.OpenOrCreate,
            FileAccess.Read,
            FileShare.Read);

        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create(fs);
        //</snippet8>
    }

    static void FileStream_Settings()
    {
        // <snippet9>

        FileStream fs = new FileStream(
            @"C:\data\books.xml",
            FileMode.OpenOrCreate,
            FileAccess.Read,
            FileShare.Read);

        XmlUrlResolver resolver = new XmlUrlResolver();
        resolver.Credentials = CredentialCache.DefaultCredentials;
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.XmlResolver = resolver;

        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create(fs, settings);
        //</snippet9>
    }

    // Secure Resolver
    static void Settings_SecureResolver()
    {
        //<snippet10>
        // Create an XmlSecureResolver with default credentials.
        var myResolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
        myResolver.Credentials = CredentialCache.DefaultCredentials;

        XmlReaderSettings settings = new XmlReaderSettings();
        settings.XmlResolver = myResolver;

        // Create the reader.
        XmlReader reader = XmlReader.Create("http://serverName/data/books.xml", settings);
        //</snippet10>
    }

    //
    static void GeneralSettings()
    {
        //<snippet11>
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ConformanceLevel = ConformanceLevel.Fragment;
        settings.IgnoreWhitespace = true;
        settings.IgnoreComments = true;
        XmlReader reader = XmlReader.Create("books.xml", settings);
        //</snippet11>
    }

    //
    static void ChainReaders()
    {
        //<snippet12>
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.DTD;
        XmlReader inner = XmlReader.Create("book.xml", settings); // DTD Validation
        settings.Schemas.Add("urn:book-schema", "book.xsd");
        settings.ValidationType = ValidationType.Schema;
        XmlReader outer = XmlReader.Create(inner, settings);  // XML Schema Validation
        //</snippet12>
    }

    //
    static void WrapTextReader()
    {
        //<snippet13>
        XmlTextReader txtReader = new XmlTextReader("bookOrder.xml");
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add("urn:po-schema", "PO.xsd");
        settings.ValidationType = ValidationType.Schema;
        XmlReader reader = XmlReader.Create(txtReader, settings);
        //</snippet13>
    }
}
