        Dim fileName As String = "C:\mydir.old\myfile.ext"
        Dim pathname As String = "C:\mydir.old\"
        Dim extension As String

        extension = Path.GetExtension(fileName)
        Console.WriteLine("GetExtension('{0}') returns '{1}'", fileName, extension)

        extension = Path.GetExtension(pathname)
        Console.WriteLine("GetExtension('{0}') returns '{1}'", pathname, extension)

        ' This code produces output similar to the following:
        '
        ' GetExtension('C:\mydir.old\myfile.ext') returns '.ext'
        ' GetExtension('C:\mydir.old\') returns ''