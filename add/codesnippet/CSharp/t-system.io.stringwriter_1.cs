using System;
using System.IO;

class StringRW
{
    static void Main()
    {
        string textReaderText = "TextReader is the abstract base " +
            "class of StreamReader and StringReader, which read " +
            "characters from streams and strings, respectively.\n\n" +

            "Create an instance of TextReader to open a text file " +
            "for reading a specified range of characters, or to " +
            "create a reader based on an existing stream.\n\n" +

            "You can also use an instance of TextReader to read " +
            "text from a custom backing store using the same " +
            "APIs you would use for a string or a stream.\n\n";

        Console.WriteLine("Original text:\n\n{0}", textReaderText);

        // From textReaderText, create a continuous paragraph 
        // with two spaces between each sentence.
        string aLine, aParagraph = null;
        StringReader strReader = new StringReader(textReaderText);
        while(true)
        {
            aLine = strReader.ReadLine();
            if(aLine != null)
            {
                aParagraph = aParagraph + aLine + " ";
            }
            else
            {
                aParagraph = aParagraph + "\n";
                break;
            }
        }
        Console.WriteLine("Modified text:\n\n{0}", aParagraph);

        // Re-create textReaderText from aParagraph.
        int intCharacter;
        char convertedCharacter;
        StringWriter strWriter = new StringWriter();
        strReader = new StringReader(aParagraph);
        while(true)
        {
            intCharacter = strReader.Read();

            // Check for the end of the string 
            // before converting to a character.
            if(intCharacter == -1) break;

            convertedCharacter = Convert.ToChar(intCharacter);
            if(convertedCharacter == '.')
            {
                strWriter.Write(".\n\n");

                // Bypass the spaces between sentences.
                strReader.Read();
                strReader.Read();
            }
            else
            {
                strWriter.Write(convertedCharacter);
            }
        }
        Console.WriteLine("\nOriginal text:\n\n{0}", 
            strWriter.ToString());
    }
}