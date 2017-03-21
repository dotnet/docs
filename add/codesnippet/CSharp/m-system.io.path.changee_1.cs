using System;
using System.IO;

public class PathSnippets
{

    public void ChangeExtension()
    {
        string goodFileName = @"C:\mydir\myfile.com.extension";
        string badFileName = @"C:\mydir\";
        string result;

        result = Path.ChangeExtension(goodFileName, ".old");
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'",
            goodFileName, result); 

        result = Path.ChangeExtension(goodFileName, "");
        Console.WriteLine("ChangeExtension({0}, '') returns '{1}'", 
            goodFileName, result); 

        result = Path.ChangeExtension(badFileName, ".old");
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", 
            badFileName, result); 

        // This code produces output similar to the following:
        //
        // ChangeExtension(C:\mydir\myfile.com.extension, '.old') returns 'C:\mydir\myfile.com.old'
        // ChangeExtension(C:\mydir\myfile.com.extension, '') returns 'C:\mydir\myfile.com.'
        // ChangeExtension(C:\mydir\, '.old') returns 'C:\mydir\.old'