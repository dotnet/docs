//<snippet1>
using System;
using System.Xml;
using System.IO;

class Example
{
    static void Main()
    {
        // Create an XmlUrlResolver with default credentials.
        XmlUrlResolver resolver = new XmlUrlResolver();
        resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

        // Point the resolver at the desired resource and resolve as a stream.
        Uri baseUri = new Uri("http://serverName/");
        Uri fulluri = resolver.ResolveUri(baseUri, "fileName.xml");
        Stream s = (Stream)resolver.GetEntity(fulluri, null, typeof(Stream));

        // Create the reader with the resolved stream and display the data.
        XmlReader reader = XmlReader.Create(s);
        while (reader.Read())
        {
            Console.WriteLine(reader.ReadOuterXml());
        }
    }
}
//</snippet1>
//If IIS is in "Basic" auth mode, supply credentials explicitly
//System.Net.NetworkCredential creds = new System.Net.NetworkCredential(UserName, Password, Domain);
//resolver.Credentials = creds;