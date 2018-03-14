<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Example</h3>

        <table cellspacing="10">
            
          <tr>
                
            <td valign="top">

<!--<Snippet4>-->  
<asp:FormView ID="FormView1"
  DataSourceID="SqlDataSource1"
  DataKeyNames="ProductID"     
  RunAt="server">
                                    
  <ItemTemplate>
    <table>
      <tr>
        <td align="right"><b>Product ID:</b></td>       
        <td><%# Eval("ProductID") %></td>
      </tr>
      <tr>
        <td align="right"><b>Product Name:</b></td>     
        <td><%# Eval("ProductName") %></td>
      </tr>
      <tr>
        <td align="right"><b>Category ID:</b></td>      
        <td><%# Eval("CategoryID") %></td>
      </tr>
      <tr>
        <td align="right"><b>Quantity Per Unit:</b></td>
        <td><%# Eval("QuantityPerUnit") %></td>
      </tr>
      <tr>
        <td align="right"><b>Unit Price:</b></td>       
        <td><%# Eval("UnitPrice") %></td>
      </tr>
    </table>                 
  </ItemTemplate>                 
</asp:FormView>
<!--</Snippet4>-->  
            
            </td>
                
          </tr>
            
        </table>
            
<!--<Snippet3>-->  
<asp:SqlDataSource ID="SqlDataSource1" 
  SelectCommand="SELECT * FROM [Products]"
  ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
  RunAt="server">
</asp:SqlDataSource>
<!--</Snippet3>-->
            
      </form>
  </body>
</html>
