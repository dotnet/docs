<!-- <Snippet1> -->
<%@ page language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">

    <asp:sqldatasource
      id="SqlDataSource1"
      runat="server"
      connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
      selectcommand="Select * From Employees">
    </asp:sqldatasource>

    <asp:detailsview
      id="DetailsView1"
      runat="server"
      allowpaging="True"
      datasourceid="SqlDataSource1"
      height="208px"
      width="264px"
      autogeneraterows="False">
        <fields>

          <asp:boundfield
            sortexpression="LastName"
            datafield="LastName"
            headertext="LastName">
              <itemstyle backcolor="Yellow">
              </itemstyle>
          </asp:boundfield>

          <asp:boundfield
            sortexpression="FirstName"
            datafield="FirstName"
            headertext="FirstName">
              <itemstyle forecolor="#C00000">
              </itemstyle>
          </asp:boundfield>

          <asp:buttonfield
            text="TestButton"
            buttontype="Button">
          </asp:buttonfield>

        </fields>
    </asp:detailsview>

  </form>
</body>
</html>
<!-- </Snippet1> -->