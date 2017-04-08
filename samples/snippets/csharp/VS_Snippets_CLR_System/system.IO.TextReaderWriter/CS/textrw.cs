// <Snippet1>
using System;
using System.IO;

class TextRW
{
    static void Main()
    {
        // <Snippet2>
        TextWriter stringWriter = new StringWriter();
        using(TextWriter streamWriter = 
            new StreamWriter("InvalidPathChars.txt"))
        // </Snippet2>
        {
            WriteText(stringWriter);
            WriteText(streamWriter);
        }

        // <Snippet3>
        TextReader stringReader = 
            new StringReader(stringWriter.ToString());
        using(TextReader streamReader = 
            new StreamReader("InvalidPathChars.txt"))
        // </Snippet3>
        {
            ReadText(stringReader);
            ReadText(streamReader);
        }
    }

    // <Snippet4>
    static void WriteText(TextWriter textWriter)
    {
        textWriter.Write("Invalid file path characters are: ");
        textWriter.Write(Path.InvalidPathChars);
        textWriter.Write('.');
    }
    // </Snippet4>

    // <Snippet5>
    static void ReadText(TextReader textReader)
    {
        Console.WriteLine("From {0} - {1}", 
            textReader.GetType().Name, textReader.ReadToEnd());
    }
    // </Snippet5>
}
// </Snippet1>