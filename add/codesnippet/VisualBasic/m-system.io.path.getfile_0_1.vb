        Dim fileName As String = "C:\mydir\myfile.ext"
        Dim pathname As String = "C:\mydir\"
        Dim result As String

        result = Path.GetFileNameWithoutExtension(fileName)
        Console.WriteLine("GetFileNameWithoutExtension('{0}') returns '{1}'", fileName, result)

        result = Path.GetFileName(pathname)
        Console.WriteLine("GetFileName('{0}') returns '{1}'", pathname, result)

        ' This code produces output similar to the following:
        '
        ' GetFileNameWithoutExtension('C:\mydir\myfile.ext') returns 'myfile'
        ' GetFileName('C:\mydir\') returns ''