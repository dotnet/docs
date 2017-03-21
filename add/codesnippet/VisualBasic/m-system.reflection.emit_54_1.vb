            Dim t1 As Type = tbldr.MakeGenericType(GetType(String))
            Dim t2 As Type = tbldr.MakeGenericType(GetType(String))
            Dim result As Boolean = t1.Equals(t2)