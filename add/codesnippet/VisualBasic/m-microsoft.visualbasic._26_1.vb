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