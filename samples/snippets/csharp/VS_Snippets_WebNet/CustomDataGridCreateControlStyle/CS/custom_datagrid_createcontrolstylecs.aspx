<!-- <Snippet1> -->
<%@ Page language="c#" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom DataGrid - CreateControlStyle - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom DataGrid - CreateControlStyle - C# Example</h3>
      <aspSample:CustomDataGridCreateControlStyle id="Datagrid1" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:HyperLinkColumn Text="www.microsoft.com" Target="_blank" HeaderText="HyperLinks" NavigateUrl="http://www.microsoft.com" />
        </Columns>
      </aspSample:CustomDataGridCreateControlStyle>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
