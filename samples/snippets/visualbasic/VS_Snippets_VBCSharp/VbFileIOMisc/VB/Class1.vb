Option Strict On


Class Class1478b6263a0c4cf388d6c34166493594
    ' HowtoMoveACollectionOfFilesInVisualBasic

    Public Sub Method2()
        ' <snippet2>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

            Dim foundFileInfo As New System.IO.FileInfo(foundFile)
            My.Computer.FileSystem.MoveFile(foundFile, "C:\StorageDir\" & foundFileInfo.Name)
        Next
        ' </snippet2>
    End Sub

End Class

Class Class1a05512e97c342248649a1c013e59ff0
    ' HowtoDetermineAFilesLastAccessedTimeInVisualBasic

    Public Sub Method3()
        ' <snippet3>
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
        MsgBox("File was last accessed on " & infoReader.LastAccessTime)
        ' </snippet3>
    End Sub

End Class

Class Class25e3b71db84442939e4ef06c5836b5cc
    ' HowtoFindFilesWithASpecificPatternInVisualBasic

    Public Sub Method4()
        Dim Listbox1 As New System.Windows.Forms.ListBox
        ' <snippet4>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.dll")

            Listbox1.Items.Add(foundFile)
        Next
        ' </snippet4>
    End Sub

End Class

Class Class331dac55d3fa4b5094571557db00e297
    ' HowtoMoveTheContentsOfADirectoryInVisualBasic

    Public Sub Method5()
        ' <snippet5>
        Dim fileList = My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyPictures,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

        For Each foundFile In fileList
            My.Computer.FileSystem.MoveFile(foundFile,
                "C:\StorageDir\" & My.Computer.FileSystem.GetFileInfo(foundFile).Name)
        Next
        ' </snippet5>
    End Sub

End Class

Class Class38c3c7d2849d4ba08209132d19636668
    ' HowtoDetermineADirectorysCreationTimeInVisualBasic

    Public Sub Method6()
        ' <snippet6>
        Dim getInfo = My.Computer.FileSystem.GetDirectoryInfo(
                        "C:\Documents and Settings")
        MsgBox("The directory was created at " & getInfo.CreationTime)
        ' </snippet6>
    End Sub

End Class

Class Class39a4caa4e5254b58884653149e21fe7e
    ' HowtoDetermineADrivesFormatInVisualBasic

    Public Sub Method7()
        ' <snippet7>
        Dim cdrive As System.IO.DriveInfo
        cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox(cdrive.DriveFormat)
        ' </snippet7>
    End Sub

End Class

Class Class4739348a86364eabb6ed827b95e77789
    ' HowtoDetermineTheWindowsSystemDirectoryInVisualBasic

    Public Sub Method8()
        ' <snippet8>
        Dim systemDirectory As String
        systemDirectory = System.Environment.SystemDirectory
        ' </snippet8>
    End Sub

End Class

Class Class4b7217693e454be7b7feb08dc4141b44
    ' HowtoDeleteAFileInVisualBasic

    Public Sub Method9()
        ' <snippet9>
        My.Computer.FileSystem.DeleteFile("C:\test.txt",
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
                Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ' </snippet9>
    End Sub

    Public Sub Method10()
        ' <snippet10>
        My.Computer.FileSystem.DeleteFile("C:\test.txt",
        Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin)
        ' </snippet10>
    End Sub

End Class

Class Class4c6769dfe9b94b69bfdfce4cfbda30ff
    ' HowtoDetermineTheAbsolutePathOfAFileInVisualBasic

    Public Sub Method11()
        ' <snippet11>
        Dim getInfo As System.IO.FileInfo
        getInfo = My.Computer.FileSystem.GetFileInfo("C:\TestFolder1\test.txt")
        MsgBox(getInfo.FullName)
        ' </snippet11>
    End Sub

End Class

Class Class5199d1fcbf5d418b94870700e54d1dae



    ' HowtoDetermineIfADirectoryExistsInVisualBasic

    Public Sub Method12()

        ' <snippet12>
        Dim logDirectoryProperties As System.IO.DirectoryInfo
        If My.Computer.FileSystem.DirectoryExists("C:\backup\logs") Then
            logDirectoryProperties = My.Computer.FileSystem.GetDirectoryInfo("C:\backup\logs")
        End If
        ' </snippet12>
    End Sub

    ' HowtoDetermineIfADirectoryExistsInVisualBasic

    Public Sub Method13()
        ' <snippet13>
        Dim logDirectoryProperties As System.IO.DirectoryInfo
        If My.Computer.FileSystem.DirectoryExists("C:\backup\logs") Then
            logDirectoryProperties = My.Computer.FileSystem.GetDirectoryInfo("C:\backup\logs")
        End If
        ' </snippet13>
    End Sub

End Class

Class Class5382a4d6ee154d7bb31ed16a3c69e8d3
    ' HowtoDetermineADirectorysAttributesInVisualBasic

    Public Sub Method14()
        ' <snippet14>
        Dim checkFile As System.IO.DirectoryInfo
        checkFile = My.Computer.FileSystem.GetDirectoryInfo("C:\TestDir")
        Dim attributeReader As System.IO.FileAttributes
        attributeReader = checkFile.Attributes

        If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
            MsgBox("Directory is hidden")
        End If
        ' </snippet14>
    End Sub

End Class

Class Class541da1b7b50c4e0d8bdcc5ac5515c0ea
    ' HowtoDetermineADrivesTypeInVisualBasic

    Public Sub Method15()
        ' <snippet15>
        Dim cdrive As System.IO.DriveInfo
        cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox(cdrive.DriveType.ToString)
        ' </snippet15>
    End Sub

End Class

Class Class64cc984b9b7e4617aa6d01a74f08f331
    ' HowtoDetermineIfAFileIsHiddenInVisualBasic

    Public Sub Method16()
        If My.Computer.FileSystem.FileExists("C:\testfile.txt") Then
            ' <snippet16>
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
            ' </snippet16>
        End If
    End Sub

    Public Sub Method17()
        If My.Computer.FileSystem.FileExists("C:\testfile.txt") Then
            Dim inforeader As New System.IO.FileInfo("C:\testfile.txt")
            inforeader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
            ' <snippet17>
            Dim attributeReader As System.IO.FileAttributes
            attributeReader = infoReader.Attributes
            ' </snippet17>

            ' <snippet18>
            If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                MsgBox("File is hidden!")
            Else
                MsgBox("File is not hidden!")
            End If
            ' </snippet18>
        End If
    End Sub

End Class

Class Class717c90ba55d1454cac9ed034eae95c1e
    ' HowtoDetermineAFilesExtensionInVisualBasic

    Public Sub Method19()
        ' <snippet19>
        For Each foundFile As String In
        My.Computer.FileSystem.GetFiles("C:\TestDir")
            Dim check As String =
            System.IO.Path.GetExtension(foundFile)
            MsgBox("The file extension is " & check)
        Next
        ' </snippet19>
    End Sub

End Class

Class Class7d0622cbc48f416386557e50cdd379a4
    ' HowtoDetermineIfADirectoryIsRead-OnlyInVisualBasic

    Public Sub Method20()
        ' <snippet20>
        Dim reader As System.IO.DirectoryInfo
        reader = My.Computer.FileSystem.GetDirectoryInfo("C:\testDirectory")
        ' </snippet20>

        ' <snippet21>
        If (reader.Attributes And System.IO.FileAttributes.ReadOnly) > 0 Then
            MsgBox("Directory is readonly!")
        End If
        ' </snippet21>
    End Sub

    Public Sub Method22()
        ' <snippet22>
        Dim reader As System.IO.DirectoryInfo
        reader = My.Computer.FileSystem.GetDirectoryInfo("C:\testDirectory")
        If (reader.Attributes And System.IO.FileAttributes.ReadOnly) > 0 Then
            MsgBox("File is readonly!")
        End If
        ' </snippet22>
    End Sub

End Class

Class Class7f031720901e4b66992848a2ea9fe925
    ' HowtoDetermineADrivesVolumeLabelInVisualBasic

    Public Sub Method23()
        ' <snippet23>
        Dim cdrive As System.IO.DriveInfo
        cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox(cdrive.VolumeLabel)
        ' </snippet23>
    End Sub

End Class

Class Class88e2145cd41445a5ad036f5d58ecca26
    ' HowtoCreateACopyOfAFileInaDifferentDirectoryInVisualBasic

    Public Sub Method24()
        ' <snippet24>
        ' Copy the file to a new location without overwriting existing file.
        My.Computer.FileSystem.CopyFile(
            "C:\UserFiles\TestFiles\testFile.txt",
            "C:\UserFiles\TestFiles2\testFile.txt")

        ' Copy the file to a new folder, overwriting existing file.
        My.Computer.FileSystem.CopyFile(
            "C:\UserFiles\TestFiles\testFile.txt",
            "C:\UserFiles\TestFiles2\testFile.txt",
            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

        ' Copy the file to a new folder and rename it.
        My.Computer.FileSystem.CopyFile(
            "C:\UserFiles\TestFiles\testFile.txt",
            "C:\UserFiles\TestFiles2\NewFile.txt",
            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ' </snippet24>
    End Sub

End Class

Class Class8b1a9d47e9cb4338896a5a5b1b33bf6d
    ' HowtoDetermineAFilesAttributesInVisualBasic

    Public Sub Method25()
        ' <snippet25>
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
        ' </snippet25>

        ' <snippet26>
        Dim attributeReader As System.IO.FileAttributes
        attributeReader = infoReader.Attributes
        ' </snippet26>

        ' <snippet27>
        If (attributeReader And System.IO.FileAttributes.Encrypted) > 0 Then
            MsgBox("File is encrypted!")
        Else
            MsgBox("File is not encrypted!")
        End If
        ' </snippet27>
    End Sub

End Class

Class Class938e938f401e428aae1ea9210fea9085
    ' HowtoDetermineIfAFileExistsInVisualBasic

    Public Sub Method28()
        ' <snippet28>
        If My.Computer.FileSystem.FileExists("c://Check.txt") Then
            MsgBox("File found.")
        Else
            MsgBox("File not found.")
        End If
        ' </snippet28>
    End Sub

End Class

Class Classb78c9a1c6cbe4c1db8a9d600bb357070
    ' HowtoDetermineADrivesRootDirectoryInVisualBasic

    Public Sub Method29()
        ' <snippet29>
        Dim cdrive As System.IO.DriveInfo
        cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox(cdrive.RootDirectory)
        ' </snippet29>
    End Sub

End Class

Class Classca0720ecf40e4c1197480ce1685c78f0
    ' HowtoGetInformationAboutAFileInVisualBasic

    Public Sub Method30()
        ' <snippet30>
        Dim information As System.IO.FileInfo
        information = My.Computer.FileSystem.GetFileInfo("C:\MyLogFile.log")
        ' </snippet30>

        ' <snippet31>
        MsgBox("The file's full name is " & information.FullName & ".")
        MsgBox("Last access time is " & information.LastAccessTime & ".")
        MsgBox("The length is " & information.Length & ".")
        ' </snippet31>
    End Sub

End Class

Class Classccdc06ca624f4d38bbff8764f6e56c24
    ' HowtoDetermineAFilesLastModifiedTimeInVisualBasic

    Public Sub Method32()
        ' <snippet32>
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
        MsgBox("File was last modified on " & infoReader.LastWriteTime)
        ' </snippet32>
    End Sub

End Class

Class Classdb5e06eb388a451884663cbaa40a4dc0
    ' HowtoDetermineAFilesSizeInVisualBasic

    Public Sub Method33()
        ' <snippet33>
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
        MsgBox("File is " & infoReader.Length & " bytes.")
        ' </snippet33>
    End Sub

End Class

Class Classe1e12534a14b4f6cb24f8a7f097e1cfe
    ' HowtoDetermineAFilesCreationTimeInVisualBasic

    Public Sub Method34()
        ' <snippet34>
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
        MsgBox("File was created on " & infoReader.CreationTime)
        ' </snippet34>
    End Sub

End Class

Class Classedd47f08a88a441daeb82857be1af94a
    ' HowtoDetermineADrivesTotalSpaceInVisualBasic

    Public Sub Method35()
        ' <snippet35>
        Dim cdrive As System.IO.DriveInfo
        cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox(cdrive.TotalSize)
        ' </snippet35>
    End Sub

End Class

Class Classf205d2adbbe54d558a40acda21aa82dd
    ' HowtoCopyFilesWithASpecificPatternToADirectoryInVisualBasic

    Public Sub Method36()
        ' <snippet36>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.rtf")
            ' </snippet36>
        Next
    End Sub

    Public Sub Method37()
        ' <snippet37>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.rtf")

            My.Computer.FileSystem.CopyFile(foundFile, "C:\testdirectory\" & foundFile)
        Next
        ' </snippet37>
    End Sub

End Class

Class Classfb3fb1d6824a4d6dab631566ed479fdc
    ' HowtoDeleteAllFilesInADirectoryInVisualBasic

    Public Sub Method38()
        ' <snippet38>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

            My.Computer.FileSystem.DeleteFile(foundFile,
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
        Next
        ' </snippet38>
    End Sub

End Class

Class Classff3411ed1b8d4676b85b40ce5edf96d8
    ' HowtoDetermineIfAFileIsRead-OnlyInVisualBasic

    Public Sub Method39()
        ' <snippet39>
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\testfile.txt")
        If infoReader.IsReadOnly = True Then
            MsgBox("File is readonly!")
        End If
        ' </snippet39>
    End Sub

End Class


