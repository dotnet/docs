        string fileName = @"C:\mydir\myfile.ext";
        string path = @"C:\mydir\";
        string result;

        result = Path.GetFileNameWithoutExtension(fileName);
        Console.WriteLine("GetFileNameWithoutExtension('{0}') returns '{1}'", 
            fileName, result);

        result = Path.GetFileName(path);
        Console.WriteLine("GetFileName('{0}') returns '{1}'", 
            path, result);

        // This code produces output similar to the following:
        //
        // GetFileNameWithoutExtension('C:\mydir\myfile.ext') returns 'myfile'
        // GetFileName('C:\mydir\') returns ''