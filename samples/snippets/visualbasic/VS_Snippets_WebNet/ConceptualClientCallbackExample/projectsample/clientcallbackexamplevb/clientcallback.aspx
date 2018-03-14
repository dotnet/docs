<%@ Page Language="VB" AutoEventWireup="true" 
  CodeFile="ClientCallback.aspx.vb" Inherits="ClientCallback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html  >
<head id="Head1" runat="server">
  <title>Client Callback Example</title>
  <script type="text/javascript">
      function LookUpStock() {
          var lb = document.getElementById("ListBox1");
          try {
              var product = lb.options[lb.selectedIndex].text;
              CallServer(product, "");
          }
          catch (err) {
              alert("Please select a product.");
          }
      }

      function ReceiveServerData(rValue) {
          document.getElementById("ResultsSpan").innerHTML = rValue;
      }
</script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:ListBox ID="ListBox1" Runat="server"></asp:ListBox>
      <br />
      <br />
      <input type="button" value="Look Up Stock" onclick="LookUpStock()" />
      <br />
      <br />
      Items in stock: <span id="ResultsSpan" runat="server"></span>
      <br />
    </div>
  </form>
</body>
</html>