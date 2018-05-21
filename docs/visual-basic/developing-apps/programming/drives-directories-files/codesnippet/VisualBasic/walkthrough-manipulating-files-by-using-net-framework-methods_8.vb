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