        Dim path As String
        Dim patients As String
        path = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & "Patients.txt"
        patients = My.Computer.FileSystem.ReadAllText(path)