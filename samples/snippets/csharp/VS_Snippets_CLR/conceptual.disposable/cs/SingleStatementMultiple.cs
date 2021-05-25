using System.IO;

class SingleStatementMultiple
{
    static void Main()
    {
        var buffer1 = new char[50];
        var buffer2 = new char[50];

        using StreamReader version1 = new("file1.txt"),
                           version2 = new("file2.txt");

        int charsRead1, charsRead2 = 0;
        while (version1.Peek() != -1 && version2.Peek() != -1)
        {
            charsRead1 = version1.Read(buffer1, 0, buffer1.Length);
            charsRead2 = version2.Read(buffer2, 0, buffer2.Length);
            //
            // Process characters read.
            //
        }
    }
}
