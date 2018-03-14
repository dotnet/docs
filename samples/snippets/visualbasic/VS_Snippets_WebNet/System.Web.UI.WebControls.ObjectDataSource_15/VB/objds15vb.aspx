<!-- <Snippet1> -->
<%@ Import namespace="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
Private Sub NorthwindLogicCreating(sender As Object, e As ObjectDataSourceEventArgs)

    ' Create an instance of the business object using a non-default constructor.
    Dim eLogic As EmployeeLogic = New EmployeeLogic("Not created by the default constructor!")
    
    ' Set the ObjectInstance property so that the ObjectDataSource uses the created instance.
    e.ObjectInstance = eLogic
    
End Sub ' NorthwindLogicCreating

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - VB Example</title>
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
          typename="Samples.AspNet.VB.EmployeeLogic" >
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->