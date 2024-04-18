namespace HowToFilesAndDirectories;

public class CompareDirectoryContents
{
    // <CompareDirectoryContents>
    // This implementation defines a very simple comparison
    // between two FileInfo objects. It only compares the name
    // of the files being compared and their length in bytes.
    class FileCompare : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo? f1, FileInfo? f2)
        {
            return (f1?.Name == f2?.Name &&
                    f1?.Length == f2?.Length);
        }

        // Return a hash that reflects the comparison criteria. According to the
        // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must
        // also be equal. Because equality as defined here is a simple value equality, not
        // reference identity, it is possible that two or more objects will produce the same
        // hash code.
        public int GetHashCode(FileInfo fi)
        {
            string s = $"{fi.Name}{fi.Length}";
            return s.GetHashCode();
        }
    }

    public static void CompareDirectories()
    {
        string pathA = """C:\Program Files\dotnet\sdk\8.0.104""";
        string pathB = """C:\Program Files\dotnet\sdk\8.0.204""";

        DirectoryInfo dir1 = new DirectoryInfo(pathA);
        DirectoryInfo dir2 = new DirectoryInfo(pathB);

        IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);

        //A custom file comparer defined below
        FileCompare myFileCompare = new FileCompare();

        // This query determines whether the two folders contain
        // identical file lists, based on the custom file comparer
        // that is defined in the FileCompare class.
        // The query executes immediately because it returns a bool.
        bool areIdentical = list1.SequenceEqual(list2, myFileCompare);

        if (areIdentical == true)
        {
            Console.WriteLine("the two folders are the same");
        }
        else
        {
            Console.WriteLine("The two folders are not the same");
        }

        // Find the common files. It produces a sequence and doesn't
        // execute until the foreach statement.
        var queryCommonFiles = list1.Intersect(list2, myFileCompare);

        if (queryCommonFiles.Any())
        {
            Console.WriteLine($"The following files are in both folders (total number = {queryCommonFiles.Count()}):");
            foreach (var v in queryCommonFiles.Take(10))
            {
                Console.WriteLine(v.Name); //shows which items end up in result list
            }
        }
        else
        {
            Console.WriteLine("There are no common files in the two folders.");
        }

        // Find the set difference between the two folders.
        var queryList1Only = (from file in list1
                              select file)
                              .Except(list2, myFileCompare);

        Console.WriteLine();
        Console.WriteLine($"The following files are in list1 but not list2 (total number = {queryList1Only.Count()}):");
        foreach (var v in queryList1Only.Take(10))
        {
            Console.WriteLine(v.FullName);
        }

        var queryList2Only = (from file in list2
                              select file)
                              .Except(list1, myFileCompare);

        Console.WriteLine();
        Console.WriteLine($"The following files are in list2 but not list1 (total number = {queryList2Only.Count()}:");
        foreach (var v in queryList2Only.Take(10))
        {
            Console.WriteLine(v.FullName);
        }
    }
    // </CompareDirectoryContents>
}
