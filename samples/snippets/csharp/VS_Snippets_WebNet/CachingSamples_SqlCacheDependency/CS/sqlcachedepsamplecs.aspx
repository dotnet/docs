<%--<snippet1>--%>
<%@ Page Language="C#" Debug="true" %>
<%@ import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
// <snippet2>
    public void Page_Load(object Src, EventArgs E) 
    { 
        // Declare the SqlCacheDependency instance, SqlDep. 
        SqlCacheDependency SqlDep = null; 
        
        // Check the Cache for the SqlSource key. 
        // If it isn't there, create it with a dependency 
        // on a SQL Server table using the SqlCacheDependency class. 
        if (Cache["SqlSource"] == null) { 
            
            // Because of possible exceptions thrown when this 
            // code runs, use Try...Catch...Finally syntax. 
            try { 
                // Instantiate SqlDep using the SqlCacheDependency constructor. 
                SqlDep = new SqlCacheDependency("Northwind", "Categories"); 
            } 
            
            // Handle the DatabaseNotEnabledForNotificationException with 
            // a call to the SqlCacheDependencyAdmin.EnableNotifications method. 
            catch (DatabaseNotEnabledForNotificationException exDBDis) { 
                try { 
                    SqlCacheDependencyAdmin.EnableNotifications("Northwind"); 
                } 
                
                // If the database does not have permissions set for creating tables, 
                // the UnauthorizedAccessException is thrown. Handle it by redirecting 
                // to an error page. 
                catch (UnauthorizedAccessException exPerm) { 
                    Response.Redirect(".\\ErrorPage.htm"); 
                } 
            } 
            
            // Handle the TableNotEnabledForNotificationException with 
            // a call to the SqlCacheDependencyAdmin.EnableTableForNotifications method. 
            catch (TableNotEnabledForNotificationException exTabDis) { 
                try { 
                    SqlCacheDependencyAdmin.EnableTableForNotifications("Northwind", "Categories"); 
                } 
                
                // If a SqlException is thrown, redirect to an error page. 
                catch (SqlException exc) { 
                    Response.Redirect(".\\ErrorPage.htm"); 
                } 
            } 
            
            // If all the other code is successful, add MySource to the Cache 
            // with a dependency on SqlDep. If the Categories table changes, 
            // MySource will be removed from the Cache. Then generate a message 
            // that the data is newly created and added to the cache. 
            finally { 
                Cache.Insert("SqlSource", Source1, SqlDep); 
                CacheMsg.Text = "The data object was created explicitly."; 
                
            } 
        } 
        
        else { 
            CacheMsg.Text = "The data was retrieved from the Cache."; 
        } 
    } 
// </snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
        </p>
        <p>
            <asp:SqlDataSource id="Source1" runat="server" SelectCommand="SELECT * FROM [Categories]" UpdateCommand="UPDATE [Categories] SET [CategoryName]=@CategoryName,[Description]=@Description,[Picture]=@Picture WHERE [CategoryID]=@CategoryID" ConnectionString="<%$ ConnectionStrings:Northwind %>"></asp:SqlDataSource>
            <asp:GridView id="GridView1" runat="server" DataKeyNames="CategoryID" AllowSorting="True" AllowPaging="True" DataSourceID="Source1"></asp:GridView>
        </p>
        <p>
        </p>
        <p>
            <asp:Label id="CacheMsg" runat="server" AssociatedControlID="GridView1"></asp:Label>
        </p>
   </form>
</body>
</html>
<%--</snippet1>--%>