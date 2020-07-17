// <Snippet2>
using System.IO;
using System.Text.RegularExpressions;

public class WordCount
{
    const string Pattern = @"\b\w+\b";

    public WordCount(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("The file does not exist.");
        }

        FullName = filename;

        var txt = string.Empty;
        StreamReader streamReader = null;
        try
        {
            streamReader = new StreamReader(filename);
            txt = streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
        }

        Count = Regex.Matches(txt, Pattern).Count;
    }

    public string FullName { get; }
    public string Name => Path.GetFileName(FullName);
    public int Count { get; }
}
// </Snippet2>

public class Example
{
   public static void Main()
   {
      WordCount wc = new WordCount(@"C:\users\ronpet\documents\Fr_Mike_Mass.txt");
      Console.WriteLine("File {0} ({1}) has {2} words",
                        wc.Name, wc.FullName, wc.Count);
   }
}
