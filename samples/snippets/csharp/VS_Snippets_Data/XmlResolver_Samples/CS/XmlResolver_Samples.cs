using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;

class Sample
{
	static void Main()
	{

    }

    // Default credentials
    static void XmlUrlResolver_Credentials1()
    {
        //<snippet1>

    // Create an XmlUrlResolver with default credentials.
    XmlUrlResolver resolver = new XmlUrlResolver();
    resolver.Credentials = CredentialCache.DefaultCredentials;

    // Create the reader.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.XmlResolver = resolver;
    XmlReader reader = 
         XmlReader.Create("http://serverName/data/books.xml", settings);
   
//</snippet1>
    }


    // Resolver with specific credentials
    static void XmlUrlResolver_Credentials2()
    {

	string UserName = "username";
	string SecurelyStoredPassword = "psswd";
	string Domain= "domain";

        //<snippet2>

    // Create a resolver and specify the necessary credentials.
    XmlUrlResolver resolver = new XmlUrlResolver();
    System.Net.NetworkCredential myCred;
    myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
    resolver.Credentials = myCred;

        //</snippet2>
    }


}