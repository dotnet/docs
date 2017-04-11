//<snippet1>
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class FileReaderException : Exception
{
    public FileReaderException(string description) : base(description)
    {
    }
}

[FlagsAttribute]
public enum ConnectionState
{
    Closed = 0,
    Open = 1
}

public class DemoDBClient
{
    private ConnectionState state;

    public DemoDBClient()
    {
        state = ConnectionState.Open;
    }

    public ConnectionState State
    {
        get
        {
            return state;
        }
    }

    public void Close()
    {
        state = ConnectionState.Closed;
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
        DemoDBClient conn = new DemoDBClient();

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
    public void ReadAll(FileStream fileToRead)
    {
        // This if statement is optional
        // as it is very unlikely that
        // the stream would ever be null.
        if (fileToRead == null)
        {
            throw new System.ArgumentNullException();
        }

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
    private string fileName;

    public FileReader(string path)
    {
        fileName = path;
    }

    public byte[] Read(int bytes)
    {
        byte[] results = FileUtils.ReadFromFile(fileName, bytes);
        if (results == null)
        {
            throw NewFileIOException();
        }
        return results;
    }

    FileReaderException NewFileIOException()
    {
        string description = "My NewFileIOException Description";

        return new FileReaderException(description);
    }
}
//</snippet6>
//</snippet1>
