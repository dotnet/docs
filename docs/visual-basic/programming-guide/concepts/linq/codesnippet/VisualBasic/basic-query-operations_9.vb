        Dim vowels() As String = {"A", "E", "I", "O", "U"}
        Dim vowelNames = From student In students, vowel In vowels
                         Where student.Last.IndexOf(vowel) = 0
                         Select Name = student.First & " " &
                         student.Last, Initial = vowel
                         Order By Initial

        For Each vName In vowelNames
            Console.WriteLine(vName.Initial & ":  " & vName.Name)
        Next