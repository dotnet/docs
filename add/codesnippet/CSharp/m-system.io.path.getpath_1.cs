        string path = @"\mydir\";
        string fileName = "myfile.ext";
        string fullPath = @"C:\mydir\myfile.ext";
        string pathRoot;

        pathRoot = Path.GetPathRoot(path);
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", 
            path, pathRoot);
        
        pathRoot = Path.GetPathRoot(fileName);
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", 
            fileName, pathRoot);

        pathRoot = Path.GetPathRoot(fullPath);
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", 
            fullPath, pathRoot);

        // This code produces output similar to the following:
        //
        // GetPathRoot('\mydir\') returns '\'
        // GetPathRoot('myfile.ext') returns ''
        // GetPathRoot('C:\mydir\myfile.ext') returns 'C:\'