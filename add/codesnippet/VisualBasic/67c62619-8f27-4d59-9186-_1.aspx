        Dim rg As New RoleGroup
        rg.ContentTemplate = New CustomTemplate
        Dim RoleList(1) As String
        RoleList(0) = "users"

        rg.Roles = RoleList

        Dim rgc As RoleGroupCollection = LoginView1.RoleGroups
        rgc.Add(rg)