'<snippet1>
Imports System
Imports System.IO

Class CopyDir
    Shared Sub CopyAll(ByVal source As DirectoryInfo, ByVal target As DirectoryInfo)
        If (source.FullName.ToLower() = target.FullName.ToLower()) Then
            Return
        End If

        ' Check if the target directory exists, if not, create it.
        If Directory.Exists(target.FullName) = False Then
            Directory.CreateDirectory(target.FullName)
        End If

        ' Copy each file into it's new directory.
        For Each fi As FileInfo In source.GetFiles()
            Console.WriteLine("Copying {0}\{1}", target.FullName, fi.Name)
            fi.CopyTo(Path.Combine(target.ToString(), fi.Name), True)
        Next

        ' Copy each subdirectory using recursion.
        For Each diSourceSubDir As DirectoryInfo In source.GetDirectories()
            Dim nextTargetSubDir As DirectoryInfo = target.CreateSubdirectory(diSourceSubDir.Name)
            CopyAll(diSourceSubDir, nextTargetSubDir)
        Next
    End Sub

    Shared Sub Main()
        Dim sourceDirectory As String = "c:\\sourceDirectory"
        Dim targetDirectory As String = "c:\\targetDirectory"

        Dim diSource As DirectoryInfo = New DirectoryInfo(sourceDirectory)
        Dim diTarget As DirectoryInfo = New DirectoryInfo(targetDirectory)

        CopyAll(diSource, diTarget)
    End Sub
    ' Output will vary based on the contents of the source directory.
End Class
'</snippet1>

