Imports System.IO
Module Module1

    Sub Main()

        ' <Snippet1>
        Dim dirPrograms As New DirectoryInfo("c:\program files")
        Dim StartOf2009 As New DateTime(2009, 1, 1)

        Dim dirs = From dir In dirPrograms.EnumerateDirectories()
                    Where dir.CreationTimeUtc < StartOf2009

        For Each di As DirectoryInfo In dirs
            Console.WriteLine("{0}", di.Name)
        Next
        ' </Snippet1>

    End Sub

End Module
