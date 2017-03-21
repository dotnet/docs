foreach (string line in File.ReadLines(@"d:\data\episodes.txt"))
{
    if (line.Contains("episode") & line.Contains("2006"))
    {
        Console.WriteLine(line);
    }
}