<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" Assembly="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <asp:detailsview
          id="DetailsView1"
          runat="server"
          datasourceid="ObjectDataSource1">
        </asp:detailsview>

<!-- Security Note: The ObjectDataSource uses a QueryStringParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the QueryStringParameter, handle the Selecting event. -->

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetEmployee"
          typename="Samples.AspNet.CS.EmployeeLogic" >
          <selectparameters>
            <asp:querystringparameter name="EmployeeID" querystringfield="empid" defaultvalue="-1" />
          </selectparameters>
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->