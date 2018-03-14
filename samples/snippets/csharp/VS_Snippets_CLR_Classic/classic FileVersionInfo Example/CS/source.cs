// <Snippet1>

using System;
using System.IO;
using System.Diagnostics;

class Class1
{
    public static void Main(string[] args)
    {
        // Get the file version for the notepad.
        // Use either of the two following commands.
        FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"));
        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");


        // Print the file name and version number.
        Console.WriteLine("File: " + myFileVersionInfo.FileDescription + '\n' +
           "Version number: " + myFileVersionInfo.FileVersion);
    }

}
// </Snippet1>
