        Dim empIdParam As New QueryStringParameter()
        empIdParam.Name = "empId"
        empIdParam.QueryStringField = "empId"

        AccessDataSource1.SelectParameters.Add(empIdParam)