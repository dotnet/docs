//<snippet1>
public class FileReaderException : Exception
{
    public FileReaderException(string description) : base(description)
    {
    }
}

[Flags]
public enum ConnectionState
{
    Closed = 0,
    Open = 1
}

public class DemoDBClient
{
    public DemoDBClient()
    {
        State = ConnectionState.Open;
    }

    public ConnectionState State { get; private set; }

    public void Close()
    {
        State = ConnectionState.Closed;
    }
}

public class FileUtils
{
    public static byte[] ReadFromFile(string filename, int bytes)
    {
        return File.ReadAllBytes(filename);
    }
}

//<snippet4>
public class MyFileNotFoundException : Exception
{
}
//</snippet4>

public class ExceptionHandling
{
    public static void Main()
    {
        var conn = new DemoDBClient();

        //<snippet2>
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();
        }
        //</snippet2>

        //<snippet3>
        try
        {
            conn.Close();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
        }
        //</snippet3>
    }
}

//<snippet5>
class FileRead
{
    public static void ReadAll(FileStream fileToRead)
    {
        ArgumentNullException.ThrowIfNull(fileToRead);

        int b;

        // Set the stream position to the beginning of the file.
        fileToRead.Seek(0, SeekOrigin.Begin);

        // Read each byte to the end of the file.
        for (int i = 0; i < fileToRead.Length; i++)
        {
            b = fileToRead.ReadByte();
            Console.Write(b.ToString());
            // Or do something else with the byte.
        }
    }
}
//</snippet5>

//<snippet6>
class FileReader
{
    private readonly string _fileName;

    public FileReader(string path)
    {
        _fileName = path;
    }

    public byte[] Read(int bytes)
    {
        byte[] results = FileUtils.ReadFromFile(_fileName, bytes) ?? throw NewFileIOException();
        return results;
    }

    static FileReaderException NewFileIOException()
    {
        string description = "My NewFileIOException Description";

        return new FileReaderException(description);
    }
}
//</snippet6>
//</snippet1>
