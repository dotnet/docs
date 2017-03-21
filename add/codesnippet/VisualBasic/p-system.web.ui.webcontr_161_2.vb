        ' In this example, the session parameter "empid" is set
        ' after the employee successfully logs in.
        Dim empid As New SessionParameter()
        empid.Name = "empid"
        empid.Type = TypeCode.Int32
        empid.SessionField = "empid"