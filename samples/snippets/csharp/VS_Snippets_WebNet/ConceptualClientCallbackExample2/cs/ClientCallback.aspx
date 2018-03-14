<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="true" 
  CodeFile="ClientCallback.aspx.cs" Inherits="ClientCallback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 
  1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
<script type="text/javascript">    
    function ReceiveServerData(rValue)
    {
        Results.innerText = rValue;
    }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:ListBox id="ListBox1" runat="server"></asp:ListBox>
      <br />
      <br />
      <button id="LookUpStockButton" type="button" onclick="LookUpStock()">Look Up Stock</button>
      <asp:LoginView id="LoginView1" runat="server">
      <LoggedInTemplate>
         <button id="LookUpSaleButton" type="button" onclick="LookUpSale()">Look Up Back Order</button>
      </LoggedInTemplate>
      </asp:LoginView>
      <br />
      Item status: <span id="Results"></span>
    </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->