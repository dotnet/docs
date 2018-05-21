        Dim seniorsQuery = From stdnt In students
                           Where stdnt.Year = "Senior"
                           Select stdnt