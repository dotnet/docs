//<Snippet1>
using System;
using System.IO;

class StrmRdrRead
{
public static void Main()
    {
    //Create a FileInfo instance representing an existing text file.
    FileInfo MyFile=new FileInfo(@"c:\csc.txt");
    //Instantiate a StreamReader to read from the text file.
    StreamReader sr=MyFile.OpenText();
    //Read a single character.
    int FirstChar=sr.Read();
    //Display the ASCII number of the character read in both decimal and hexadecimal format.
    Console.WriteLine("The ASCII number of the first character read is {0:D} in decimal and {1:X} in hexadecimal.",
        FirstChar, FirstChar);
    //
    sr.Close();
    }
}
//</Snippet1>    
    
