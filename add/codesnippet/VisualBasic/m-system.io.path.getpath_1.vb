        Dim pathname As String = "\mydir\"
        Dim fileName As String = "myfile.ext"
        Dim fullPath As String = "C:\mydir\myfile.ext"
        Dim pathnameRoot As String

        pathnameRoot = Path.GetPathRoot(pathname)
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", pathname, pathnameRoot)

        pathnameRoot = Path.GetPathRoot(fileName)
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", fileName, pathnameRoot)

        pathnameRoot = Path.GetPathRoot(fullPath)
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", fullPath, pathnameRoot)

        ' This code produces output similar to the following:
        '
        ' GetPathRoot('\mydir\') returns '\'
        ' GetPathRoot('myfile.ext') returns ''
        ' GetPathRoot('C:\mydir\myfile.ext') returns 'C:\'