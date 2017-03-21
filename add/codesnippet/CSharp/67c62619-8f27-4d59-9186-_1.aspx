        RoleGroup rg = new RoleGroup();
        rg.ContentTemplate = new CustomTemplate();
        String[] RoleList = {"users"};
        rg.Roles = RoleList;
        RoleGroupCollection rgc = LoginView1.RoleGroups;
        rgc.Add(rg);