        string fileName = "myfile.ext";
        string path1 = @"mydir";
        string path2 = @"\mydir";
        string fullPath;

        fullPath = Path.GetFullPath(path1);
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", 
            path1, fullPath);
        
        fullPath = Path.GetFullPath(fileName);
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", 
            fileName, fullPath);

        fullPath = Path.GetFullPath(path2);
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", 
            path2, fullPath);

        // Output is based on your current directory, except
        // in the last case, where it is based on the root drive
        // GetFullPath('mydir') returns 'C:\temp\Demo\mydir'
        // GetFullPath('myfile.ext') returns 'C:\temp\Demo\myfile.ext'
        // GetFullPath('\mydir') returns 'C:\mydir'