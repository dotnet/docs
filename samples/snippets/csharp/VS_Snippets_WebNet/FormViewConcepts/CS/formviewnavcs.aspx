<!-- <Snippet2> -->
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
                
              <asp:FormView ID="ProductsFormView"
                DataSourceID="ProductsSqlDataSource"
                AllowPaging="true"
                runat="server">

                <HeaderStyle forecolor="white" backcolor="Blue" />                
                                    
                <ItemTemplate>
                  <table>
                    <tr>
                      <td align="right"><b>Product ID:</b></td>
                      <td><asp:Label id="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Product Name:</b></td>
                      <td><asp:Label id="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Category ID:</b></td>
                      <td><asp:Label id="CategoryIDLabel" runat="server" Text='<%# Eval("CategoryID") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Quantity Per Unit:</b></td>
                      <td><asp:Label id="QuantityPerUnitLabel" runat="server" Text='<%# Eval("QuantityPerUnit") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Unit Price:</b></td>
                      <td><asp:Label id="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' /></td>
                    </tr>
                  </table>                 
                </ItemTemplate>

                <PagerTemplate>
                  <table>
                    <tr>
                      <td><asp:LinkButton ID="FirstButton" CommandName="Page" CommandArgument="First" Text="<<" RunAt="server"/></td>
                      <td><asp:LinkButton ID="PrevButton"  CommandName="Page" CommandArgument="Prev"  Text="<"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="NextButton"  CommandName="Page" CommandArgument="Next"  Text=">"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="LastButton"  CommandName="Page" CommandArgument="Last"  Text=">>" RunAt="server"/></td>
                    </tr>
                  </table>
                </PagerTemplate>

              </asp:FormView>
            
            </td>
          </tr>
        </table>
   
        <asp:SqlDataSource ID="ProductsSqlDataSource" 
          SelectCommand="SELECT ProductID, ProductName, CategoryID, QuantityPerUnit, UnitPrice FROM [Products]" 
          connectionstring="<%$ ConnectionStrings:NorthwindConnection %>" 
          RunAt="server"/>

      </form>
  </body>
</html>
<!-- </Snippet2> -->