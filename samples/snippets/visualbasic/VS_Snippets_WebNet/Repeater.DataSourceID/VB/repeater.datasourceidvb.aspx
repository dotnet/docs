<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Repeater.DataSourceID Property Example</title>
</head>

  <body>
    <form id="Form1" runat="server">
        
      <h3>Repeater.DataSourceID Property Example</h3>
      
      <asp:repeater id="Repeater1"       
        datasourceid="SqlDataSource1"
        runat="server">
        
        <headertemplate>
          <table border="1">
            <tr>
              <td><b>Product ID</b></td>
              <td><b>Product Name</b></td>
            </tr>
        </headertemplate>
          
        <itemtemplate>
          <tr>
            <td> <%# Eval("ProductID") %> </td>
            <td> <%# Eval("ProductName") %> </td>
          </tr>
        </itemtemplate>
          
        <footertemplate>
          </table>
        </footertemplate>
      </asp:repeater>
        
            <asp:sqldatasource id="SqlDataSource1"          
            connectionstring="<%$ ConnectionStrings:NorthWindConnection%>" 
        selectcommand="SELECT ProductID, ProductName FROM [Products] Where ProductID <= 10"
        runat="server">
      </asp:sqldatasource>
               
    </form>      
  </body>
</html>
<!--</Snippet1>-->
