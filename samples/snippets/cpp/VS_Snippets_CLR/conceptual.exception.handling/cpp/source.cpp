//<snippet1>
using namespace System;
using namespace System::IO;

public ref class FileReaderException : public Exception
{
public:
    FileReaderException(String^ description) : Exception(description)
    {
    }
};

[Flags]
public enum class ConnectionState
{
    Closed = 0,
    Open = 1
};

public ref class DemoDBClient
{
private:
    ConnectionState state;

public:
    DemoDBClient()
    {
        state = ConnectionState::Open;
    }

    property ConnectionState State
    {
        ConnectionState get()
        {
            return state;
        }
    }

    void Close()
    {
        state = ConnectionState::Closed;
    }
};

public ref class FileUtils
{
public:
    static array<Byte>^ ReadFromFile(String^ filename, int bytes)
    {
        return File::ReadAllBytes(filename);
    }
};

//<snippet4>
public ref class MyFileNotFoundException : public Exception
{
};
//</snippet4>


public ref class ExceptionHandling
{
public:
    static void Main()
    {
        DemoDBClient^ conn = gcnew DemoDBClient();

        //<snippet2>
        if (conn->State != ConnectionState::Closed)
        {
            conn->Close();
        }
        //</snippet2>

        //<snippet3>
        try
        {
            conn->Close();
        }
        catch (InvalidOperationException^ ex)
        {
            Console::WriteLine(ex->GetType()->FullName);
            Console::WriteLine(ex->Message);
        }
        //</snippet3>
    }
};

//<snippet5>
class FileRead
{
public:
    void ReadAll(FileStream^ fileToRead)
    {
        // This if statement is optional
        // as it is very unlikely that
        // the stream would ever be null.
        if (fileToRead == nullptr)
        {
            throw gcnew System::ArgumentNullException();
        }

        int b;

        // Set the stream position to the beginning of the file.
        fileToRead->Seek(0, SeekOrigin::Begin);

        // Read each byte to the end of the file.
        for (int i = 0; i < fileToRead->Length; i++)
        {
            b = fileToRead->ReadByte();
            Console::Write(b.ToString());
            // Or do something else with the byte.
        }
    }
};
//</snippet5>

//<snippet6>
ref class FileReader
{
private:
    String^ fileName;

public:
    FileReader(String^ path)
    {
        fileName = path;
    }

    array<Byte>^ Read(int bytes)
    {
        array<Byte>^ results = FileUtils::ReadFromFile(fileName, bytes);
        if (results == nullptr)
        {
            throw NewFileIOException();
        }
        return results;
    }

    FileReaderException^ NewFileIOException()
    {
        String^ description = "My NewFileIOException Description";

        return gcnew FileReaderException(description);
    }
};
//</snippet6>
int main()
{
    ExceptionHandling::Main();
}
//</snippet1>
