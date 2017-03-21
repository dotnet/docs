    void Application_Start(object sender, EventArgs e) 
    {
        System.Web.ApplicationServices.ProfileService.ValidatingProperties += new EventHandler<System.Web.ApplicationServices.ValidatingPropertiesEventArgs>(ProfileService_ValidatingProperties);
    }

    void ProfileService_ValidatingProperties(object sender, System.Web.ApplicationServices.ValidatingPropertiesEventArgs e)
    {
        if (String.IsNullOrEmpty((string)e.Properties["FirstName"]))
        {
            e.FailedProperties.Add("FirstName");
        }
    }