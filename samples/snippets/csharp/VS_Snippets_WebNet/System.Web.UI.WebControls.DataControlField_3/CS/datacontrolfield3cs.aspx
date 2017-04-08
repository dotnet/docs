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
    <asp:sqldatasource
      id="SqlDataSource1"
      runat="server"
      connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
      selectcommand="SELECT EmployeeID, FirstName, LastName, Title, Region FROM Employees">
    </asp:sqldatasource>

    <asp:gridview
      id="GridView1"
      runat="server"
      allowpaging="True"
      datasourceid="SqlDataSource1"
      allowsorting="True"
      width="472px">
        <columns>

          <asp:buttonfield
            headerimageurl="http://www.microsoft.com/homepage/gif/bnr-microsoft.gif"
            text="ClickMe"
            showheader="True"
            buttontype="Button">
          </asp:buttonfield>

        <asp:hyperlinkfield
          target="http://msdn.microsoft.com/"
          headertext="Link To Info"
          text="MyLink">
            <headerstyle backcolor="Yellow">
            </headerstyle>
        </asp:hyperlinkfield>

      </columns>
    </asp:gridview>

  </form>
</body>
</html>
<!-- </Snippet1> -->