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