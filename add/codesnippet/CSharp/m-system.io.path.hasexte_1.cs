        string fileName1 = "myfile.ext";
        string fileName2 = @"mydir\myfile";
        string path = @"C:\mydir.ext\";
        bool result;

        result = Path.HasExtension(fileName1);
        Console.WriteLine("HasExtension('{0}') returns {1}", 
            fileName1, result);

        result = Path.HasExtension(fileName2);
        Console.WriteLine("HasExtension('{0}') returns {1}", 
            fileName2, result);
        
        result = Path.HasExtension(path);
        Console.WriteLine("HasExtension('{0}') returns {1}", 
            path, result);

        // This code produces output similar to the following:
        //
        // HasExtension('myfile.ext') returns True
        // HasExtension('mydir\myfile') returns False
        // HasExtension('C:\mydir.ext\') returns False