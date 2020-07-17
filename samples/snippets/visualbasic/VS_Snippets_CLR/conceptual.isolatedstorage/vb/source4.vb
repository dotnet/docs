'<snippet4>
Imports System.IO.IsolatedStorage
Imports System.IO

Public Class DeletingFilesDirectories
    Public Shared Sub Main()
        ' Get a new isolated store for this user domain and assembly.
        ' Put the store into an isolatedStorageFile object.

        Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or
            IsolatedStorageScope.Domain Or IsolatedStorageScope.Assembly, Nothing, Nothing)

        Console.WriteLine("Creating Directories:")

        ' This code creates several different directories.

        isoStore.CreateDirectory("TopLevelDirectory")
        Console.WriteLine("TopLevelDirectory")
        isoStore.CreateDirectory("TopLevelDirectory/SecondLevel")
        Console.WriteLine("TopLevelDirectory/SecondLevel")

        ' This code creates two new directories, one inside the other.

        isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory")
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory")
        Console.WriteLine()

        ' This code creates a few files and places them in the directories.

        Console.WriteLine("Creating Files:")

        ' This file is placed in the root.

        Dim isoStream1 As New IsolatedStorageFileStream("InTheRoot.txt", FileMode.Create, isoStore)
        Console.WriteLine("InTheRoot.txt")

        isoStream1.Close()

        ' This file is placed in the InsideDirectory.

        Dim isoStream2 As New IsolatedStorageFileStream(
            "AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt", FileMode.Create, isoStore)
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt")
        Console.WriteLine()

        isoStream2.Close()

        Console.WriteLine("Deleting File:")

        ' This code deletes the HereIAm.txt file.
        isoStore.DeleteFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt")
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt")
        Console.WriteLine()

        Console.WriteLine("Deleting Directory:")

        ' This code deletes the InsideDirectory.

        isoStore.DeleteDirectory("AnotherTopLevelDirectory/InsideDirectory/")
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory/")
        Console.WriteLine()

    End Sub
End Class
'</snippet4>
