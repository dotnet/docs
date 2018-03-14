<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB" Assembly="Samples.AspNet.VB" %>
<%@ Import namespace="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
Private Sub NorthwindEmployeeInserting(source As Object, e As ObjectDataSourceMethodEventArgs)

  ' The GridView control passes an array of strings in the parameters
  ' collection because that is the type it knows how to work with.
  ' However, the business object expects a custom type. Build it
  ' and add it to the parameters collection.
  Dim paramsFromPage As IDictionary = e.InputParameters

  Dim ne As New NorthwindEmployee()
  ne.FirstName  = paramsFromPage("FirstName").ToString()
  ne.LastName   = paramsFromPage("LastName").ToString()
  ne.Title      = paramsFromPage("Title").ToString()
  ne.Courtesy   = paramsFromPage("Courtesy").ToString()
  ne.Supervisor = Int32.Parse(paramsFromPage("Supervisor").ToString())
  
  paramsFromPage.Clear()
  paramsFromPage.Add("ne", ne)
End Sub ' NorthwindEmployeeInserting

</script>
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
          datasourceid="ObjectDataSource1">
        </asp:detailsview>

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetEmployee"
          insertmethod="UpdateEmployeeInfo"
          oninserting="NorthwindEmployeeInserting"
          typename="Samples.AspNet.VB.EmployeeLogic" >
          <selectparameters>
            <asp:parameter name="anID" defaultvalue="-1" />
          </selectparameters>
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->