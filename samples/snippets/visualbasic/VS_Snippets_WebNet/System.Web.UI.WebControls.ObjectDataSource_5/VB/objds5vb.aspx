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

        <p>Show all empoyees with the following title:
        <asp:dropdownlist
            id="DropDownList1"
            runat="server"
            autopostback="True">
            <asp:listitem Selected="True">Sales Representative</asp:listitem>
            <asp:listitem>Sales Manager</asp:listitem>
            <asp:listitem>Vice President, Sales</asp:listitem>
        </asp:dropdownlist></p>

        <asp:gridview
          id="GridView1"
          runat="server"
          datasourceid="ObjectDataSource1" />

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          typename="Samples.AspNet.VB.EmployeeLogic"
          selectmethod="GetAllEmployeesAsDataSet"
          filterexpression="Title='{0}'">
            <filterparameters>
              <asp:controlparameter name="Title" controlid="DropDownList1" propertyname="SelectedValue"/>
            </filterparameters>
        </asp:objectdatasource>

    </form>
  </body>
</html>
<!-- </Snippet1> -->