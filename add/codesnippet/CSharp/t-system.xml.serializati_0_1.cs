[XmlSchemaProvider("MySchema")]
public class SongStream : IXmlSerializable
{

    private const string ns = "http://demos.Contoso.com/webservices";
    private string filePath;

    public SongStream(){ }

    public SongStream(string filePath)
    {
     this.filePath = filePath;
    }

    // This is the method named by the XmlSchemaProviderAttribute applied to the type.
    public static XmlQualifiedName MySchema(XmlSchemaSet xs)
    {
     // This method is called by the framework to get the schema for this type.
     // We return an existing schema from disk.

     XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
     string xsdPath = null;
     // NOTE: replace the string with your own path.
     xsdPath = System.Web.HttpContext.Current.Server.MapPath("SongStream.xsd");
     XmlSchema s = (XmlSchema)schemaSerializer.Deserialize(
         new XmlTextReader(xsdPath), null);
     xs.XmlResolver = new XmlUrlResolver();
     xs.Add(s);

     return new XmlQualifiedName("songStream", ns);
    }


    void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
    {
       // This is the chunking code.
       // ASP.NET buffering must be turned off for this to work.
 

     int bufferSize = 4096;
     char[] songBytes = new char[bufferSize];
     FileStream inFile = File.Open(this.filePath, FileMode.Open, FileAccess.Read);

     long length = inFile.Length;

     // Write the file name.
     writer.WriteElementString("fileName", ns, Path.GetFileNameWithoutExtension(this.filePath));

     // Write the size.
     writer.WriteElementString("size", ns, length.ToString());

     // Write the song bytes.
     writer.WriteStartElement("song", ns);

     StreamReader sr = new StreamReader(inFile, true);
     int readLen = sr.Read(songBytes, 0, bufferSize);

     while (readLen > 0)
     {
         writer.WriteStartElement("chunk", ns);
         writer.WriteChars(songBytes, 0, readLen);
         writer.WriteEndElement();

         writer.Flush();
         readLen = sr.Read(songBytes, 0, bufferSize);
     }

     writer.WriteEndElement();
     inFile.Close();

    }


    System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
    {
     throw new System.NotImplementedException();
    }

    void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
    {
     throw new System.NotImplementedException();

    }
}