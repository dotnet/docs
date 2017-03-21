        Dim fileName1 As String = "myfile.ext"
        Dim fileName2 As String = "mydir\myfile"
        Dim pathname As String = "C:\mydir.ext\"
        Dim result As Boolean

        result = Path.HasExtension(fileName1)
        Console.WriteLine("HasExtension('{0}') returns {1}", fileName1, result)

        result = Path.HasExtension(fileName2)
        Console.WriteLine("HasExtension('{0}') returns {1}", fileName2, result)

        result = Path.HasExtension(pathname)
        Console.WriteLine("HasExtension('{0}') returns {1}", pathname, result)

        ' This code produces output similar to the following:
        '
        ' HasExtension('myfile.ext') returns True
        ' HasExtension('mydir\myfile') returns False
        ' HasExtension('C:\mydir.ext\') returns False