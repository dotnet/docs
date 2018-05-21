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