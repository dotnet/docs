'<snippet00>
Imports System
Imports System.IO

Class App
    Public Shared Sub Main()
        ' Specify the directory you want to manipulate.
        Dim path As String = "c:\\"
        Dim searchPattern As String = "c*"

        Dim di As DirectoryInfo = New DirectoryInfo(path)
        Dim directories() As DirectoryInfo = _
            di.GetDirectories(searchPattern, SearchOption.TopDirectoryOnly)

        Dim files() As FileInfo = _
            di.GetFiles(searchPattern, SearchOption.TopDirectoryOnly)

        Console.WriteLine( _
            "Directories that begin with the letter 'c' in {0}", path)
        Dim dir As DirectoryInfo
        For Each dir In directories
            Console.WriteLine( _
                "{0,-25} {1,25}", dir.FullName, dir.LastWriteTime)
        Next dir

        Console.WriteLine()
        Console.WriteLine( _
            "Files that begin with the letter 'c' in {0}", path)
        Dim file As FileInfo
        For Each file In files
            Console.WriteLine( _
                "{0,-25} {1,25}", file.Name, file.LastWriteTime)
        Next file
    End Sub
End Class
'</snippet00>