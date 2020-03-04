<!-- <Snippet1> -->
<%@Page  Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

Sub Page_Load(sender As Object, e As EventArgs)
  ' These cookies might be added by a login form.
  ' They are added here for simplicity.
  If (Not IsPostBack) Then
      Dim cookie As HttpCookie

      cookie = New HttpCookie("lname","davolio")
      Response.Cookies.Add(cookie)

      cookie = New HttpCookie("loginname","ndavolio")
      Response.Cookies.Add(cookie)

      cookie = New HttpCookie("lastvisit", DateTime.Now.ToString())
      Response.Cookies.Add(cookie)

' <Snippet2>
    ' You can  programmatically add a CookieParameter to the
    ' SqlDataSource control's SelectParameters collection.
    Dim cookieParam As New CookieParameter("lastname","lname")
    SqlDataSource1.SelectParameters.Add(cookieParam)
' </Snippet2>
  End If
End Sub ' Page_Load
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          DataSourceMode="DataSet"
          ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
          SelectCommand="SELECT OrderID,CustomerID,OrderDate,RequiredDate,ShippedDate
                          FROM Orders WHERE EmployeeID =
                          (SELECT EmployeeID FROM Employees WHERE LastName = @lastname)">
      </asp:SqlDataSource>

      <asp:GridView
          id="GridView1"
          runat="server"
          AllowSorting="True"
          DataSourceID="SqlDataSource1">
      </asp:GridView>

    </form>
  </body>
</html>
<!-- </Snippet1> -->