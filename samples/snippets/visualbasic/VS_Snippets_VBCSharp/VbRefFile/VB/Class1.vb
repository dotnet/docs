Class Class0c0a56cae3d043359738b40e3c422810
    ' My.Computer.FileSystem.GetFileInfoMethod

    Public Sub Method1()
        ' <snippet1>
        Dim information = My.Computer.FileSystem.GetFileInfo("C:\MyLogFile.log")
        MsgBox("The file's full name is " & information.FullName & ".")
        MsgBox("Last access time is " & information.LastAccessTime & ".")
        MsgBox("The length is " & information.Length & ".")
        ' </snippet1>
    End Sub

End Class

Class Class0f859233069a4da3ab1cb5484e39a86e
    ' My.Computer.FileSystem.OpenTextFileReaderMethod

    Public Sub Method2()
        ' <snippet2>
        Dim fileReader =
          My.Computer.FileSystem.OpenTextFileReader("C:\testfile.txt")
        Dim stringReader = fileReader.ReadLine()
        MsgBox("The first line of the file is " & stringReader)
        ' </snippet2>
    End Sub

End Class

Class Class1ac8df99f1e34584814b26b451058eb6
    ' My.Computer.FileSystem.CombinePathMethod

    Public Sub Method3()
        ' <snippet3>
        Dim fullPath = My.Computer.FileSystem.CombinePath(
            "C:\Documents and Settings\All Users\Documents\My Pictures", "picture.jpg")
        ' </snippet3>
    End Sub

    Public Sub Method4()
        ' <snippet4>
        Dim fullPath = My.Computer.FileSystem.CombinePath(
            "C:\Dir1\Dir2\Dir3", "..\Dir4\Dir5\File.txt")
        ' </snippet4>
    End Sub

End Class

Class Class1ed1854afc1a44d793bc5093540bb232
    ' My.Computer.FileSystem.GetFilesMethod

    Public Sub Method5()
        Dim Listbox1 As New System.Windows.Forms.ListBox
        ' <snippet5>
        For Each foundFile In My.Computer.FileSystem.GetFiles(
                My.Computer.FileSystem.SpecialDirectories.MyDocuments)
            ListBox1.Items.Add(foundFile)
        Next
        ' </snippet5>
    End Sub

    Public Sub Method6()
        Dim Listbox1 As New System.Windows.Forms.ListBox
        ' <snippet6>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                 My.Computer.FileSystem.SpecialDirectories.MyDocuments,
                 FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
            ListBox1.Items.Add(foundFile)
        Next
        ' </snippet6>
    End Sub

End Class

Class Class24b3bb6519d641b4b5c5532ac1fdb4f4
    ' My.Computer.FileSystem.GetDirectoryInfoMethod

    Public Sub Method7()
        ' <snippet7>
        Dim getInfo = My.Computer.FileSystem.GetDirectoryInfo(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        MsgBox("The directory was created at " & getInfo.CreationTime)
        MsgBox("The directory was last accessed at " & getInfo.LastAccessTime)
        MsgBox("The directory was last written to at " & getInfo.LastWriteTime)
        ' </snippet7>
    End Sub

End Class

Class Class3a7ac8befb1d4087bc65167d6754d57f
    ' My.Computer.FileSystem.ReadAllTextMethod

    Public Sub Method8()
        ' <snippet8>
        Dim reader = My.Computer.FileSystem.ReadAllText("C:\test.txt")
        MsgBox(reader)
        ' </snippet8>
    End Sub

    Public Sub Method9()
        ' <snippet9>
        Dim reader = My.Computer.FileSystem.ReadAllText("C:\test.txt",
           System.Text.Encoding.ASCII)
        MsgBox(reader)
        ' </snippet9>
    End Sub

End Class

Class Class5d54ae034c13486893ba388ab6fe8818
    ' My.Computer.FileSystem.GetDirectoriesMethod

    Public Sub Method10()
        Dim Listbox1 As New System.Windows.Forms.ListBox
        ' <snippet10>
        For Each foundDirectory In My.Computer.FileSystem.GetDirectories(
              My.Computer.FileSystem.SpecialDirectories.MyDocuments,
              True, "*Logs*")

            ListBox1.Items.Add(foundDirectory)
        Next
        ' </snippet10>
    End Sub

End Class

Class Class72ea443a6ff04e779d5adc9d58d7d8f9
    ' My.Computer.FileSystem.GetDriveInfoMethod

    Public Sub Method11()
        ' <snippet11>
        Dim getInfo = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox("The drive's type is " & getInfo.DriveType)
        MsgBox("The drive has " & getInfo.TotalFreeSpace & " bytes free.")
        ' </snippet11>
    End Sub

End Class

Class Class7d3959fab6e247e7929e43c45c5f770b
    ' My.Computer.FileSystem.FindInFilesMethod

    Public Sub Method12()
        Dim Listbox1 As New System.Windows.Forms.ListBox
        ' <snippet12>
        Dim list As System.Collections.ObjectModel.
          ReadOnlyCollection(Of String)
        list = My.Computer.FileSystem.FindInFiles("C:\TestDir", 
         "sample string", True, FileIO.SearchOption.SearchTopLevelOnly)
        For Each name In list
            ListBox1.Items.Add(name)
        Next
        ' </snippet12>
    End Sub

End Class

Class Class7ea4bbb509384dcfa48a4588fd9c74b8
    ' My.Computer.FileSystem.DirectoryExistsMethod

    Public Sub Method13()
        ' <snippet13>
        If My.Computer.FileSystem.DirectoryExists("C:\backup\logs") Then
            Dim logInfo = My.Computer.FileSystem.GetDirectoryInfo(
                "C:\backup\logs")
        End If
        ' </snippet13>
    End Sub

End Class

Class Class9506c210fdf24d57b1baa7e49250cffb
    ' My.Computer.FileSystem.OpenTextFileWriterMethod

    Public Sub Method14()
        ' <snippet14>
        Dim file = My.Computer.FileSystem.OpenTextFileWriter(
            "c:\test.txt", True)
        file.WriteLine("Here is the first string.")
        file.Close()
        ' </snippet14>
    End Sub

End Class

Class Classa37285367ad842798a07dd4776d3b33c
    ' My.Computer.FileSystem.CopyFileMethod

    Public Sub Method15()
        ' <snippet15>
        My.Computer.FileSystem.CopyFile( _
            "C:\UserFiles\TestFiles\test.txt", _
            "C:\UserFiles\TestFiles2\test.txt", overwrite:=False)
        ' </snippet15>
    End Sub

    Public Sub Method16()
        ' <snippet16>
        My.Computer.FileSystem.CopyFile( _
            "C:\UserFiles\TestFiles\test.txt", _
            "C:\UserFiles\TestFiles2\NewFile.txt", _
            FileIO.UIOption.OnlyErrorDialogs, _
            FileIO.UICancelOption.DoNothing)
        ' </snippet16>
    End Sub

End Class

Class Classc15d0371d0444d8daa70d6414667227c
    ' My.Computer.FileSystem.GetParentPathMethod

    Public Sub Method17()
        ' <snippet17>
        Dim strPath = My.Computer.FileSystem.GetParentPath("C:\backups\tmp\test")
        MsgBox(strPath)
        ' </snippet17>
    End Sub

End Class

Class Classe5869f85c078485f83238dc716494546
    ' My.Computer.FileSystem.OpenTextFieldParserMethod

    Public Sub Method18()
        ' <snippet18>
        Dim reader = My.Computer.FileSystem.OpenTextFieldParser(
            "C:\TestFolder1\test1.txt")
        reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        reader.delimiters = {","}
        Dim currentRow As String()
        While Not reader.EndOfData
            Try
                currentRow = reader.ReadFields()
                Dim currentField As String
                For Each currentField In currentRow
                    MsgBox(currentField)
                Next
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While
        ' </snippet18>
    End Sub

End Class

Class Classe5873f47f6474f8586d5343eb59d269c
    ' My.Computer.FileSystem.DrivesProperty

    Public Sub Method19()
        ' <snippet19>
        Dim getInfo = System.IO.DriveInfo.GetDrives()
        For Each info In getInfo
            MsgBox(info.name)
        Next
        ' </snippet19>
    End Sub

End Class

Class Classe8dc824e29634d6b8deffa34d4c46773
    ' My.Computer.FileSystem.FileExistsMethod

    Public Sub Method20()
        ' <snippet20>
        If My.Computer.FileSystem.FileExists("c:\Check.txt") Then
            MsgBox("File found.")
        Else
            MsgBox("File not found.")
        End If
        ' </snippet20>
    End Sub

End Class

Class Classf507460c87d94504b74f3ff825c7d5c4
    ' My.Computer.FileSystem.WriteAllTextMethod

    Public Sub Method21()
        ' <snippet21>
        My.Computer.FileSystem.WriteAllText("C:\TestFolder1\test.txt",
        "This is new text to be added.", False)
        ' </snippet21>
    End Sub

    Public Sub Method22()
        ' <snippet22>
        For Each foundFile In
                My.Computer.FileSystem.GetFiles("C:\Documents and Settings")
            foundFile = foundFile & vbCrLf
            My.Computer.FileSystem.WriteAllText(
                "C:\Documents and Settings\FileList.txt", foundFile, True)
        Next
        ' </snippet22>
    End Sub

End Class


