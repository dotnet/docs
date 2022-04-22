using System;
using System.IO;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

public class Test
{
    public class DownloadAuthorization { }

    static void Main()
    {
        Console.WriteLine("Hello");
    }

    //<snippet1>
    [WebMethod]
    [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
    public SongStream DownloadSong(DownloadAuthorization Authorization, string filePath)
    {
        // Turn off response buffering.
        System.Web.HttpContext.Current.Response.Buffer = false;
        // Return a song.
        SongStream song = new SongStream(filePath);
        return song;
    }
    //</snippet1>
}

//<snippet2>
[XmlSchemaProvider("MySchema")]
public class SongStream : IXmlSerializable
{
    private const string ns = "http://demos.Contoso.com/webservices";
    private string filePath;

    public SongStream() { }

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

    XmlSchema IXmlSerializable.GetSchema()
    {
        throw new NotImplementedException();
    }

    void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
    {
        throw new NotImplementedException();
    }
}
//</snippet2>

public delegate void ProgressMade(double Progress);

//<snippet3>
public class SongFile : IXmlSerializable
{
    public static event ProgressMade OnProgress;

    public SongFile()
    { }

    private const string ns = "http://demos.teched2004.com/webservices";
    public static string MusicPath;
    private string filePath;
    private double size;

    void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
    {
        reader.ReadStartElement("DownloadSongResult", ns);
        ReadFileName(reader);
        ReadSongSize(reader);
        ReadAndSaveSong(reader);
        reader.ReadEndElement();
    }

    void ReadFileName(XmlReader reader)
    {
        string fileName = reader.ReadElementString("fileName", ns);
        this.filePath =
            Path.Combine(MusicPath, Path.ChangeExtension(fileName, ".mp3"));
    }

    void ReadSongSize(XmlReader reader)
    {
        this.size = Convert.ToDouble(reader.ReadElementString("size", ns));
    }

    void ReadAndSaveSong(XmlReader reader)
    {
        FileStream outFile = File.Open(
            this.filePath, FileMode.Create, FileAccess.Write);

        string songBase64;
        byte[] songBytes;
        reader.ReadStartElement("song", ns);
        double totalRead = 0;
        while (true)
        {
            if (reader.IsStartElement("chunk", ns))
            {
                songBase64 = reader.ReadElementString();
                totalRead += songBase64.Length;
                songBytes = Convert.FromBase64String(songBase64);
                outFile.Write(songBytes, 0, songBytes.Length);
                outFile.Flush();

                if (OnProgress != null)
                {
                    OnProgress(100 * (totalRead / size));
                }
            }

            else
            {
                break;
            }
        }

        outFile.Close();
        reader.ReadEndElement();
    }

    public void Play()
    {
        System.Diagnostics.Process.Start(this.filePath);
    }

    XmlSchema IXmlSerializable.GetSchema()
    {
        throw new NotImplementedException();
    }

    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }
}
//</snippet3>
