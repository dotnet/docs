// <Snippet2>
using System;
using System.IO;
using System.Text.RegularExpressions;

public class WordCount2
{
    private String filename = String.Empty;
    private int nWords = 0;
    private String pattern = @"\b\w+\b";

    public WordCount2(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("The file does not exist.");

        this.filename = filename;
        string txt = String.Empty;
        StreamReader? sr = null;
        try
        {
            sr = new StreamReader(filename);
            txt = sr.ReadToEnd();
        }
        finally
        {
            if (sr != null) sr.Dispose();
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
// </Snippet2>

public class Example
{
    public static void Main()
    {
        WordCount2 wc = new WordCount2(@"C:\users\ronpet\documents\Fr_Mike_Mass.txt");
        Console.WriteLine($"File {wc.Name} ({wc.FullName}) has {wc.Count} words");
    }
}
