'<Snippet1>
Imports System.IO
Class Program

    Shared Sub Main()

        ' Get the directories currently on the C drive.
        Dim cDirs As DirectoryInfo() = New DirectoryInfo("c:\").GetDirectories()

        ' Write each directory name to a file.
        Using sw As StreamWriter = New StreamWriter("CDriveDirs.txt")
            For Each Dir As DirectoryInfo In cDirs
                sw.WriteLine(Dir.Name)
            Next
        End Using

        'Read and show each line from the file.
        Dim line As String = ""
        Using sr As StreamReader = New StreamReader("CDriveDirs.txt")
            Do
                line = sr.ReadLine()
                Console.WriteLine(line)
            Loop Until line Is Nothing
        End Using


    End Sub

End Class
'</Snippet1>
