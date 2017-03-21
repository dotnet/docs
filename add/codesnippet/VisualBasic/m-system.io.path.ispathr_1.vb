        Dim fileName As String = "C:\mydir\myfile.ext"
        Dim UncPath As String = "\\myPc\mydir\myfile"
        Dim relativePath As String = "mydir\sudir\"
        Dim result As Boolean

        result = Path.IsPathRooted(fileName)
        Console.WriteLine("IsPathRooted('{0}') returns {1}", fileName, result)

        result = Path.IsPathRooted(UncPath)
        Console.WriteLine("IsPathRooted('{0}') returns {1}", UncPath, result)

        result = Path.IsPathRooted(relativePath)
        Console.WriteLine("IsPathRooted('{0}') returns {1}", relativePath, result)

        ' This code produces output similar to the following:
        '
        ' IsPathRooted('C:\mydir\myfile.ext') returns True
        ' IsPathRooted('\\myPc\mydir\myfile') returns True
        ' IsPathRooted('mydir\sudir\') returns False