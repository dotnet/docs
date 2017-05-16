<!-- <Snippet1> -->
<%@ Import namespace="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
private void NorthwindLogicCreating(object sender, ObjectDataSourceEventArgs e)
{
    // Create an instance of the business object using a non-default constructor.
    EmployeeLogic eLogic = new EmployeeLogic("Not created by the default constructor!");
    
    // Set the ObjectInstance property so that the ObjectDataSource uses the created instance.
    e.ObjectInstance = eLogic;
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <asp:gridview
          id="GridView1"
          runat="server"
          datasourceid="ObjectDataSource1">
        </asp:gridview>

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetAllEmployees"
          onobjectcreating="NorthwindLogicCreating"
          typename="Samples.AspNet.CS.EmployeeLogic" >
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->