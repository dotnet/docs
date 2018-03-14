<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" Assembly="Samples.AspNet.CS" %>
<%@ Import namespace="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
private void NorthwindEmployeeInserting(object source, ObjectDataSourceMethodEventArgs e)
{
  // The business object expects a custom type. Build it
  // and add it to the parameters collection.
  
  IDictionary paramsFromPage = e.InputParameters;

  NorthwindEmployee ne = new NorthwindEmployee();

  ne.FirstName  = paramsFromPage["FirstName"].ToString();
  ne.LastName   = paramsFromPage["LastName"].ToString();
  ne.Title      = paramsFromPage["Title"].ToString();
  ne.Courtesy   = paramsFromPage["Courtesy"].ToString();
  ne.Supervisor = Int32.Parse(paramsFromPage["Supervisor"].ToString());

  paramsFromPage.Clear();
  paramsFromPage.Add("ne", ne);
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - C# Example</title>
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
          typename="Samples.AspNet.CS.EmployeeLogic"
          >
          <selectparameters>
            <asp:parameter name="anID" defaultvalue="-1" />
          </selectparameters>
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->