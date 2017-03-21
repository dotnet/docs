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