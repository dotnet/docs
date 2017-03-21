        string fileName = @"C:\mydir.old\myfile.ext";
        string path = @"C:\mydir.old\";
        string extension;

        extension = Path.GetExtension(fileName);
        Console.WriteLine("GetExtension('{0}') returns '{1}'", 
            fileName, extension);

        extension = Path.GetExtension(path);
        Console.WriteLine("GetExtension('{0}') returns '{1}'", 
            path, extension);

        // This code produces output similar to the following:
        //
        // GetExtension('C:\mydir.old\myfile.ext') returns '.ext'
        // GetExtension('C:\mydir.old\') returns ''