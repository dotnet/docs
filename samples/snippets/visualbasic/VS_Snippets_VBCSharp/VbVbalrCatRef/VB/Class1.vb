Option Explicit On
Option Strict On

Class Class0259fe248582471cb7278ddd0ef047a1
    ' 0259fe24-8582-471c-b727-8ddd0ef047a1
    ' FileLen Function

    Public Sub Method1()
        ' <snippet1>
        Dim MySize As Long
        ' Returns file length (bytes).
        MySize = FileLen("TESTFILE")
        ' </snippet1>
    End Sub

End Class

Class Class03a1877667a14462b55317d52bdfaa5c
    ' 03a18776-67a1-4462-b553-17d52bdfaa5c
    ' FileCopy Function

    Public Sub Method2()
        ' <snippet2>
        Dim SourceFile, DestinationFile As String
        SourceFile = "SRCFILE"   ' Define source file name.
        DestinationFile = "DESTFILE"   ' Define target file name.
        FileCopy(SourceFile, DestinationFile)   ' Copy source to target.
        ' </snippet2>
    End Sub

End Class

Class Class04df2ddee6df43159ca5eb5cc783985e
    ' 04df2dde-e6df-4315-9ca5-eb5cc783985e
    ' Dir Function

    Public Sub Method3()
        ' <snippet3>
        Dim MyFile, MyPath, MyName As String
        ' Returns "WIN.INI" if it exists.
        MyFile = Dir("C:\WINDOWS\WIN.INI")

        ' Returns filename with specified extension. If more than one *.INI
        ' file exists, the first file found is returned.
        MyFile = Dir("C:\WINDOWS\*.INI")

        ' Call Dir again without arguments to return the next *.INI file in the
        ' same directory.
        MyFile = Dir()

        ' Return first *.TXT file, including files with a set hidden attribute.
        MyFile = Dir("*.TXT", vbHidden)

        ' Display the names in C:\ that represent directories.
        MyPath = "c:\"   ' Set the path.
        MyName = Dir(MyPath, vbDirectory)   ' Retrieve the first entry.
        Do While MyName <> ""   ' Start the loop.
            ' Use bitwise comparison to make sure MyName is a directory.
            If (GetAttr(MyPath & MyName) And vbDirectory) = vbDirectory Then
                ' Display entry only if it's a directory.
                MsgBox(MyName)
            End If
            MyName = Dir()   ' Get next entry.
        Loop
        ' </snippet3>
    End Sub

End Class

Class Class0eb2cf1f62954b4aa7ff59b279bd3074
    ' 0eb2cf1f-6295-4b4a-a7ff-59b279bd3074
    ' ErrorToString Function

    Public Sub Method4()
        ' <snippet4>
        Dim ErrorNumber As Integer
        For ErrorNumber = 61 To 64   ' Loop through values 61 - 64.
            MsgBox(ErrorToString(ErrorNumber))   ' Display error names in message box.
        Next ErrorNumber
        ' </snippet4>
    End Sub

End Class

Class Class0f07e1dfd4ea44a9a21c76aa2e242f81
    ' 0f07e1df-d4ea-44a9-a21c-76aa2e242f81
    ' FileOpen Function

    Public Sub Method5()
        ' <snippet5>
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Close before reopening in another mode.
        FileClose(1)
        ' </snippet5>
    End Sub

    Public Sub Method6()
        ' <snippet6>
        FileOpen(1, "TESTFILE", OpenMode.Binary, OpenAccess.Write)
        ' Close before reopening in another mode.
        FileClose(1)
        ' </snippet6>
    End Sub

    ' <snippet7>
    Structure Person
        <VBFixedString(30)> Dim Name As String
        Dim ID As Integer
    End Structure
    Public Sub ExampleMethod()
        ' Count 30 for the string, plus 4 for the integer.
        FileOpen(1, "TESTFILE", OpenMode.Random, , , 34)
        ' Close before reopening in another mode.
        FileClose(1)
    End Sub
    ' </snippet7>

    Public Sub Method8()
        ' <snippet8>
        FileOpen(1, "TESTFILE", OpenMode.Output, OpenAccess.Default, OpenShare.Shared)
        ' Close before reopening in another mode.
        FileClose(1)
        ' </snippet8>
    End Sub

    Public Sub Method9()
        ' <snippet9>
        FileOpen(1, "TESTFILE", OpenMode.Binary, OpenAccess.Read,
           OpenShare.LockRead)
        ' </snippet9>
    End Sub

End Class

Class Class12c01ce2c8504b28b3944d8875aeba3d
    ' 12c01ce2-c850-4b28-b394-4d8875aeba3d
    ' FileWidth Function

    Public Sub Method10()
        ' <snippet10>
        Dim i As Integer
        FileOpen(1, "TESTFILE", OpenMode.Output) ' Open file for output.
        FileWidth(1, 5)   ' Set output line width to 5.
        For i = 0 To 9   ' Loop 10 times.
            Print(1, Chr(48 + I))   ' Prints five characters per line.
        Next
        FileClose(1)   ' Close file.
        ' </snippet10>
    End Sub

End Class

Class Class131e78f92efd4581b45c74fe89d347c9
    ' 131e78f9-2efd-4581-b45c-74fe89d347c9
    ' AppActivate Function

    Public Sub Method11()
        ' <snippet11>
        Dim notepadID As Integer
        ' Activate a running Notepad process.
        AppActivate("Untitled - Notepad")
        ' AppActivate can also use the return value of the Shell function.
        ' Shell runs a new instance of Notepad.
        notepadID = Shell("C:\WINNT\NOTEPAD.EXE", AppWinStyle.NormalFocus)
        ' Activate the new instance of Notepad.  
        AppActivate(notepadID)
        ' </snippet11>
    End Sub

End Class

Class Class142a2f6bd63347768822ffeffebf8397
    ' 142a2f6b-d633-4776-8822-ffeffebf8397
    ' Reset Function

    Public Sub Method12()
        ' <snippet12>
        ' Open 5 files named TEST1, TEST2, etc.
        Dim fileNumber As Integer
        ' Open 5 files.
        For fileNumber = 1 To 5
            FileOpen(fileNumber, "TEST" & fileNumber, OpenMode.Output)
            PrintLine(fileNumber, "Hello World")
        Next fileNumber
        ' Close files and write contents to disk.
        Reset()
        ' </snippet12>
    End Sub

End Class

Class Class1585c9fa47ff404c934134dd40ee15d1
    ' 1585c9fa-47ff-404c-9341-34dd40ee15d1
    ' Lock, Unlock Functions

    ' <snippet13>
    Structure Person
        Dim Name As String
        Dim ID As Integer
    End Structure

    Sub PutInLockedFile(ByVal onePerson As Person)
        FileOpen(1, "c:\people.txt", OpenMode.Binary)
        Lock(1)
        FilePut(1, onePerson)
        Unlock(1)
        FileClose(1)
    End Sub
    ' </snippet13>

End Class

Class Class1f0c46e394d74a48ade880eb14e0eba4
    ' 1f0c46e3-94d7-4a48-ade8-80eb14e0eba4
    ' SetAttr Function

    Public Sub Method14()
        ' <snippet14>
        ' Set hidden attribute.
        SetAttr("TESTFILE", vbHidden)
        ' Set hidden and read-only attributes.
        SetAttr("TESTFILE", vbHidden Or vbReadOnly)
        ' </snippet14>
    End Sub

End Class

Class Class1f65d831e2e44a5a8ee8eca5db72c509
    ' 1f65d831-e2e4-4a5a-8ee8-eca5db72c509
    ' SPC Function



    Public Sub Method16()
        ' <snippet16>
        ' The SPC function can be used with the Print function.
        FileOpen(1, "TESTFILE", OpenMode.Output)   ' Open file for output.
        Print(1, "10 spaces between here", SPC(10), "and here.")
        FileClose(1)   ' Close file.
        ' </snippet16>
    End Sub

End Class

Class Class1faf98aad25c48878ff498847cc0fbdc
    ' 1faf98aa-d25c-4887-8ff4-98847cc0fbdc
    ' Loc Function

    Public Sub Method17()
        ' <snippet17>
        Dim location As Long
        Dim oneChar As Char
        FileOpen(1, "C:\TESTFILE.TXT", OpenMode.Binary)
        While location < LOF(1)
            Input(1, oneChar)
            location = Loc(1)
            WriteLine(1, location & ControlChars.CrLf)
        End While
        FileClose(1)
        ' </snippet17>
    End Sub

End Class

Class Class25d1c892519c411d8b84543324ece2ea
    ' 25d1c892-519c-411d-8b84-543324ece2ea
    ' RGB Function (Visual Basic)

    Public Sub Method18()
        ' <snippet18>
        Dim red, rgbValue As Integer
        Dim i As Integer = 75
        ' Return the value for red.
        red = RGB(255, 0, 0)
        ' Same as RGB(75, 139, 203).
        rgbValue = RGB(i, 64 + i, 128 + i)
        ' </snippet18>
    End Sub

End Class

Class Class2dd49344ef2d4bbead62b97ce50b18c8
    ' 2dd49344-ef2d-4bbe-ad62-b97ce50b18c8
    ' LineInput Function

    Public Sub Method19()
        ' <snippet19>
        Dim TextLine As String
        ' Open file.
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Loop until end of file.
        While Not EOF(1)
            ' Read line into variable.
            TextLine = LineInput(1)
            ' Print to the console.
            Console.WriteLine("1", TextLine)
        End While
        FileClose(1)
        ' </snippet19>
    End Sub

End Class

Class Class30eedf308c8a4c81baea3ff0bd36acc7
    ' 30eedf30-8c8a-4c81-baea-3ff0bd36acc7
    ' MsgBox Function (Visual Basic)

    Public Sub Method20()

        ' <snippet20>
        ' The following example requires that Option Infer be set to On.

        ' Define the message you want to see inside the message box.
        Dim msg = "Do you want to continue?"

        ' Display a simple message box.
        MsgBox(msg)

        ' Define a title for the message box.
        Dim title = "MsgBox Demonstration"

        ' Add the title to the display.
        MsgBox(msg, , title)

        ' Now define a style for the message box. In this example, the
        ' message box will have Yes and No buttons, the default will be
        ' the No button, and a Critical Message icon will be present.
        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or
                    MsgBoxStyle.Critical

        ' Display the message box and save the response, Yes or No.
        Dim response = MsgBox(msg, style, title)

        ' Take some action based on the response.
        If response = MsgBoxResult.Yes Then
            MsgBox("YES, continue!!", , title)
        Else
            MsgBox("NO, stop!!", , title)
        End If
        ' </snippet20>
    End Sub

End Class

Class Class31cbf2da4b9448f48cf8d88db0693213
    ' 31cbf2da-4b94-48f4-8cf8-d88db0693213
    ' FileGet Function

    Public Sub Method21()
        ' <snippet21>
        Dim MyArray(4, 9) As Integer
        ' </snippet21>
    End Sub

End Class

Class Class32b7885001cb498dafaa7b22a0770b8f
    ' 32b78850-01cb-498d-afaa-7b22a0770b8f
    ' LOF Function

    Public Sub Method23()
        ' <snippet23>
        Dim length As Long
        FileOpen(1, "C:\TESTFILE.TXT", OpenMode.Input) ' Open file.
        length = LOF(1)   ' Get length of file.
        MsgBox(length)
        FileClose(1)   ' Close file.
        ' </snippet23>
    End Sub

End Class

Class Class3dc0818c2c3e4bab9404f188978053ba
    ' 3dc0818c-2c3e-4bab-9404-f188978053ba
    ' GetAttr Function



    Public Sub Method25()
        ' <snippet25>
        Dim MyAttr As FileAttribute
        ' Assume file TESTFILE is normal and readonly.
        MyAttr = GetAttr("C:\TESTFILE.txt")   ' Returns vbNormal.

        ' Test for normal.
        If (MyAttr And FileAttribute.Normal) = FileAttribute.Normal Then
            MsgBox("This file is normal.")
        End If

        ' Test for normal and readonly.
        Dim normalReadonly As FileAttribute
        normalReadonly = FileAttribute.Normal Or FileAttribute.ReadOnly
        If (MyAttr And normalReadonly) = normalReadonly Then
            MsgBox("This file is normal and readonly.")
        End If

        ' Assume MYDIR is a directory or folder.
        MyAttr = GetAttr("C:\MYDIR")
        If (MyAttr And FileAttribute.Directory) = FileAttribute.Directory Then
            MsgBox("MYDIR is a directory")
        End If
        ' </snippet25>
    End Sub

End Class

Class Class3eda786bd1ee4b449dd70ea6bff072c0
    ' 3eda786b-d1ee-4b44-9dd7-0ea6bff072c0
    ' FileGetObject Function

    Public Sub Method26()
        ' <snippet26>
        Dim c As Object = "test"
        FileSystem.FileOpen(1, "test.dat", OpenMode.Binary)
        FileSystem.FilePutObject(1, "ABCDEF")
        FileSystem.Seek(1, 1)
        FileSystem.FileGetObject(1, c)
        MsgBox(c)
        FileSystem.FileClose(1)
        ' </snippet26>
    End Sub

    Public Sub Method27()
        ' <snippet27>
        Dim MyArray(4, 9) As Integer
        ' </snippet27>
    End Sub

End Class

Class Class408824304c6541d19701ad489c8296fe
    ' 40882430-4c65-41d1-9701-ad489c8296fe
    ' Environ Function

    ' <snippet28>
    Sub tenv()
        Dim envString As String
        Dim found As Boolean = False
        Dim index As Integer = 1
        Dim pathLength As Integer
        Dim message As String

        envString = Environ(index)
        While Not found And (envString <> "")
            If (envString.Substring(0, 5) = "Path=") Then
                found = True
            Else
                index += 1
                envString = Environ(index)
            End If
        End While

        If found Then
            pathLength = Environ("PATH").Length
            message = "PATH entry = " & index & " and length = " & pathLength
        Else
            message = "No PATH environment variable exists."
        End If

        MsgBox(message)
    End Sub
    ' </snippet28>

End Class

Class Class457f96ebb6b04d5da1f0e8e6d02cee76
    ' 457f96eb-b6b0-4d5d-a1f0-e8e6d02cee76
    ' QBColor Function

    Public Sub Method29()
        ' <snippet29>
        Dim colorInteger As Integer
        ' Use 4 for red.
        colorInteger = QBColor(4)
        ' </snippet29>
    End Sub

End Class

Class Class464062d8232043058a8c1f43e96c94df
    ' 464062d8-2320-4305-8a8c-1f43e96c94df
    ' Rename Function

    Public Sub Method30()
        ' <snippet30>
        Dim OldName, NewName As String
        OldName = "OLDFILE"
        ' Define file names.
        NewName = "NEWFILE"
        ' Rename file.
        Rename(OldName, NewName)

        OldName = "C:\OLDDIR\OLDFILE"
        NewName = "C:\NEWDIR\NEWFILE"
        ' Move and rename file.
        Rename(OldName, NewName)
        ' </snippet30>
    End Sub

End Class

Class Class55c0cb908b6a4e43b0c26c2f6146c43e
    ' 55c0cb90-8b6a-4e43-b0c2-6c2f6146c43e
    ' RmDir Function

    Public Sub Method31()
        ' <snippet31>
        ' Assume that MYDIR is an empty directory.
        ' Remove MYDIR.
        RmDir("MYDIR")
        ' </snippet31>
    End Sub

End Class

Class Class64dd300c196e41c9b872e174f7904c41
    ' 64dd300c-196e-41c9-b872-e174f7904c41
    ' ChDrive Function

    Public Sub Method32()
        ' <snippet32>
        ChDrive("D")   ' Make "D" the current drive.
        ' </snippet32>
    End Sub

End Class

Class Class65125d1faf734a16939407f97a345b8e
    ' 65125d1f-af73-4a16-9394-07f97a345b8e
    ' InputString Function

    Public Sub Method33()
        ' <snippet33>
        Dim oneChar As String
        ' Open file.
        FileOpen(1, "MYFILE.TXT", OpenMode.Input)
        ' Loop until end of file.
        While Not EOF(1)
            ' Get one character.
            oneChar = (InputString(1, 1))
            ' Print to the output window.
            System.Console.Out.WriteLine(oneChar)
        End While
        FileClose(1)
        ' </snippet33>
    End Sub

End Class

Class Class6ccd0e38ca82496d9db723077db3985f
    ' 6ccd0e38-ca82-496d-9db7-23077db3985f
    ' FileDateTime Function

    Public Sub Method34()
        ' <snippet34>
        Dim MyStamp As Date
        ' Assume TESTFILE was last modified on October 12, 2001 at 4:35:47 PM.
        ' Assume English/U.S. locale settings.
        ' Returns "10/12/2001 4:35:47 PM".
        MyStamp = FileDateTime("C:\TESTFILE.txt")
        ' </snippet34>
    End Sub

End Class

Class Class6e55faaed32f40389b21245e25399dba
    ' 6e55faae-d32f-4038-9b21-245e25399dba
    ' Input Function

    Public Sub Method35()
        ' <snippet35>
        FileOpen(1, "TESTFILE", OpenMode.Output)
        Write(1, "hello")
        Write(1, 14)
        FileClose(1)
        Dim s As String = "teststring"
        Dim i As Integer
        FileOpen(1, "TESTFILE", OpenMode.Input)
        Input(1, s)
        MsgBox(s)
        Input(1, i)
        MsgBox(i)
        FileClose(1)
        ' </snippet35>
    End Sub

End Class

Class Class77e2f46e618240d98e9b88be70827fc3
    ' 77e2f46e-6182-40d9-8e9b-88be70827fc3
    ' TAB Function

    Public Sub Method37()
        ' <snippet37>
        FileOpen(1, "TESTFILE", OpenMode.Output) ' Open file for output.
        ' The second word prints at column 20.
        Print(1, "Hello", TAB(20), "World.")
        ' If the argument is omitted, cursor is moved to the next print zone.
        Print(1, "Hello", TAB(), "World")
        FileClose(1)
        ' </snippet37>
    End Sub

End Class

Class Class8282172d5fc84b22947cb22acb4d1a4d
    ' 8282172d-5fc8-4b22-947c-b22acb4d1a4d
    ' MkDir Function

    Public Sub Method38()
        ' <snippet38>
        ' Make new directory.
        MkDir("C:\TESTDIR")
        ' </snippet38>
    End Sub

End Class

Class Class85d3f18269924f2bbaf17eb25e63b5fa
    ' 85d3f182-6992-4f2b-baf1-7eb25e63b5fa
    ' ChDir Function

    Public Sub Method39()
        ' <snippet39>
        ChDir("D:\TMP")
        ' </snippet39>
    End Sub

    Public Sub Method40()
        ' <snippet40>
        ChDir("..") ' Moves up one directory.
        ' </snippet40>
    End Sub

    Public Sub Method41()
        ' <snippet41>
        ' Change current directory or folder to "MYDIR".
        ChDir("MYDIR")

        ' Assume "C:" is the current drive. The following statement changes
        ' the default directory on drive "D:". "C:" remains the current drive.
        ChDir("D:\WINDOWS\SYSTEM")
        ' </snippet41>
    End Sub

End Class

Class Class9045d32008404af991a27cbcb5d8e971
    ' 9045d320-0840-4af9-91a2-7cbcb5d8e971
    ' FilePut Function

    ' <snippet42>
    Structure Person
        Public ID As Integer
        Public Name As String
    End Structure

    Sub WriteData()
        Dim PatientRecord As Person
        Dim recordNumber As Integer
        '    Open file for random access.
        FileOpen(1, "C:\TESTFILE.txt", OpenMode.Binary)
        ' Loop 5 times.
        For recordNumber = 1 To 5
            ' Define ID.
            PatientRecord.ID = recordNumber
            ' Create a string.
            PatientRecord.Name = "Name " & recordNumber
            ' Write record to file.
            FilePut(1, PatientRecord)
        Next recordNumber
        FileClose(1)
    End Sub
    ' </snippet42>

    Public Sub Method43()
        ' <snippet43>
        Dim MyArray(4, 9) As Integer
        ' </snippet43>
    End Sub

    Public Sub Method44()
        ' <snippet44>
        Dim hellow As String = "Hello World"
        FilePut(1, hellow)
        ' </snippet44>
    End Sub

End Class

Class Class921c78db83274a058ea0008091637cb1
    ' 921c78db-8327-4a05-8ea0-008091637cb1
    ' DeleteSetting Function

    Public Sub Method45()
        ' <snippet45>
        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        ' Remove section and all its settings from registry.
        DeleteSetting("MyApp", "Startup")
        ' Remove MyApp from the registry.
        DeleteSetting("MyApp")
        ' </snippet45>
    End Sub

End Class

Class Class9cba04cb8459444791f03038d5471e86
    ' 9cba04cb-8459-4447-91f0-3038d5471e86
    ' FileAttr Function

    Public Sub Method46()
        ' <snippet46>
        Dim mode As OpenMode
        FileOpen(1, "c:\TESTFILE.TXT", OpenMode.Input)
        mode = FileAttr(1)
        MsgBox("The file mode is " & mode.ToString())
        FileClose(1)
        ' </snippet46>
    End Sub

End Class

Class Class9ed3ccc23d9746eba40ee12179d14e1d
    ' 9ed3ccc2-3d97-46eb-a40e-e12179d14e1d
    ' Seek Function


    ' <snippet47>
    Structure Record   ' Define user-defined type.
        Dim ID As Integer
        Dim Name As String
    End Structure
    ' </snippet47>


    Public Sub Method48()
        Dim MyRecord As System.ValueType
        MyRecord = Nothing
        ' <snippet48>  
        FileOpen(1, "TESTFILE", OpenMode.Random)
        Do While Not EOF(1)
            WriteLine(1, Seek(1))   ' Write record number.
            FileGet(1, MyRecord, -1)   ' Read next record.
        Loop
        FileClose(1)
        ' </snippet48>
    End Sub

    Public Sub Method49()
        ' <snippet49>
        ' Report character position at beginning of each line.
        Dim TextLine As String
        FileOpen(1, "TESTFILE", OpenMode.Input)   ' Open file for reading.
        While Not EOF(1)
            ' Read next line.
            TextLine = LineInput(1)
            ' Position of next line.
            MsgBox(Seek(1))
        End While
        FileClose(1)
        ' </snippet49>
    End Sub


    ' <snippet50>
    Structure TestRecord
        Dim Name As String
        Dim ID As Integer
    End Structure
    ' </snippet50>




    Public Sub Method52()
        ' <snippet52>
        Dim someText As String = "This is a test string."
        ' Open file for output.
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Move to the third character.
        Seek(1, 3)
        Input(1, someText)
        Console.WriteLine(someText)
        FileClose(1)
        ' </snippet52>
    End Sub

End Class

Class Class9f0b792d295d44509392819c3003ad81
    ' 9f0b792d-295d-4450-9392-819c3003ad81
    ' Print, PrintLine Functions

    Public Sub Method53()
        ' <snippet53>
        FileOpen(1, "c:\trash.txt", OpenMode.Output)   ' Open file for output.
        Print(1, "This is a test.")   ' Print text to file.
        PrintLine(1)   ' Print blank line to file.
        PrintLine(1, "Zone 1", TAB(), "Zone 2")   ' Print in two print zones.
        PrintLine(1, "Hello", "World")   ' Separate strings with a tab.
        PrintLine(1, SPC(5), "5 leading spaces ")   ' Print five leading spaces.
        PrintLine(1, TAB(10), "Hello")   ' Print word at column 10.

        ' Assign Boolean, Date, and Error values.
        Dim aBool As Boolean
        Dim aDate As DateTime
        aBool = False
        aDate = DateTime.Parse("February 12, 1969")

        ' Dates and booleans are translated using locale settings of your system.
        PrintLine(1, aBool, " is a Boolean value")
        PrintLine(1, aDate, " is a date")
        FileClose(1)   ' Close file.
        ' </snippet53>
    End Sub

End Class

Class Classa0f52a1c5ecc4945b18c03147af61d6b
    ' a0f52a1c-5ecc-4945-b18c-03147af61d6b
    ' FilePutObject Function

    ' <snippet54>
    Sub WriteData()
        Dim text As String = "test"
        FileOpen(1, "test.bin", OpenMode.Binary)
        FilePutObject(1, text)
        FileClose(1)
    End Sub
    ' </snippet54>

End Class

Class Classa53e2c3f42ab4cda9ef43211acb0e60e
    ' a53e2c3f-42ab-4cda-9ef4-3211acb0e60e
    ' FreeFile Function

    Public Sub Method55()
        ' <snippet55>
        Dim count As Integer
        Dim fileNumber As Integer
        For count = 1 To 5
            fileNumber = FreeFile()
            FileOpen(fileNumber, "TEST" & count & ".TXT", OpenMode.Output)
            PrintLine(fileNumber, "This is a sample.")
            FileClose(fileNumber)
        Next
        ' </snippet55>
    End Sub

End Class

Class Classa9c0e6fab67e4875981f5100620806fb
    ' a9c0e6fa-b67e-4875-981f-5100620806fb
    ' SaveSetting Function

    Public Sub Method56()
        ' <snippet56>
        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        ' Remove Startup section and all its settings from registry.
        DeleteSetting("MyApp", "Startup")
        ' Remove MyApp from the registry.
        DeleteSetting("MyApp")
        ' </snippet56>
    End Sub

End Class

Class Classbd0183cbf31949da857ae05db8874d8d
    ' bd0183cb-f319-49da-857a-e05db8874d8d
    ' Command Function


    ' <snippet58>
    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Interaction.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function
    ' </snippet58>

End Class

Class Classc1918dd251d6412d86e8adef5f0dba1e
    ' c1918dd2-51d6-412d-86e8-adef5f0dba1e
    ' Beep Function

    Public Sub Method59()
        ' <snippet59>
        ' Sound a tone.
        Beep()
        ' </snippet59>
    End Sub

End Class

Class Classc2aaee4bbb444795899a3cb6d922f19e
    ' c2aaee4b-bb44-4795-899a-3cb6d922f19e
    ' Kill Function

    Public Sub Method60()
        ' <snippet60>
        ' Assume TESTFILE is a file containing some data.
        Kill("TestFile")   ' Delete file.

        ' Delete all *.TXT files in current directory.
        Kill("*.TXT")
        ' </snippet60>
    End Sub

End Class

Class Classc67c596bf93e487a892098b065775447
    ' c67c596b-f93e-487a-8920-98b065775447
    ' GetSetting Function

    Public Sub Method61()
        ' <snippet61>
        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        Console.WriteLine(GetSetting("MyApp", "Startup", "Left", "25"))
        DeleteSetting("MyApp")
        ' </snippet61>
    End Sub

End Class

Class Classca3deb55b6904ca088eb5936c2475ecb
    ' ca3deb55-b690-4ca0-88eb-5936c2475ecb
    ' EOF Function

    Public Sub Method62()
        ' <snippet62>
        Dim TextLine As String
        ' Open file.
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Loop until end of file.
        Do Until EOF(1)
            ' Read the line into a variable.
            TextLine = LineInput(1)
            ' Display the line in a message box.
            MsgBox(TextLine)
        Loop
        FileClose(1)
        ' </snippet62>
    End Sub

End Class

Class Classd06c20ec71d445b5b34e9d68cdc6f593
    ' d06c20ec-71d4-45b5-b34e-9d68cdc6f593
    ' Write, WriteLine Functions

    Public Sub Method63()
        ' <snippet63>
        Dim x As String = "Double quotation marks aren't ""difficult"" to handle."
        ' </snippet63>
    End Sub

    Public Sub Method64()
        ' <snippet64>
        ' Open file for output.
        FileOpen(1, "TestFile.txt", OpenMode.Output)
        ' Print text to the file. The quotation marks will be in the display.
        Write(1, "This is a test.")
        ' Go to the next line.
        WriteLine(1)
        ' Skip a line.
        WriteLine(1)
        ' Print in two print zones. You will see commas and quotation marks
        ' in the output file.
        WriteLine(1, "Zone 1", SPC(10), "Zone 2")
        ' Build a longer string before calling WriteLine.
        WriteLine(1, "Hello" & "  " & "World")
        ' Include five leading spaces.
        WriteLine(1, SPC(5), "Leading spaces")
        ' Print a word starting at column 10.
        WriteLine(1, TAB(10), "Hello")

        ' Assign Boolean and Date values.
        Dim aBool As Boolean
        Dim aDate As DateTime
        aBool = False
        aDate = DateTime.Parse("February 12, 1969")

        ' Dates and Booleans are translated using locale settings of 
        ' your system.
        WriteLine(1, aBool & " is a Boolean value.")
        WriteLine(1, aDate & " is a date.")
        ' Close the file.
        FileClose(1)

        ' Contents of TestFile.txt
        '"This is a test.",
        '
        '"Zone 1",          "Zone 2"
        '"Hello  World"
        '     "Leading spaces"
        '         ,"Hello"
        '"False is a Boolean value."
        '"2/12/1969 is a date."
        ' </snippet64>
    End Sub
End Class

Class Classd749c230795a43bf8949a466cc8aae4f
    ' d749c230-795a-43bf-8949-a466cc8aae4f
    ' CurDir Function

    Public Sub Method65()
        ' <snippet65>
        ' Assume current path on C drive is "C:\WINDOWS\SYSTEM".
        ' Assume current path on D drive is "D:\EXCEL".
        ' Assume C is the current drive.
        Dim MyPath As String
        MyPath = CurDir()   ' Returns "C:\WINDOWS\SYSTEM".
        MyPath = CurDir("C"c)   ' Returns "C:\WINDOWS\SYSTEM".
        MyPath = CurDir("D"c)   ' Returns "D:\EXCEL".
        ' </snippet65>
    End Sub

End Class

Class Classd8deeeb283534d1e8674f4e3d6207aa4
    ' d8deeeb2-8353-4d1e-8674-f4e3d6207aa4
    ' GetException Function

    Public Sub Method66()
        ' <snippet66>
        On Error Resume Next
        Dim myError As System.Exception
        ' Generate an overflow exception.
        Err.Raise(6)
        ' Assigns the exception from the Err object to myError.
        myError = Err.GetException()
        ' Displays the message associated with the exception.
        MsgBox(myError.Message)
        ' </snippet66>
    End Sub

End Class

Class Classe5ec95bfb33c4110aa34121d1599b4aa
    ' e5ec95bf-b33c-4110-aa34-121d1599b4aa
    ' InputBox Function (Visual Basic)

    Public Sub Method67()
        ' <snippet67>
        Dim message, title, defaultValue As String
        Dim myValue As Object
        ' Set prompt.
        message = "Enter a value between 1 and 3"
        ' Set title.
        title = "InputBox Demo"
        defaultValue = "1"   ' Set default value.

        ' Display message, title, and default value.
        myValue = InputBox(message, title, defaultValue)
        ' If user has clicked Cancel, set myValue to defaultValue
        If myValue Is "" Then myValue = defaultValue

        ' Display dialog box at position 100, 100.
        myValue = InputBox(message, title, defaultValue, 100, 100)
        ' If user has clicked Cancel, set myValue to defaultValue
        If myValue Is "" Then myValue = defaultValue
        ' </snippet67>
    End Sub

End Class

Class Classe9b01977713b484ea500d3e32150bacc
    ' e9b01977-713b-484e-a500-d3e32150bacc
    ' GetAllSettings Function

    Public Sub Method68()
        ' <snippet68>
        ' Object to hold 2-dimensional array returned by GetAllSettings.
        ' Integer to hold counter.
        Dim MySettings(,) As String
        Dim intSettings As Integer
        ' Place some settings in the registry.
        SaveSetting("MyApp", "Startup", "Top", "75")
        SaveSetting("MyApp", "Startup", "Left", "50")
        ' Retrieve the settings.
        MySettings = GetAllSettings("MyApp", "Startup")
        For intSettings = LBound(MySettings, 1) To UBound(MySettings, 1)
            WriteLine(1, MySettings(intSettings, 0))
            WriteLine(1, MySettings(intSettings, 1))
        Next intSettings
        DeleteSetting("MyApp")
        ' </snippet68>
    End Sub

End Class

Class Classf307b39fa9964ff6ab13e0b05ea5ab91
    ' f307b39f-a996-4ff6-ab13-e0b05ea5ab91
    ' FileClose Function

    Public Sub Method69()
        ' <snippet69>
        Dim TextLine As String
        FileOpen(1, "TESTFILE", OpenMode.Input)   ' Open file.
        Do While Not EOF(1)   ' Loop until end of file.
            TextLine = LineInput(1)   ' Read line into variable.
            MsgBox(TextLine)   ' Display the line
        Loop
        FileClose(1)   ' Close file.
        ' </snippet69>
    End Sub

End Class


