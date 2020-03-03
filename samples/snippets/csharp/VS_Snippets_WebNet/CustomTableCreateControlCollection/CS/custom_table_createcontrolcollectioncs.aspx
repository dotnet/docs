<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" %>
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Custom Table - CreateControlCollection - C# Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Custom Table - CreateControlCollection - C# Example</h3>

    <aspSample:CustomTableCreateControlCollection runat="server"
      id="Table1" GridLines="Both" CellPadding="4">
      <asp:TableRow>
        <asp:TableCell>Row 0, Col 0</asp:TableCell>
        <asp:TableCell>Row 0, Col 1</asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
        <asp:TableCell>Row 1, Col 0</asp:TableCell>
        <asp:TableCell>Row 1, Col 1</asp:TableCell>
      </asp:TableRow>
    </aspSample:CustomTableCreateControlCollection>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
