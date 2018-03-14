<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB" Assembly="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Protected Sub ObjectDataSource1_Filtering(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceFilteringEventArgs)
        If Textbox1.Text = "" Then
            e.ParameterValues.Clear()
            e.ParameterValues.Add("FullName", "Nancy Davolio")
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - VB Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <p>Show all users with the following name.</p>

        <asp:textbox id="Textbox1" runat="server" text="Nancy Davolio" />

        <asp:gridview
          id="GridView1"
          runat="server"
          datasourceid="ObjectDataSource1"
          autogeneratecolumns="False">
          <columns>
            <asp:boundfield headertext="ID" datafield="EmpID" />
            <asp:boundfield headertext="Name" datafield="FullName" />
            <asp:boundfield headertext="Street Address" datafield="Address" />
          </columns>
        </asp:gridview>

        <!-- Security Note: The ObjectDataSource uses a FormParameter,
             Security Note: which does not perform validation of input from the client. -->

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetAllEmployeesAsDataSet"
          typename="Samples.AspNet.VB.EmployeeLogic"
          filterexpression="FullName='{0}'" OnFiltering="ObjectDataSource1_Filtering">
            <filterparameters>
              <asp:formparameter name="FullName" formfield="Textbox1" defaultvalue="Nancy Davolio" />
            </filterparameters>
        </asp:objectdatasource>

        <p><asp:button id="Button1" runat="server" text="Search" /></p>

    </form>
  </body>
</html>
<!-- </Snippet1> -->