'<snippet9>
Imports System
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Collections
Imports System.Collections.Generic

Public class FindingExistingFilesAndDirectories
    ' These arrayLists hold the directory and file names as they are found.

    Private Shared directoryList As New List(Of String)
    Private Shared fileList As New List(Of String)

    ' Retrieves an array of all directories in the store, and
    ' displays the results.

    Public Shared Sub Main()
        ' This part of the code sets up a few directories and files in the store.
        Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
            IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
        isoStore.CreateDirectory("TopLevelDirectory")
        isoStore.CreateDirectory("TopLevelDirectory/SecondLevel")
        isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory")
        isoStore.CreateFile("InTheRoot.txt")
        isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt")
        ' End of setup.

        Console.WriteLine()
        Console.WriteLine("Here is a list of all directories in this isolated store:")

        GetAllDirectories("*", isoStore)
        For Each directory As String In directoryList
           Console.WriteLine(directory)
        Next

        Console.WriteLine()
        Console.WriteLine("Retrieve all the files in the directory by calling the GetFiles method.")

        GetAllFiles(isoStore)
        For Each file As String In fileList
            Console.WriteLine(file)
        Next
    End Sub

    Public Shared Sub GetAllDirectories(ByVal pattern As String, ByVal storeFile As IsolatedStorageFile)
        ' Retrieve directories.
        Dim directories As String() = storeFile.GetDirectoryNames(pattern)

        For Each directory As String In directories
            ' Add the directory to the final list.
            directoryList.Add((pattern.TrimEnd(CChar("*"))) + directory + "/")
            ' Call the method again using directory.
            GetAllDirectories((pattern.TrimEnd(CChar("*")) + directory + "/*"), storeFile)
        Next
    End Sub

    Public Shared Sub GetAllFiles(ByVal storefile As IsolatedStorageFile)
        ' This adds the root to the directory list.
        directoryList.Add("*")
        For Each directory As String In directoryList
            Dim files As String() = storefile.GetFileNames(directory + "*")
            For Each dirfile As String In files
                fileList.Add(dirfile)
            Next
        Next
    End Sub
End Class
'</snippet9>
