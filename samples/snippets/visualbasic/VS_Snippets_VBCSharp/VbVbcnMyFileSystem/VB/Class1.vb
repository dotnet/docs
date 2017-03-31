
Option Explicit On
Option Strict On

' <snippet35>
Imports System
Imports System.IO
' </snippet35>

Imports System.Drawing
Imports System.Windows.Forms

Class Class00ad6fbd924e4a49af32d505fe69ea32
    ' 00ad6fbd-924e-4a49-af32-d505fe69ea32
    ' My.Computer.FileSystem.RenameFile Method

    Public Sub Method1()
        ' <snippet1>
        My.Computer.FileSystem.RenameFile("C:\Test.txt", "SecondTest.txt")
        ' </snippet1>
    End Sub

End Class

Class Class0351a2ca24d843b5bb399b99e6401cff
    ' 0351a2ca-24d8-43b5-bb39-9b99e6401cff
    ' How to: Create a Directory in Visual Basic

    Public Sub Method2()
        ' <snippet2>
        My.Computer.FileSystem.CreateDirectory(
          "C:\Documents and Settings\All Users\Documents\NewDirectory")
        ' </snippet2>
    End Sub

End Class

Class Class07637b38bd9949b18cc0dc37cdb14dba
    ' 07637b38-bd99-49b1-8cc0-dc37cdb14dba
    ' My.Computer.FileSystem.DeleteFile Method

    Public Sub Method3()
        ' <snippet3>
        My.Computer.FileSystem.DeleteFile("C:\test.txt")
        ' </snippet3>
    End Sub

    Public Sub Method4()
        ' <snippet4>
        My.Computer.FileSystem.DeleteFile(
          "C:\test.txt",
          FileIO.UIOption.AllDialogs,
          FileIO.RecycleOption.SendToRecycleBin,
          FileIO.UICancelOption.ThrowException)
        ' </snippet4>
    End Sub

    Public Sub Method5()
        ' <snippet5>
        My.Computer.FileSystem.DeleteFile(
          "C:\test.txt",
          FileIO.UIOption.OnlyErrorDialogs,
          FileIO.RecycleOption.SendToRecycleBin,
          FileIO.UICancelOption.ThrowException)
        ' </snippet5>
    End Sub

End Class

Class Class0c50a18fc24e4266a95276bce924ad3e
    ' 0c50a18f-c24e-4266-a952-76bce924ad3e
    ' How to: Determine How Many Files Are in a Directory in Visual Basic

    Public Sub Method6()
        ' <snippet6>
        Dim counter = My.Computer.FileSystem.GetFiles("C:\TestDir")
        MsgBox("number of files is " & CStr(counter.Count))
        ' </snippet6>
    End Sub

    Public Sub Method7()
        ' <snippet7>
        Dim counter = My.Computer.FileSystem.GetFiles("C:\TestDir")
        ' </snippet7>
    End Sub

    Public Sub Method8()
        Dim counter = My.Computer.FileSystem.GetFiles("C:\TestDir")
        ' <snippet8>
        MsgBox("number of files is " & CStr(counter.Count))
        ' </snippet8>
    End Sub

End Class

Class Class0ea7e0c82cb24bf5a00d7b6e3c08a3bc
    ' 0ea7e0c8-2cb2-4bf5-a00d-7b6e3c08a3bc
    ' How to: Rename a File in Visual Basic

    Public Sub Method9()
        ' <snippet9>
        ' Change "c:\test.txt" to the path and filename for the file that
        ' you want to rename.
        My.Computer.FileSystem.RenameFile("C:\Test.txt", "SecondTest.txt")
        ' </snippet9>
    End Sub

End Class

Class Class0f26d1efc0a044458eb09b7d0490411c
    ' 0f26d1ef-c0a0-4445-8eb0-9b7d0490411c
    ' How to: Move a Directory in Visual Basic

    Public Sub Method10()
        ' <snippet10>
        My.Computer.FileSystem.MoveDirectory("C:\Dir1", "C:\Dir2")
        ' </snippet10>
    End Sub

    Public Sub Method11()
        ' <snippet11>
        My.Computer.FileSystem.MoveDirectory("C:\Dir1", "C:\Dir2", True)
        ' </snippet11>
    End Sub

End Class

Class Class10d9a542698c4150ada9033527605b7f
    ' 10d9a542-698c-4150-ada9-033527605b7f
    ' My.Computer.FileSystem.GetTempFileName Method

    Public Sub Method12()
        ' <snippet12>
        MsgBox("The file is located at " &
        My.Computer.FileSystem.GetTempFileName)
        ' </snippet12>
    End Sub

End Class

Class Class14700cb39d2946e2af8d61970d7e251b
    ' 14700cb3-9d29-46e2-af8d-61970d7e251b
    ' My.Computer.FileSystem.RenameDirectory Method

    Public Sub Method13()
        ' <snippet13>
        My.Computer.FileSystem.RenameDirectory("C:MyDocuments\Test", "SecondTest")
        ' </snippet13>
    End Sub

End Class

Class Class1c726124781d49769baaed46814ff3fe
    ' 1c726124-781d-4976-9baa-ed46814ff3fe
    ' How to: Write Text to Files in MyDocuments (Visual Basic)

    Public Sub Method14()
        Dim filepath As String = "filepath"
        ' <snippet14>
        My.Computer.FileSystem.WriteAllText(filePath, "some text", True)
        ' </snippet14>
    End Sub

End Class

Class Class26560d017dda44578e9521db23d71aea
    ' 26560d01-7dda-4457-8e95-21db23d71aea
    ' How to: Retrieve the Contents of the MyDocuments Folder in Visual Basic

    Public Sub Method15()
        ' <snippet15>
        Dim path As String
        Dim patients As String
        path = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & "Patients.txt"
        patients = My.Computer.FileSystem.ReadAllText(path)
        ' </snippet15>
    End Sub

End Class

Class Class2a370bd710ba4219afc44519d031eb6c
    ' 2a370bd7-10ba-4219-afc4-4519d031eb6c
    ' How to: Copy a Directory to Another Directory in Visual Basic

    Public Sub Method16()
        ' <snippet16>
        My.Computer.FileSystem.CopyDirectory("C:\TestDirectory1", "C:\TestDirectory2", True)
        ' </snippet16>
    End Sub

End Class

Class Class2c1688d2a60c4e689a1a4006917b28e1
    ' 2c1688d2-a60c-4e68-9a1a-4006917b28e1
    ' My.Computer.FileSystem.CreateDirectory Method

    Public Sub Method17()
        ' <snippet17>
        My.Computer.FileSystem.CreateDirectory(
          "C:\Documents and Settings\All Users\Documents\NewDirectory")
        ' </snippet17>
    End Sub

End Class

Class Class2ebefb41a88946a594068688329288c3
    ' 2ebefb41-a889-46a5-9406-8688329288c3
    ' My.Computer.FileSystem.CurrentDirectory Property

    Public Sub Method18()
        ' <snippet18>
        MsgBox(My.Computer.FileSystem.CurrentDirectory)
        ' </snippet18>
    End Sub

    Public Sub Method19()
        ' <snippet19>
        My.Computer.FileSystem.CurrentDirectory = "C:\TestDirectory"
        ' </snippet19>
    End Sub

End Class

Class Class3c2a7073f7b540c0b3973c9f3d43caeb
    ' 3c2a7073-f7b5-40c0-b397-3c9f3d43caeb
    ' How to: Determine a Drive's Physical Free Space in Visual Basic

    Public Sub Method20()
        ' <snippet20>
        Dim cdrive As System.IO.DriveInfo
        cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
        MsgBox("Total free space: " & CStr(cdrive.TotalFreeSpace))
        ' </snippet20>
    End Sub

End Class

Class Class3d201ebc54994ee286d0c2d8f023701d
    ' 3d201ebc-5499-4ee2-86d0-c2d8f023701d
    ' My.Computer.FileSystem.GetName Method

    Public Sub Method21()
        ' <snippet21>
        MsgBox("The filename is: " &
        My.Computer.FileSystem.GetName("C:\testdirectory\testfile"))
        ' </snippet21>
    End Sub

End Class

Class Class4b7217693e454be7b7feb08dc4141b44
    ' 4b721769-3e45-4be7-b7fe-b08dc4141b44
    ' How to: Delete a File in Visual Basic

    Public Sub Method22()
        ' <snippet22>
        My.Computer.FileSystem.DeleteFile("C:\test.txt")
        ' </snippet22>
    End Sub

End Class

Class Class4c14545654534bdaaab5578dc8bee59a
    ' 4c145456-5453-4bda-aab5-578dc8bee59a
    ' My.Computer.FileSystem Object

    Public Sub Method23()
        ' <snippet23>
        Dim logInfo As System.IO.DirectoryInfo
        If My.Computer.FileSystem.DirectoryExists("C:\backup\logs") Then
            logInfo = My.Computer.FileSystem.GetDirectoryInfo(
              "C:\backup\logs")
        End If
        ' </snippet23>
    End Sub

End Class

Class Class53a7457b581541adb37d28537c1fb77a
    ' 53a7457b-5815-41ad-b37d-28537c1fb77a
    ' How to: Move a File in Visual Basic

    Public Sub Method24()
        ' <snippet24>
        My.Computer.FileSystem.MoveFile("C:\TestDir1\test.txt",
            "C:\TestDir2\test.txt")
        ' </snippet24>
    End Sub

    Public Sub Method25()
        ' <snippet25>
        My.Computer.FileSystem.MoveFile("C:\TestDir1\test.txt",
            "C:\TestDir2\nexttest.txt",
            FileIO.UIOption.AllDialogs,
            FileIO.UICancelOption.ThrowException)
        ' </snippet25>
    End Sub

End Class

Class Class585f14af16694efd83c55e576a487d5d
    ' 585f14af-1669-4efd-83c5-5e576a487d5d
    ' My.Computer.FileSystem.SpecialDirectories.MyMusic Property

    Public Sub Method26()
        ' <snippet26>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.MyMusic)
        ' </snippet26>
    End Sub

End Class

Class Class59fae125de5b4c96883c209f4a55112c
    ' 59fae125-de5b-4c96-883c-209f4a55112c
    ' How to: Write to a Binary File in Visual Basic

    Public Sub Method27()
        Dim customerQuery As Byte() = {0}
        ' <snippet27>
        Dim CustomerData As Byte() = (From c In customerQuery).ToArray()

        My.Computer.FileSystem.WriteAllBytes(
          "C:\MyDocuments\CustomerData", CustomerData, True)
        ' </snippet27>
    End Sub

End Class



Class Class68d88e077f2748deb7438d7baf5b590e
    ' 68d88e07-7f27-48de-b743-8d7baf5b590e
    ' My.Computer.FileSystem.SpecialDirectories.Temp Property

    Public Sub Method31()
        ' <snippet31>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.Temp)
        ' </snippet31>
    End Sub

End Class

Class Class6c8ba7e8dd37485392bf762b67c98160
    ' 6c8ba7e8-dd37-4853-92bf-762b67c98160
    ' How to: Get the Collection of Files in a Directory in Visual Basic

    Public Sub Method32()
        Dim listBox1 As New System.Windows.Forms.ListBox
        ' <snippet32>
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
          My.Computer.FileSystem.SpecialDirectories.MyDocuments)

            listBox1.Items.Add(foundFile)
        Next
        ' </snippet32>
    End Sub

End Class

Class Class76a7ee5aed55479880737592aee2ff47
    ' 76a7ee5a-ed55-4798-8073-7592aee2ff47
    ' My.Computer.FileSystem.ReadAllBytes Method

    Public Sub Method33()
        ' <snippet33>
        My.Computer.FileSystem.ReadAllBytes(
          "C:/Documents and Settings/selfportrait.jpg")
        ' </snippet33>
    End Sub

End Class

Class Class780c7afca03c4b01865a510fe331b1cc
    ' 780c7afc-a03c-4b01-865a-510fe331b1cc
    ' How to: Rename a Directory in Visual Basic

    Public Sub Method34()
        ' <snippet34>
        My.Computer.FileSystem.RenameDirectory("C:MyDocuments\Test",
        "SecondTest")
        ' </snippet34>
    End Sub

End Class

Class Class7d2109ebf98a4389b43d30f384aaa7d5
    ' 7d2109eb-f98a-4389-b43d-30f384aaa7d5
    ' Walkthrough: Manipulating Files Using .NET Framework Methods


    Public Sub Method36()
        ' <snippet36>
        Dim fw As StreamWriter
        ' </snippet36>
        fw = New StreamWriter("C:\MyDiary.txt", True)
    End Sub

    Public Sub Method37()
        Dim fw As StreamWriter
        Dim entry As New System.Windows.Forms.TextBox
        fw = New StreamWriter("C:\MyDiary.txt", True)
        ' <snippet37>
        Dim ReadString As String
        Try
            'Pass the file path and name to the StreamWriter constructor.
            'Indicate that Append is True, so file will not be overwritten.
            fw = New StreamWriter("C:\MyDiary.txt", True)
            ReadString = Entry.Text
            fw.WriteLine(ReadString)
        Finally
            'Close the file.
            fw.Close()
        End Try
        ' </snippet37>
    End Sub

    Public Sub Method38()
        Dim fw As StreamWriter
        Dim entry As New System.Windows.Forms.TextBox
        fw = New StreamWriter("C:\MyDiary.txt", True)
        ' <snippet38>
        If (Entry.Text = "" Or Entry.Text = "Please enter something.") Then
            Entry.Text = "Please enter something."
            Return
        End If
        ' </snippet38>
    End Sub

    Public Sub Method39()
        Dim fw As StreamWriter
        Dim entry As New System.Windows.Forms.TextBox
        fw = New StreamWriter("C:\MyDiary.txt", True)
        ' <snippet39>
        Dim Today As DateTime
        Today = Now
        fw.Write(CStr(Today))
        fw.Write(ControlChars.CrLf)
        ' </snippet39>
    End Sub

    Public Sub Method40()
        Dim fw As StreamWriter
        Dim entry As New System.Windows.Forms.TextBox
        fw = New StreamWriter("C:\MyDiary.txt", True)
        ' <snippet40>
        Entry.Text = ""
        ' </snippet40>
    End Sub

    Public Sub Method41()
        Dim pickentries As New System.Windows.Forms.ListBox
        ' <snippet41>
        Dim fr As StreamReader = Nothing
        Dim FileString As String
        FileString = ""
        Try
            fr = New System.IO.StreamReader("C:\MyDiary.txt")
            PickEntries.Items.Clear()
            PickEntries.Enabled = True
            Do
                FileString = fr.ReadLine
                If IsDate(FileString) Then
                    PickEntries.Items.Add(FileString)
                End If
            Loop Until (FileString Is Nothing)
        Finally
            If fr IsNot Nothing Then
                fr.Close()
            End If
        End Try
        PickEntries.Enabled = True
        ' </snippet41>
    End Sub

    Public Sub Method42()
        Dim pickentries As New System.Windows.Forms.ComboBox
        Dim displayentry As New System.Windows.Forms.Button
        ' <snippet42>
        Dim fr As StreamReader
        Dim ReadString As String
        'Make sure ReadString begins empty.
        ReadString = ""
        Dim FileString As String
        fr = New StreamReader("C:\MyDiary.txt")
        'If no entry has been selected, show the whole file.
        If PickEntries.Enabled = False Or PickEntries.SelectedText Is Nothing Then
            Do
                'Read a line from the file into FileString.
                FileString = fr.ReadLine
                'add it to ReadString
                ReadString = ReadString & ControlChars.CrLf & FileString
            Loop Until (FileString = Nothing)
        Else
            'An entry has been selected, find the line that matches.
            Do

                FileString = fr.ReadLine
            Loop Until FileString = CStr(PickEntries.SelectedItem)
            FileString = CStr(PickEntries.SelectedItem) & ControlChars.CrLf
            ReadString = FileString & fr.ReadLine

            'Read from the file until EOF or another Date is found.
            Do Until ((fr.Peek < 0) Or (IsDate(fr.ReadLine)))
                ReadString = ReadString & fr.ReadLine
            Loop
        End If
        fr.Close()
        DisplayEntry.Visible = True
        DisplayEntry.Text = ReadString
        ' </snippet42>
    End Sub

    Public Sub Method43()
        Dim deleteentry As New System.Windows.Forms.Button

        ' <snippet43>
        DeleteEntry.enabled = True
        ' </snippet43>
    End Sub

    Public Sub Method44()
        Dim displayentry As New System.Windows.Forms.TextBox
        Dim pickentries As New System.Windows.Forms.ComboBox
        Dim deleteentry As New System.Windows.Forms.TextBox

        ' <snippet44>
        Dim fr As StreamReader
        Dim ReadString As String
        Dim WriteString As String
        Dim ConfirmDelete As MsgBoxResult
        fr = New StreamReader("C:\MyDiary.txt")
        ReadString = fr.ReadLine
        ' Read through the textfile
        Do Until (fr.Peek < 0)
            ReadString = ReadString & vbCrLf & fr.ReadLine
        Loop
        WriteString = Replace(ReadString, DisplayEntry.Text, "")
        fr.Close()
        ' Check to make sure the user wishes to delete the entry
        ConfirmDelete = MsgBox("Do you really wish to delete this entry?",
          MsgBoxStyle.OKCancel)
        If ConfirmDelete = MsgBoxResult.OK Then
            File.Delete("C:\MyDiary.txt")
            Dim fw As StreamWriter = File.CreateText("C:\MyDiary.txt")
            fw.WriteLine(WriteString)
            fw.Close()
            ' Reset controls on the form
            DisplayEntry.Text = ""
            PickEntries.Text = ""
            PickEntries.Items.Clear()
            PickEntries.Enabled = False
            DeleteEntry.Enabled = False
        End If
        ' </snippet44>
    End Sub

    Public Sub Method45()
        Dim editentry As New System.Windows.Forms.Button
        ' <snippet45>
        EditEntry.Enabled = True
        ' </snippet45>
    End Sub

    Public Sub Method46()
        Dim entry As New System.Windows.Forms.TextBox
        Dim displayentry As New System.Windows.Forms.TextBox
        Dim submitedit As New System.Windows.Forms.Button
        ' <snippet46>
        Entry.Text = DisplayEntry.Text
        SubmitEdit.Enabled = True
        ' </snippet46>
    End Sub

    Public Sub Method47()
        Dim entry As New System.Windows.Forms.TextBox
        Dim displayentry As New System.Windows.Forms.TextBox
        Dim editentry As New System.Windows.Forms.Button
        Dim submitedit As New System.Windows.Forms.Button
        ' <snippet47>
        Dim fr As StreamReader
        Dim ReadString As String
        Dim WriteString As String
        If Entry.Text = "" Then
            MsgBox("Use Delete to Delete an Entry")
            Return
        End If
        fr = New StreamReader("C:\MyDiary.txt")
        ReadString = fr.ReadLine
        Do Until (fr.Peek < 0)
            ReadString = ReadString & vbCrLf & fr.ReadLine
        Loop
        WriteString = Replace(ReadString, DisplayEntry.Text, Entry.Text)
        fr.Close()
        File.Delete("C:\MyDiary.txt")
        Dim fw As StreamWriter = File.CreateText("C:\MyDiary.txt")
        fw.WriteLine(WriteString)
        fw.Close()
        DisplayEntry.Text = Entry.Text
        Entry.Text = ""
        EditEntry.Enabled = False
        SubmitEdit.Enabled = False
        ' </snippet47>
    End Sub

End Class

Class Classab01af4109ca4206b81d876379a18e3b
    ' ab01af41-09ca-4206-b81d-876379a18e3b
    ' My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData Property

    Public Sub Method48()
        ' <snippet48>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)
        ' </snippet48>
    End Sub

End Class

Class Classaedb6fd5dca3415388b601b9796329c3
    ' aedb6fd5-dca3-4153-88b6-01b9796329c3
    ' My.Computer.FileSystem.CopyDirectory Method

    Public Sub Method49()
        ' <snippet49>
        My.Computer.FileSystem.CopyDirectory("C:\TestDirectory1", "C:\TestDirectory2", True)
        ' </snippet49>
    End Sub

End Class

Class Classb1a24dc1eac84e228ffacc3bacbaf826
    ' b1a24dc1-eac8-4e22-8ffa-cc3bacbaf826
    ' My.Computer.FileSystem.WriteAllBytes Method

    Public Sub Method50()
        Dim customerdata As Byte() = {0}
        ' <snippet50>
        My.Computer.FileSystem.WriteAllBytes(
          "C:\MyDocuments\CustomerData", CustomerData, True)
        ' </snippet50>
    End Sub

End Class

Class Classb2fdda86e66642c297069527e9fa68ff
    ' b2fdda86-e666-42c2-9706-9527e9fa68ff
    ' How to: Create a Copy of a File in the Same Directory in Visual Basic

    Public Sub Method51()
        ' <snippet51>
        My.Computer.FileSystem.CopyFile("C:\TestFolder\test.txt",
        "C:\TestFolder\test2.txt", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
        ' </snippet51>
    End Sub

    Public Sub Method52()
        ' <snippet52>
        My.Computer.FileSystem.CopyFile("C:\TestFolder\test.txt",
        "C:\TestFolder\test2.txt", True)
        ' </snippet52>
    End Sub

End Class

Class Classb55a2a7967e84a05b88bc2dee1fc5b2f
    ' b55a2a79-67e8-4a05-b88b-c2dee1fc5b2f
    ' My.Computer.FileSystem.SpecialDirectories.MyDocuments Property

    Public Sub Method53()
        ' <snippet53>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        ' </snippet53>
    End Sub

End Class

Class Classc1bd99c98160456ab5ab60a49139b923
    ' c1bd99c9-8160-456a-b5ab-60a49139b923
    ' How to: Parse File Paths in Visual Basic

    Public Sub Method54()
        ' <snippet54>
        Dim testFile As System.IO.FileInfo
        testFile = My.Computer.FileSystem.GetFileInfo("C:\TestFolder1\test1.txt")
        Dim folderPath As String = testFile.DirectoryName
        MsgBox(folderPath)
        Dim fileName As String = testFile.Name
        MsgBox(fileName)
        ' </snippet54>

        ' <snippet55>
        Dim fullPath As String
        fullPath = My.Computer.FileSystem.CombinePath(folderPath, fileName)
        MsgBox(fullPath)
        ' </snippet55>
    End Sub

End Class

Class Classc8038bac8e59467d85d9a5d5e6367737
    ' c8038bac-8e59-467d-85d9-a5d5e6367737
    ' My.Computer.FileSystem.DeleteDirectory Method

    Public Sub Method56()
        ' <snippet56>
        My.Computer.FileSystem.DeleteDirectory(
          "C:\OldDirectory",
          FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
        ' </snippet56>
    End Sub

    Public Sub Method57()
        ' <snippet57>
        My.Computer.FileSystem.DeleteDirectory(
          "C:\OldDirectory",
          FileIO.DeleteDirectoryOption.DeleteAllContents)
        ' </snippet57>
    End Sub

    Public Sub Method58()
        ' <snippet58>
        My.Computer.FileSystem.DeleteDirectory(
          "C:\OldDirectory",
          FileIO.UIOption.AllDialogs,
          FileIO.RecycleOption.DeletePermanently,
          FileIO.UICancelOption.ThrowException)
        ' </snippet58>
    End Sub

    Public Sub Method59()
        ' <snippet59>
        My.Computer.FileSystem.DeleteDirectory(
         "C:\OldDirectory",
         FileIO.UIOption.AllDialogs,
         FileIO.RecycleOption.SendToRecycleBin,
         FileIO.UICancelOption.ThrowException)
        ' </snippet59>
    End Sub

End Class

Class Classc8f1380032514f11b47a5f0489989ba7
    ' c8f13800-3251-4f11-b47a-5f0489989ba7
    ' My.Computer.FileSystem.SpecialDirectories.Desktop Property

    Public Sub Method60()
        ' <snippet60>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.Desktop)
        ' </snippet60>
    End Sub

End Class

Class Classc98e98f7fc4e4f7abe917c532c858df0
    ' c98e98f7-fc4e-4f7a-be91-7c532c858df0
    ' My.Computer.FileSystem.SpecialDirectories.Programs Property

    Public Sub Method61()
        ' <snippet61>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.Programs)
        ' </snippet61>
    End Sub

End Class

Class Classcae775659f784e468e42eb2f9f8e1ffd
    Inherits System.Windows.Forms.Form
    ' cae77565-9f78-4e46-8e42-eb2f9f8e1ffd
    ' Walkthrough: Manipulating Files and Directories in Visual Basic
    Dim DirectoryTextBox As New System.Windows.Forms.TextBox
    Dim FilePickComboBox As New System.Windows.Forms.ComboBox
    Dim LastAccessCheckBox As New System.Windows.Forms.CheckBox
    Dim SaveCheckBox As New System.Windows.Forms.CheckBox
    Dim FileLengthCheckBox As New System.Windows.Forms.CheckBox

    '    Dim strFirstline As String
    'Dim firstline As String
    'Dim lastaccess As Date
    'Dim foundFile As New System.IO.FileInfo("test.txt")
    'Dim length As Long

    Private Sub Form1_Load() Handles Me.Load
        ' <snippet62>
        DirectoryTextBox.Text = My.Computer.FileSystem.CurrentDirectory
        ' </snippet62>
    End Sub

    Public Sub btnSubmit_Click()

        Dim fileList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

        Dim errorMessage = ""

        ' <snippet63>
        ' newPath holds the path the user has entered.
        Dim newPath = DirectoryTextBox.Text
        ' Change the location to newPath.
        My.Computer.FileSystem.CurrentDirectory = newPath
        ' </snippet63>


        ' <snippet64>
        Try
            ' </snippet64>

            My.Computer.FileSystem.CurrentDirectory = newPath

            ' <snippet65>
            ' This checks to make sure the path is not blank.
        Catch ex As Exception When newPath = ""
            ErrorMessage = "You must enter a path."
            ' This catches errors caused by a path that is not valid.
        Catch
            ErrorMessage = "You must enter a valid path.  If trying " &
            "to access a different drive, remember to include the drive " &
            "letter."
        Finally
            ' Display the error message only if one exists.
            If errorMessage <> Nothing Then
                MsgBox(errorMessage)
            End If
        End Try
        ' </snippet65>

        ' <snippet66>
        fileList = My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.CurrentDirectory,
            FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
        For Each foundFile In fileList
            FilePickComboBox.Items.Add(foundFile)
        Next
        ' </snippet66>
    End Sub

    Public Sub btnExamine_Click()
        ' <snippet67>
        Dim thisFile =
            My.Computer.FileSystem.GetFileInfo(CStr(FilePickComboBox.SelectedItem))
        ' </snippet67>

        ' <snippet68>
        Dim stringlength = "The file's length, in bytes, is: "
        Dim stringLastAccess = "The file was last accessed on: "
        Dim lastAccess As Date
        Dim length As Long
        Dim firstLine = ""
        Dim finalString = ""

        If FilePickComboBox.SelectedItem Is Nothing Then
            MsgBox("You must select a file to examine.")
            Exit Sub
        End If

        Dim newName = CStr(FilePickComboBox.SelectedItem)
        ' </snippet68>

        ' <snippet69>
        ' Check last access time.
        If LastAccessCheckBox.Checked = True Then
            lastAccess = thisFile.LastAccessTime
        End If
        ' </snippet69>
        ' <snippet73>
        ' Add to the message box.
        finalString = finalString & stringLastAccess & lastAccess & "." &
          vbCrLf
        ' </snippet73>

        ' <snippet70>
        ' Check length.
        If FileLengthCheckBox.Checked = True Then
            length = thisFile.Length
        End If
        ' </snippet70>
        ' <snippet74>
        ' Add to the message box.
        finalString = finalString & stringlength & CStr(Length) & "." &
          vbCrLf
        ' </snippet74>

        ' <snippet75>
        ' Add to the message box.
        finalString &= firstLine & vbCrLf
        ' </snippet75>

        ' <snippet76>
        ' Check to see whether results should be saved.
        If SaveCheckBox.Checked = True AndAlso finalString <> "" Then
            My.Computer.FileSystem.WriteAllText("log.txt", finalString, True)
        End If
        ' </snippet76>
    End Sub

End Class

Class Classcfba872bf268400f983a2e4525845874
    ' cfba872b-f268-400f-983a-2e4525845874
    ' My.Computer.FileSystem.SpecialDirectories.MyPictures Property

    Public Sub Method77()
        ' <snippet77>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.MyPictures)
        ' </snippet77>
    End Sub

End Class

Class Classd2b1269e24b642e09414ae708db282d8
    ' d2b1269e-24b6-42e0-9414-ae708db282d8
    ' How to: Read From a Binary File in Visual Basic

    Public Sub Method78()
        Dim PictureBox1 As New PictureBox
        ' <snippet78>
        Dim bytes = My.Computer.FileSystem.ReadAllBytes(
                      "C:/Documents and Settings/selfportrait.jpg")
        PictureBox1.Image = Image.FromStream(New IO.MemoryStream(bytes))
        ' </snippet78>
    End Sub

    '<Snippet91>
    ' This method does not trap for exceptions. If an exception is 
    ' encountered opening the file to be copied or writing to the 
    ' destination location, then the exception will be thrown to 
    ' the requestor.
    Public Sub CopyBinaryFile(ByVal path As String,
                              ByVal copyPath As String,
                              ByVal bufferSize As Integer,
                              ByVal overwrite As Boolean)

        Dim inputFile = IO.File.Open(path, IO.FileMode.Open)

        If overwrite AndAlso My.Computer.FileSystem.FileExists(copyPath) Then
            My.Computer.FileSystem.DeleteFile(copyPath)
        End If

        ' Adjust array length for VB array declaration.
        Dim bytes = New Byte(bufferSize - 1) {}

        While inputFile.Read(bytes, 0, bufferSize) > 0
            My.Computer.FileSystem.WriteAllBytes(copyPath, bytes, True)
        End While

        inputFile.Close()
    End Sub
    '</Snippet91>

End Class

Class Classd5b61ecef32746fba82ad6b102dbc0ca
    ' d5b61ece-f327-46fb-a82a-d6b102dbc0ca
    ' My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData Property

    Public Sub Method79()
        ' <snippet79>
        MsgBox(
          My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData)
        ' </snippet79>
    End Sub

End Class

Class Classd5f375c3094b4011843817a31bc6df2b
    ' d5f375c3-094b-4011-8438-17a31bc6df2b
    ' My.Computer.FileSystem.SpecialDirectories Object

    Public Sub Method80()
        ' <snippet80>
        Dim filePath As String
        filePath = My.Computer.FileSystem.SpecialDirectories.Desktop
        MsgBox(filePath)
        ' </snippet80>
    End Sub

End Class

Class Classe03f46b0dfbf450491fe8e46b0e7cb1d
    ' e03f46b0-dfbf-4504-91fe-8e46b0e7cb1d
    ' My.Computer.FileSystem.MoveDirectory Method

    Public Sub Method81()
        ' <snippet81>
        My.Computer.FileSystem.MoveDirectory("C:\Directory1", "C:\Directory2")
        ' </snippet81>
    End Sub

    Public Sub Method82()
        ' <snippet82>
        My.Computer.FileSystem.MoveDirectory("C:\Directory1", "C:\Directory2",
        True)
        ' </snippet82>
    End Sub

End Class

Class Classe80452a8e9b74532a20e97edb859d121
    ' e80452a8-e9b7-4532-a20e-97edb859d121
    ' How to: Delete a Directory in Visual Basic

    Public Sub Method83()
        ' <snippet83>
        My.Computer.FileSystem.DeleteDirectory("C:\OldDirectory",
        FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
        ' </snippet83>
    End Sub

    Public Sub Method84()
        ' <snippet84>
        My.Computer.FileSystem.DeleteDirectory("C:\OldDirectory",
        FileIO.DeleteDirectoryOption.DeleteAllContents)
        ' </snippet84>
    End Sub

    Public Sub Method85()
        ' <snippet85>
        My.Computer.FileSystem.DeleteDirectory("C:\OldDirectory", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        ' </snippet85>
    End Sub

End Class

Class Classf13ecad9b95f49239f05c061a1617756
    ' f13ecad9-b95f-4923-9f05-c061a1617756
    ' My.Computer.FileSystem.MoveFile Method

    Public Sub Method86()
        ' <snippet86>
        My.Computer.FileSystem.MoveFile("C:\TestDir1\test.txt", "C:\TestDir2\test.txt")
        ' </snippet86>
    End Sub

    Public Sub Method87()
        ' <snippet87>
        My.Computer.FileSystem.MoveFile("C:\TestDir1\test.txt", "C:\TestDir2\test2.txt")
        ' </snippet87>
    End Sub

End Class

Class Classf205d2adbbe54d558a40acda21aa82dd
    ' f205d2ad-bbe5-4d55-8a40-acda21aa82dd
    ' How to: Copy Files with a Specific Pattern to a Directory in Visual Basic

    Public Sub Method88()
        Dim foundfile As String = "x"

        ' <snippet88>
        My.Computer.FileSystem.CopyFile(foundFile, "C:\testdirectory\" & My.Computer.FileSystem.GetName(foundFile))
        ' </snippet88>
    End Sub

    Public Sub Method89()
        Dim i As Integer
        For i = 1 To 5
            ' <snippet89>
        Next
        ' </snippet89>
    End Sub

End Class

Class Class7bb0d83e875a4b158935bdc24e71ef98
    ' 7bb0d83e-875a-4b15-8935-bdc24e71ef98
    ' My.Computer.FileSystem.SpecialDirectories.ProgramFiles Property

    Public Sub Method90()
        ' <snippet90>
        MsgBox(My.Computer.FileSystem.SpecialDirectories.ProgramFiles)
        ' </snippet90>
    End Sub

End Class


