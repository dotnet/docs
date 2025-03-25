using HowToFilesAndDirectories;

Console.WriteLine("Find files by extension:");
FindFilesByExtension();
Console.WriteLine();
Console.WriteLine("Group files by extension:");
GroupFilesByExtension();
Console.WriteLine();
Console.WriteLine("Query by file size:");
QueryByFileSize();
Console.WriteLine();
Console.WriteLine("Query duplicates:");
DuplicateFileQuery.Examples();
Console.WriteLine();
Console.WriteLine("Compare directory contents:");
CompareDirectoryContents.CompareDirectories();
Console.WriteLine();
Console.WriteLine("Search file contents:");
QueryTextContent();

Console.WriteLine();
Console.WriteLine("Update file content:");
UpdateFileContent();

Console.WriteLine();
Console.WriteLine("Split file into groups");
SplitFileIntoGroups();

Console.WriteLine();
Console.WriteLine("Join dissimilar files");
JoinDissimilarFiles();

Console.WriteLine();
Console.WriteLine("Sum Spreadsheet columns");
SumColumns.SumCSVColumns("scores.csv");

static void FindFilesByExtension()
{
    // <FindFilesByExtension>
    string startFolder = """C:\Program Files\dotnet\sdk""";
    // Or
    // string startFolder = "/usr/local/share/dotnet/sdk";

    DirectoryInfo dir = new DirectoryInfo(startFolder);
    var fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

    var fileQuery = from file in fileList
                    where file.Extension == ".txt"
                    orderby file.Name
                    select file;

    // Uncomment this block to see the full query
    // foreach (FileInfo fi in fileQuery)
    // {
    //    Console.WriteLine(fi.FullName);
    // }

    var newestFile = (from file in fileQuery
                      orderby file.CreationTime
                      select new { file.FullName, file.CreationTime })
                      .Last();

    Console.WriteLine($"\r\nThe newest .txt file is {newestFile.FullName}. Creation time: {newestFile.CreationTime}");
    // </FindFilesByExtension>
}

// This query will sort all the files under the specified folder
//  and subfolder into groups keyed by the file extension.
static void GroupFilesByExtension()
{
    // <GroupFilesByExtension>
    string startFolder = """C:\Program Files\dotnet\sdk""";
    // Or
    // string startFolder = "/usr/local/share/dotnet/sdk";

    int trimLength = startFolder.Length;

    DirectoryInfo dir = new DirectoryInfo(startFolder);

    var fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

    var queryGroupByExt = from file in fileList
                          group file by file.Extension.ToLower() into fileGroup
                          orderby fileGroup.Count(), fileGroup.Key
                          select fileGroup;

    // Iterate through the outer collection of groups.
    foreach (var filegroup in queryGroupByExt.Take(5))
    {
        Console.WriteLine($"Extension: {filegroup.Key}");
        var resultPage = filegroup.Take(20);

        //Execute the resultPage query
        foreach (var f in resultPage)
        {
            Console.WriteLine($"\t{f.FullName.Substring(trimLength)}");
        }
        Console.WriteLine();
    }
    // </GroupFilesByExtension>
}

static void QueryByFileSize()
{
    // <QueryByFileSize>
    string startFolder = """C:\Program Files\dotnet\sdk""";
    // Or
    // string startFolder = "/usr/local/share/dotnet/sdk";

    var fileList = Directory.GetFiles(startFolder, "*.*", SearchOption.AllDirectories);

    var fileQuery = from file in fileList
                    let fileLen = new FileInfo(file).Length
                    where fileLen > 0
                    select fileLen;

    // Cache the results to avoid multiple trips to the file system.
    long[] fileLengths = fileQuery.ToArray();

    // Return the size of the largest file
    long largestFile = fileLengths.Max();

    // Return the total number of bytes in all the files under the specified folder.
    long totalBytes = fileLengths.Sum();

    Console.WriteLine($"There are {totalBytes} bytes in {fileList.Count()} files under {startFolder}");
    Console.WriteLine($"The largest file is {largestFile} bytes.");
    // </QueryByFileSize>

    // <MoreQueriesOnFileSizes>
    // Return the FileInfo object for the largest file
    // by sorting and selecting from beginning of list
    FileInfo longestFile = (from file in fileList
                            let fileInfo = new FileInfo(file)
                            where fileInfo.Length > 0
                            orderby fileInfo.Length descending
                            select fileInfo
                            ).First();

    Console.WriteLine($"The largest file under {startFolder} is {longestFile.FullName} with a length of {longestFile.Length} bytes");

    //Return the FileInfo of the smallest file
    FileInfo smallestFile = (from file in fileList
                             let fileInfo = new FileInfo(file)
                             where fileInfo.Length > 0
                             orderby fileInfo.Length ascending
                             select fileInfo
                            ).First();

    Console.WriteLine($"The smallest file under {startFolder} is {smallestFile.FullName} with a length of {smallestFile.Length} bytes");

    //Return the FileInfos for the 10 largest files
    var queryTenLargest = (from file in fileList
                           let fileInfo = new FileInfo(file)
                           let len = fileInfo.Length
                           orderby len descending
                           select fileInfo
                          ).Take(10);

    Console.WriteLine($"The 10 largest files under {startFolder} are:");

    foreach (var v in queryTenLargest)
    {
        Console.WriteLine($"{v.FullName}: {v.Length} bytes");
    }

    // Group the files according to their size, leaving out
    // files that are less than 200000 bytes.
    var querySizeGroups = from file in fileList
                          let fileInfo = new FileInfo(file)
                          let len = fileInfo.Length
                          where len > 0
                          group fileInfo by (len / 100000) into fileGroup
                          where fileGroup.Key >= 2
                          orderby fileGroup.Key descending
                          select fileGroup;

    foreach (var filegroup in querySizeGroups)
    {
        Console.WriteLine($"{filegroup.Key}00000");
        foreach (var item in filegroup)
        {
            Console.WriteLine($"\t{item.Name}: {item.Length}");
        }
    }
    // </MoreQueriesOnFileSizes>
}

static void QueryTextContent()
{
    // <QueryTextContent>
    string startFolder = """C:\Program Files\dotnet\sdk""";
    // Or
    // string startFolder = "/usr/local/share/dotnet/sdk";

    DirectoryInfo dir = new DirectoryInfo(startFolder);

    var fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

    string searchTerm = "change";

    var queryMatchingFiles = from file in fileList
                             where file.Extension == ".txt"
                             let fileText = File.ReadAllText(file.FullName)
                             where fileText.Contains(searchTerm)
                             select file.FullName;

    // Execute the query.
    Console.WriteLine($"""The term "{searchTerm}" was found in:""");
    foreach (string filename in queryMatchingFiles)
    {
        Console.WriteLine(filename);
    }
    // </QueryTextContent>
}

static void UpdateFileContent()
{
    // <UpdateFileContent>
    string[] lines = File.ReadAllLines("spreadsheet1.csv");

    // Create the query. Put field 2 first, then
    // reverse and combine fields 0 and 1 from the old field
    IEnumerable<string> query = from line in lines
                                let fields = line.Split(',')
                                orderby fields[2]
                                select $"{fields[2]}, {fields[1]} {fields[0]}";

    File.WriteAllLines("spreadsheet2.csv", query.ToArray());

    /* Output to spreadsheet2.csv:
    111, Svetlana Omelchenko
    112, Claire O'Donnell
    113, Sven Mortensen
    114, Cesar Garcia
    115, Debra Garcia
    116, Fadi Fakhouri
    117, Hanying Feng
    118, Hugo Garcia
    119, Lance Tucker
    120, Terry Adams
    121, Eugene Zabokritski
    122, Michael Tucker
    */
    // </UpdateFileContent>
}

static void SplitFileIntoGroups()
{
    // <SplitFileIntoGroups>
    string[] fileA = File.ReadAllLines("names1.txt");
    string[] fileB = File.ReadAllLines("names2.txt");

    // Concatenate and remove duplicate names
    var mergeQuery = fileA.Union(fileB);

    // Group the names by the first letter in the last name.
    var groupQuery = from name in mergeQuery
                     let n = name.Split(',')[0]
                     group name by n[0] into g
                     orderby g.Key
                     select g;

    foreach (var g in groupQuery)
    {
        string fileName = $"testFile_{g.Key}.txt";

        Console.WriteLine(g.Key);

        using StreamWriter sw = new StreamWriter(fileName);
        foreach (var item in g)
        {
            sw.WriteLine(item);
            // Output to console for example purposes.
            Console.WriteLine($"   {item}");
        }
    }
    /* Output:
        A
           Aw, Kam Foo
        B
           Bankov, Peter
           Beebe, Ann
        E
           El Yassir, Mehdi
        G
           Garcia, Hugo
           Guy, Wey Yuan
           Garcia, Debra
           Gilchrist, Beth
           Giakoumakis, Leo
        H
           Holm, Michael
        L
           Liu, Jinghao
        M
           Myrcha, Jacek
           McLin, Nkenge
        N
           Noriega, Fabricio
        P
           Potra, Cristina
        T
           Toyoshima, Tim
     */
    // </SplitFileIntoGroups>
}

static void JoinDissimilarFiles()
{
    // <JoinDissimilarFiles>
    string[] names = File.ReadAllLines(@"names.csv");
    string[] scores = File.ReadAllLines(@"scores.csv");

    var scoreQuery = from name in names
                      let nameFields = name.Split(',')
                      from id in scores
                      let scoreFields = id.Split(',')
                      where Convert.ToInt32(nameFields[2]) == Convert.ToInt32(scoreFields[0])
                      select $"{nameFields[0]},{scoreFields[1]},{scoreFields[2]},{scoreFields[3]},{scoreFields[4]}";

    Console.WriteLine("\r\nMerge two spreadsheets:");
    foreach (string item in scoreQuery)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine($"{scoreQuery.Count()} total names in list");
    /* Output:
    Merge two spreadsheets:
    Omelchenko, 97, 92, 81, 60
    O'Donnell, 75, 84, 91, 39
    Mortensen, 88, 94, 65, 91
    Garcia, 97, 89, 85, 82
    Garcia, 35, 72, 91, 70
    Fakhouri, 99, 86, 90, 94
    Feng, 93, 92, 80, 87
    Garcia, 92, 90, 83, 78
    Tucker, 68, 79, 88, 92
    Adams, 99, 82, 81, 79
    Zabokritski, 96, 85, 91, 60
    Tucker, 94, 92, 91, 91
    12 total names in list
     */
    // </JoinDissimilarFiles>
}
