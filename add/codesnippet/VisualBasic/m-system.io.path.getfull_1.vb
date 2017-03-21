        Dim fileName As string = "myfile.ext"
        Dim path1 As string = "mydir"
        Dim path2 As string = "\mydir"
        Dim fullPath As string

        fullPath = Path.GetFullPath(path1)
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", _
            path1, fullPath)
        
        fullPath = Path.GetFullPath(fileName)
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", _
            fileName, fullPath)

        fullPath = Path.GetFullPath(path2)
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", _
            path2, fullPath)

        ' Output is based on your current directory, except
        ' in the last case, where it is based on the root drive
        ' GetFullPath('mydir') returns 'C:\temp\Demo\mydir'
        ' GetFullPath('myfile.ext') returns 'C:\temp\Demo\myfile.ext'
        ' GetFullPath('\mydir') returns 'C:\mydir'