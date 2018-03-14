<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

void Page_Load(Object sender, EventArgs e){
  // These cookies might be added by a login form.
  // They are added here for simplicity.
  if (!IsPostBack) {
    Response.Cookies.Add(new HttpCookie("lname",    "davolio"));
    Response.Cookies.Add(new HttpCookie("loginname","ndavolio"));
    Response.Cookies.Add(new HttpCookie("lastvisit", DateTime.Now.ToString()));

// <Snippet2>
    // You can programmatically add a CookieParameter to the
    // SqlDataSource control's SelectParameters collection.
    CookieParameter cookieParam = new CookieParameter("lastname",TypeCode.String,"lname");
    SqlDataSource1.SelectParameters.Add(cookieParam);
// </Snippet2>
  }
}

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
          SelectCommand = "SELECT OrderID,CustomerID,OrderDate,RequiredDate,ShippedDate
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