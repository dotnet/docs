<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="aspSample" 
    Namespace="Samples.AspNet.CS.Controls" 
    Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Custom TableCell - RenderContents - C# Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Custom TableCell - RenderContents - C# Example</h3>

    <asp:Table id="Table1" runat="server" CellPadding="3" CellSpacing="2">
      <asp:TableRow>
        <aspSample:CustomTableCellRenderContents Text="(0,0)" />
        <aspSample:CustomTableCellRenderContents Text="(0,1)" />
        <aspSample:CustomTableCellRenderContents Text="(0,2)" />
      </asp:TableRow>
      <asp:TableRow>
        <aspSample:CustomTableCellRenderContents Text="(1,0)" />
        <aspSample:CustomTableCellRenderContents Text="(1,1)" />
        <aspSample:CustomTableCellRenderContents Text="(1,2)" />
      </asp:TableRow>
    </asp:Table>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
