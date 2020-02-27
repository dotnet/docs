<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB" Assembly="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - VB Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <asp:gridview
          id="GridView1"
          runat="server"
          datasourceid="ObjectDataSource1" />

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          typename="Samples.AspNet.VB.EmployeeLogic"
          selectmethod="GetAllEmployeesAsDataSet"
          enablecaching="True"
          cacheduration="30"
          cacheexpirationpolicy="Absolute" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->