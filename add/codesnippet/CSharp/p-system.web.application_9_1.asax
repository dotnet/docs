    void Application_Start(object sender, EventArgs e) 
    {
        System.Web.ApplicationServices.RoleService.SelectingProvider += 
            new EventHandler<System.Web.ApplicationServices.SelectingProviderEventArgs>(RoleService_SelectingProvider);
    }

    void RoleService_SelectingProvider
        (object sender, System.Web.ApplicationServices.SelectingProviderEventArgs e)
    {
        if (e.User.Identity.Name.IndexOf("@example.com") > 0)
        {
            e.ProviderName = "EmployeeRoleProvider";
        }
        else
        {
            e.ProviderName = "CustomerRoleProvider";
        }
    }