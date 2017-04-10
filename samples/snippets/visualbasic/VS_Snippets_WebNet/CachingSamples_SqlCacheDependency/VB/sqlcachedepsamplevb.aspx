<%--<snippet1>--%>
<%@ Page Language="VB" Debug="True" %>
<%@ import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
' <snippet2>
    Sub Page_Load(Src As Object, E As EventArgs)
       ' Declare the SqlCacheDependency instance, SqlDep.
       Dim SqlDep As SqlCacheDependency

       ' Check the Cache for the SqlSource key.
       ' If it isn't there, create it with a dependency
       ' on a SQL Server table using the SqlCacheDependency class.
       If Cache("SqlSource") Is Nothing

          ' Because of possible exceptions thrown when this
          ' code runs, use Try...Catch...Finally syntax.
          Try
             ' Instantiate SqlDep using the SqlCacheDependency constructor.
             SqlDep = New SqlCacheDependency("Northwind", "Categories")

          ' Handle the DatabaseNotEnabledForNotificationException with
          ' a call to the SqlCacheDependencyAdmin.EnableNotifications method.
          Catch exDBDis As DatabaseNotEnabledForNotificationException
             Try
                SqlCacheDependencyAdmin.EnableNotifications("Northwind")

             ' If the database does not have permissions set for creating tables,
             ' the UnauthorizedAccessException is thrown. Handle it by redirecting
             ' to an error page.
             Catch exPerm As UnauthorizedAccessException
                 Response.Redirect(".\ErrorPage.htm")
             End Try

          ' Handle the TableNotEnabledForNotificationException with
                ' a call to the SqlCacheDependencyAdmin.EnableTableForNotifications method.
          Catch exTabDis As TableNotEnabledForNotificationException
             Try
                SqlCacheDependencyAdmin.EnableTableForNotifications( _
                 "Northwind", "Categories")

             ' If a SqlException is thrown, redirect to an error page.
             Catch exc As SqlException
                 Response.Redirect(".\ErrorPage.htm")
             End Try

          ' If all the other code is successful, add MySource to the Cache
          ' with a dependency on SqlDep. If the Categories table changes,
          ' MySource will be removed from the Cache. Then generate a message
                ' that the data is newly created and added to the cache.
          Finally
             Cache.Insert("SqlSource", Source1, SqlDep)
                CacheMsg.Text = "The data object was created explicitly."

          End Try

        Else
           CacheMsg.Text = "The data was retrieved from the Cache."
        End If
    End Sub
' </snippet2>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
