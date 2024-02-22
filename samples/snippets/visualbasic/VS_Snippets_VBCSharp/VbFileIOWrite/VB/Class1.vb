Class Class1c726124781d49769baaed46814ff3fe
    ' HowtoWriteTextToFilesInMyDocuments(VisualBasic)

    Public Sub Method1()
        ' <snippet1>
        Dim filePath As String
        filePath = System.IO.Path.Combine(
        My.Computer.FileSystem.SpecialDirectories.MyDocuments, "test.txt")
        ' </snippet1>
    End Sub

    Public Sub Method2()
        ' <snippet2>
        Try
            Dim filePath As String
            filePath = System.IO.Path.Combine(
                       My.Computer.FileSystem.SpecialDirectories.MyDocuments, "test.txt")
            My.Computer.FileSystem.WriteAllText(filePath, "some text", False)
        Catch fileException As Exception
            Throw fileException
        End Try
        ' </snippet2>
    End Sub

End Class

Class Class304956eb530d4df7b48f9b4d1f2581a0
    ' HowtoWriteTextToFilesInVisualBasic

    Public Sub Method3()
        ' <snippet3>
        My.Computer.FileSystem.WriteAllText("C:\TestFolder1\test.txt",
        "This is new text to be added.", True)
        ' </snippet3>
    End Sub

    Public Sub Method4()
        ' <snippet4>
        For Each foundFile As String In
        My.Computer.FileSystem.GetFiles("C:\Documents and Settings")
            foundFile = foundFile & vbCrLf
            My.Computer.FileSystem.WriteAllText(
              "C:\Documents and Settings\FileList.txt", foundFile, True)
        Next
        ' </snippet4>
    End Sub

End Class

Class Class99762e57ef464dcc8959a8f79c22f067
    ' HowtoWriteTextToAFileWithAStreamWriter(VisualBasic)

    Public Sub Method5()
        ' <snippet5>
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("c:\test.txt", True)
        file.WriteLine("Here is the first string.")
        file.Close()
        ' </snippet5>
    End Sub

End Class

Class Classbbbd7fb5f16941a9b53f520ea9613913
    ' HowtoAppendToATextFile(VisualBasic)

    Public Sub Method6()
        ' <snippet6>
        Dim inputString As String = "This is a test string."
        My.Computer.FileSystem.WriteAllText(
          "C://testfile.txt", inputString, True)
        ' </snippet6>
    End Sub

End Class


