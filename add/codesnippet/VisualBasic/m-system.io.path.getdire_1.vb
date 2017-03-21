        Dim filepath As String = "C:\MyDir\MySubDir\myfile.ext"
        Dim directoryName As String
        Dim i As Integer = 0

        While filepath <> Nothing
            directoryName = Path.GetDirectoryName(filepath)
            Console.WriteLine("GetDirectoryName('{0}') returns '{1}'", _
                filepath, directoryName)
            filepath = directoryName
            If i = 1
               filepath = directoryName + "\"  ' this will preserve the previous path
            End If
            i = i + 1
        End While

        'This code produces the following output:
        '
        ' GetDirectoryName('C:\MyDir\MySubDir\myfile.ext') returns 'C:\MyDir\MySubDir'
        ' GetDirectoryName('C:\MyDir\MySubDir') returns 'C:\MyDir'
        ' GetDirectoryName('C:\MyDir\') returns 'C:\MyDir'
        ' GetDirectoryName('C:\MyDir') returns 'C:\'
        ' GetDirectoryName('C:\') returns ''