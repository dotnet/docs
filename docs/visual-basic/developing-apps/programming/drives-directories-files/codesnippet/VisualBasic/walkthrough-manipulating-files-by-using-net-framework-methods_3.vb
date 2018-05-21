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