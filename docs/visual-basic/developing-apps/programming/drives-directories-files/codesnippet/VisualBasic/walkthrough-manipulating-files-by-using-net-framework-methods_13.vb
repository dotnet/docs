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