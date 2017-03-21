        Dim fileName As String = "C:\TMP\log.txt"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If

        Console.WriteLine("{0} has a directoryName of {1}", fileName, fileInfo.DirectoryName)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\TMP\log.txt has a directory name of C:\TMP