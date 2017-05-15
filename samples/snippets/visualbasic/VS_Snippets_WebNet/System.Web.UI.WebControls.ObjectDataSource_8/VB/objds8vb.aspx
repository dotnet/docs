<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB" Assembly="Samples.AspNet.VB" %>
<%@ Import namespace="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - VB Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <asp:detailsview
          id="DetailsView1"
          runat="server"
          autogenerateinsertbutton="True"
          autogeneraterows="false"
          datasourceid="ObjectDataSource1"
          defaultmode="Insert" >
          <fields>
            <asp:BoundField headertext="FirstName" datafield="FirstName" />
            <asp:BoundField headertext="LastName"   datafield="LastName" />
            <asp:BoundField headertext="Title"      datafield="Title" />
            <asp:BoundField headertext="Courtesy"   datafield="Courtesy" />
            <asp:BoundField headertext="Supervisor" datafield="Supervisor" />
          </fields>
        </asp:detailsview>

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetEmployee"
          insertmethod="InsertNewEmployeeWrapper"
          typename="Samples.AspNet.VB.EmployeeLogic" >
          <selectparameters>
            <asp:parameter name="anID" defaultvalue="-1" />
          </selectparameters>
          <insertparameters>
            <asp:parameter name="Supervisor" type="Int32" />
          </insertparameters>
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->