using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        


    }

//<SNIPPET1>
    public byte[] OpenDataFile(string FileName)
    {
        // Check the FileName argument.
        if (FileName == null || FileName.Length == 0)
        {
            throw new ArgumentNullException("FileName");
        }

        // Check to see if the file exists.
        FileInfo fInfo = new FileInfo(FileName);
        
        // You can throw a personalized exception if 
        // the file does not exist.
        if (!fInfo.Exists)
        {
            throw new FileNotFoundException("The file was not found.", FileName);
        }

        // Open the file.
        FileStream fStream = new FileStream(FileName, FileMode.Open);

        // Create a buffer.
        byte [] buffer = new byte[fStream.Length];

        // Read the file contents to the buffer.
        fStream.Read(buffer, 0, (int)fStream.Length);

        // return the buffer.
        return buffer;

    }
//</SNIPPET1>
}