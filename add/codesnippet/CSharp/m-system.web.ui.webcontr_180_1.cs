        // In this example, the session parameter "empid" is set
        // after the employee successfully logs in.
        SessionParameter empid = new SessionParameter();
        empid.Name = "empid";
        empid.Type = TypeCode.Int32;
        empid.SessionField = "empid";