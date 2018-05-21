        Dim seniorsQuery2 = students.
            Where(Function(st) st.Year = "Senior").
            Select(Function(s) s)