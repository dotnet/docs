        Dim vowelNames2 = From student In students
                          Join vowel In vowels
                          On student.Last(0) Equals vowel
                          Select Name = student.First & " " &
                          student.Last, Initial = vowel
                          Order By Initial