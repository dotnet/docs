// <Snippet1>
using System;
using System.IO;
using System.Text.RegularExpressions;

public class WordCount
{
    private String filename = String.Empty;
    private int nWords = 0;
    private String pattern = @"\b\w+\b";

    public WordCount(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("The file does not exist.");

        this.filename = filename;
        string txt = String.Empty;
        using (StreamReader sr = new StreamReader(filename))
        {
            txt = sr.ReadToEnd();
        }
        nWords = Regex.Matches(txt, pattern).Count;
    }

    public string FullName
    { get { return filename; } }

    public string Name
    { get { return Path.GetFileName(filename); } }

    public int Count
    { get { return nWords; } }
}
// </Snippet1>

public class Example8
{
    public static void Main()
    {
        WordCount wc = new WordCount(@"C:\users\ronpet\documents\Fr_Mike_Mass.txt");
        Console.WriteLine($"File {wc.Name} ({wc.FullName}) has {wc.Count} words");
    }
}
