<%@ Page Language="VB" Debug="True" %>
<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Web.Caching" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Sub Page_Load(sender As Object, e As System.EventArgs)
    ' Declare the SqlCacheDependency instance, SqlDep.
    Dim SqlDep As SqlCacheDependency

    ' Check the Cache for the MySource key.
    ' If it isn't there, create it with a dependency
    ' on a SQL Server table using the SqlCacheDependency class.
    If Cache("MySource") Is Nothing

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
             ' Response.Redirect(".\ErrorPage.htm")
          End Try

       ' Handle the TableNotEnabledForNotificationException with
       ' a call to the SqlCacheDepenencyAdmin.EnableTableForNotifications method.
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
       ' that the data is newly created and  added to the cache.
       Finally
          Cache.Insert("MySource", Source1, SqlDep)
          CacheMsg.Text = "The data object was created explicity."

       End Try

     Else
        CacheMsg.Text = "The data was retrieved from the Cache."
     End If
End Sub

' <snippet1>
' Create a method to disable SqlCacheDependency
' change notifications for the Northwind database.
Public Sub DisableDatabase_Click( _
 sender As Object, e As System.EventArgs)

   SqlCacheDependencyAdmin.DisableNotifications( _
   "Northwind")
   Response.Write("Northwind database disabled at " _
   & DateTime.Now.ToString())

   ' An HttpException is thrown if adequate permissions to
   ' modify the database are not granted.

End Sub
' </snippet1>

' <snippet2>
' Create a method to enable an array of tables
' in the Northwind database for SqlCacheDependency
' change notifications.
Public Sub EnableTables_Click( _
 sender As Object, e As System.EventArgs)

  ' Create an string array of table names from
  ' the Northwind database.
  Dim Tables As String() = {"Categories", "Orders", "OrderDetails"}

  ' Enable the tables for notifications. If the database
  ' has not been enabled, call the EnableNotifications method.
  ' If permissions are not set, write that to the page.
  Try
     SqlCacheDependencyAdmin.EnableTableForNotifications( _
     "Northwind", "Tables")
  Catch ex2 As DatabaseNotEnabledForNotificationException

    ' Attempt to enable notifications.
    SqlCacheDependencyAdmin.EnableNotifications("Northwind")

   ' An HttpException is thrown if adequate permissions to
   ' modify the database are not granted.            

  End Try
End Sub
' </snippet2>

' <snippet3>
 ' Create a method that disables multiple tables
 ' for SqlCacheDependency change notifications.
 Public Sub DisableTables_Click( _
 sender As Object, e As EventArgs)

    ' Create a string array with table names
    ' from the Northwind database.
    Dim Tables1 As String() = {"Categories", "OrderDetails"}

    ' Attempt to disable the database.
    SqlCacheDependencyAdmin.DisableTableForNotifications( _
     "Northwind", "Tables1")

        ' An HttpException will be thrown if adequate permissions to
    ' modify the database are not granted.               

    Response.Write("You disabled the Categories and OrderDetails tables.")               
 End Sub
' </snippet3>

' <snippet4>
    ' Create a method to search for the Orders table
    ' among all tables enabled for change notifications 
    ' and specifically disable it.
 Public Sub DisableBtn_Click(sender As Object, e As EventArgs)
     ' Create string array and string variables.
     Dim EnabledTables As String()
     Dim EnabledTable As String

     ' Set string array to results from a
     ' GetTablesEnableForNotifications method call
     ' to the Northwind database.
     Try
       EnabledTables = _
         SqlCacheDependencyAdmin.GetTablesEnabledForNotifications( _
         "Northwind")
     Catch ex5 as HttpException
        Response.Write("The tables cannot be found.")
     End Try


     ' Search the strings in the array for the
     ' Orders table name. If it's found, disable
     ' that table and exit the loop. If it isn't,
        ' write a note to the page that the table was not found.
     For Each EnabledTable In EnabledTables
       If EnabledTable="Orders"
          SqlCacheDependencyAdmin.DisableTableForNotifications( _
           "Northwind", "Orders")
          ' An HttpException will be thrown if adequate permissions to
          ' modify the database are not granted.                     
          Response.Write("The Orders table has been disabled.")
        Exit For
       Else
         Response.Write("The Orders table was not in the array.")
       End If
     Next

 End Sub
' </snippet4>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Using the SqlCacheDependencyAdmin Class
        </p>
        <p>
        </p>
        <p>
            <asp:Button id="Button1" onclick="DisableDatabase_Click" runat="server" Text="Disable Database"></asp:Button>
        </p>
        <p>
        </p>
        <p>
            <asp:Button id="Button2" onclick="EnableTables_Click" runat="server" Text="Enable 3 Tables"></asp:Button>
        </p>
        <p>
        </p>
        <p>
            <asp:Button id="Button3" onclick="DisableTables_Click" runat="server" Text="Disable 2 Tables"></asp:Button>
        </p>
        <p>
        </p>
        <p>
            <asp:Button id="Button4" onclick="DisableBtn_Click" runat="server" Text="Disable Table"></asp:Button>
        </p>
        <p>
            <asp:SqlDataSource id="Source1" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>" UpdateCommand="UPDATE [Categories] SET [CategoryName]=@CategoryName,[Description]=@Description,[Picture]=@Picture WHERE [CategoryID]=@CategoryID" SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
            <asp:GridView id="GridView1" runat="server" DataSourceID="Source1" AllowPaging="True" AllowSorting="True" DataKeyNames="CategoryID"></asp:GridView>
        </p>
        <p>
        </p>
        <p>
            <asp:Label id="CacheMsg" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label id="CacheMsg1" runat="server"></asp:Label>
        </p>
        <p>
        </p>
    </form>
</body>
</html>
