namespace HowToFilesAndDirectories;
public static class DuplicateFileQuery
{
    public static void Examples()
    {
        Console.WriteLine("Query duplicates:");
        QueryDuplicateNames();

        Console.WriteLine();
        Console.WriteLine("Query duplicates 2:");
        QueryDuplicateFileInfo();
    }

    static void QueryDuplicateNames()
    {
        // <QueryDuplicateNames>
        string startFolder = """C:\Program Files\dotnet\sdk""";
        // Or
        // string startFolder = "/usr/local/share/dotnet/sdk";

        DirectoryInfo dir = new DirectoryInfo(startFolder);

        IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

        // used in WriteLine to keep the lines shorter
        int charsToSkip = startFolder.Length;

        // var can be used for convenience with groups.
        var queryDupNames = from file in fileList
                            group file.FullName.Substring(charsToSkip) by file.Name into fileGroup
                            where fileGroup.Count() > 1
                            select fileGroup;

        foreach (var queryDup in queryDupNames.Take(20))
        {
            Console.WriteLine($"Filename = {(queryDup.Key.ToString() == string.Empty ? "[none]" : queryDup.Key.ToString())}");

            foreach (var fileName in queryDup.Take(10))
            {
                Console.WriteLine($"\t{fileName}");
            }   
        }
        // </QueryDuplicateNames>
    }

    static void QueryDuplicateFileInfo()
    {
        // <QueryDuplicateFileInfo>
        string startFolder = """C:\Program Files\dotnet\sdk""";
        // Or
        // string startFolder = "/usr/local/share/dotnet/sdk";

        // Make the lines shorter for the console display
        int charsToSkip = startFolder.Length;

        // Take a snapshot of the file system.
        DirectoryInfo dir = new DirectoryInfo(startFolder);
        IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

        // Note the use of a compound key. Files that match
        // all three properties belong to the same group.
        // A named type is used to enable the query to be
        // passed to another method. Anonymous types can also be used
        // for composite keys but cannot be passed across method boundaries
        //
        var queryDupFiles = from file in fileList
                            group file.FullName.Substring(charsToSkip) by
                            (Name: file.Name, LastWriteTime: file.LastWriteTime, Length: file.Length )
                            into fileGroup
                            where fileGroup.Count() > 1
                            select fileGroup;

        foreach (var queryDup in queryDupFiles.Take(20))
        {
            Console.WriteLine($"Filename = {(queryDup.Key.ToString() == string.Empty ? "[none]" : queryDup.Key.ToString())}");

            foreach (var fileName in queryDup)
            {
                Console.WriteLine($"\t{fileName}");
            }
        }
    }
    // </QueryDuplicateFileInfo>
}
