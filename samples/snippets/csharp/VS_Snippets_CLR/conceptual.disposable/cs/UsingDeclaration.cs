using System.IO;

class UsingDeclaration
{
    static void Main()
    {
        var buffer = new char[50];
        using StreamReader streamReader = new("file1.txt");

        int charsRead = 0;
        while (streamReader.Peek() != -1)
        {
            charsRead = streamReader.Read(buffer, 0, buffer.Length);
            //
            // Process characters read.
            //
        }
    }
}
