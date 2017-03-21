        string fileName = @"C:\mydir\myfile.ext";
        string path = @"C:\mydir\";
        string result;

        result = Path.GetFileName(fileName);
        Console.WriteLine("GetFileName('{0}') returns '{1}'", 
            fileName, result);

        result = Path.GetFileName(path);
        Console.WriteLine("GetFileName('{0}') returns '{1}'", 
            path, result);

        // This code produces output similar to the following:
        //
        // GetFileName('C:\mydir\myfile.ext') returns 'myfile.ext'
        // GetFileName('C:\mydir\') returns ''