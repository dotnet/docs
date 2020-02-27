<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:detailsview
      id="DetailsView1"
      runat="server"
      allowpaging="True"
      datasourceid="SqlDataSource1"
      autogeneraterows="False"
      width="312px"
      height="152px">
        <fields>
          <asp:boundfield
            visible="False"
            sortexpression="EmployeeID"
            datafield="EmployeeID">
          </asp:boundfield>

          <asp:boundfield
            sortexpression="LastName"
            datafield="LastName"
            headertext="LastName">
          </asp:boundfield>

          <asp:boundfield
            sortexpression="FirstName"
            datafield="FirstName"
            headertext="FirstName">
          </asp:boundfield>

          <asp:boundfield
            sortexpression="Title"
            datafield="Title"
            headertext="Title">
          </asp:boundfield>

          <asp:buttonfield text="Button">
            <controlstyle font-bold="True" forecolor="Red" />
          </asp:buttonfield>
        </fields>
    </asp:detailsview>

    <asp:sqldatasource
      id="SqlDataSource1"
      runat="server"
      selectcommand="SELECT * FROM Employees"
      connectionstring="<%$ ConnectionStrings:MyNorthwind%>">
    </asp:sqldatasource>

  </form>
</body>
</html>
<!-- </Snippet1> -->