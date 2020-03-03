

<%@ Application Language="C#" %>

<script RunAt="server">

    //    <snippet1>
    
    void Application_Start(object sender, EventArgs e) {
        
        if (!Roles.RoleExists("Managers")) {
            Roles.CreateRole("Managers");
        }
        if (!Roles.RoleExists("Friends")) {
            Roles.CreateRole("Friends");
        }
    }

    //  </snippet1> 
</script>

