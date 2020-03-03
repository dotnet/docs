<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
// Clicking the Submit button explicitly refreshes the data 
// by calling the Select() method.
private void Submit(Object source, EventArgs e) {
  SqlDataSource1.Select(DataSourceSelectArguments.Empty);
}

// This event handler is called after the Select() method is executed.
private void OnSelectedHandler(Object source, SqlDataSourceStatusEventArgs e) {

  IDbCommand cmd = e.Command; 
  
  Label1.Text = "Parameter return values: ";

  foreach (SqlParameter param in cmd.Parameters) {
    //  Extract the value of the parameter.
    Label1.Text += param.ParameterName + " - " + param.Value.ToString();
  }
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
<!-- <Snippet2> -->
        <asp:sqldatasource
            id="SqlDataSource1"
            runat="server"
            datasourcemode="DataSet"
            connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
            selectcommand="getordertotal"
            onselected="OnSelectedHandler">
            <selectparameters>
              <asp:querystringparameter name="empId" querystringfield="empId" />
              <asp:parameter name="total" type="Int32" direction="Output" defaultvalue="0" />
              <asp:parameter name="_ret" type="Int32" direction="ReturnValue" defaultvalue="0" />
            </selectparameters>
        </asp:sqldatasource>
<!-- </Snippet2> -->
        <!--
          CREATE PROCEDURE dbo.getordertotal
            @empId int,
            @total int OUTPUT
          as
            set nocount on
            select @total    = count(1) from orders where employeeid=@empid;
            select * from orders where employeeID = @empId ;
            return (-1000);
          GO
        -->

        <asp:gridview
          id="GridView1"
          runat="server"
          allowpaging="True"
          pagesize="5"
          datasourceid="SqlDataSource1" />

        <asp:button
          id="Button1"
          runat="server"
          onclick="Submit"
          text="Refresh Data" />

        <asp:label id="Label1" runat="server" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->