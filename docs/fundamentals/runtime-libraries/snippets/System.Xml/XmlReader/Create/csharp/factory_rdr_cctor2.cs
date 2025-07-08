using System.Xml;

public class Sample
{
    public static void Main()
    {
        // <snippet1>
        // Set the reader settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
        settings.IgnoreProcessingInstructions = true;
        settings.IgnoreWhitespace = true;
        // </snippet1>

        //<snippet2>
        // Create a resolver with default credentials.
        XmlUrlResolver resolver = new XmlUrlResolver();
        resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

        // Set the reader settings object to use the resolver.
        settings.XmlResolver = resolver;

        // Create the XmlReader object.
        XmlReader reader = XmlReader.Create("http://ServerName/data/books.xml", settings);
        // </snippet2>

        // Parse the file.
        while (reader.Read()) ;
    }
}
