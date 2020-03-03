<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <p><asp:dropdownlist
          id="DropDownList1"
          runat="server"
          autopostback="True">
          <asp:listitem selected="True">Sales Representative</asp:listitem>
          <asp:listitem>Sales Manager</asp:listitem>
          <asp:listitem>Vice President, Sales</asp:listitem>
      </asp:dropdownlist></p>

      <asp:sqldatasource
          id="SqlDataSource1"
          runat="server"
          connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
          selectcommand="SELECT LastName FROM Employees WHERE Title = @Title">
          <selectparameters>
              <asp:controlparameter name="Title" controlid="DropDownList1" propertyname="SelectedValue"/>
          </selectparameters>
      </asp:sqldatasource>

      <p><asp:listbox
          id="ListBox1"
          runat="server"
          datasourceid="SqlDataSource1"
          datatextfield="LastName">
      </asp:listbox></p>

    </form>
  </body>
</html>
<!-- </Snippet1> -->