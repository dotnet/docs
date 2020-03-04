<!-- <snippet1> -->
<%@ page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCaptionAlign Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableCaptionAlign Enumeration Example</h3>
    <!-- Scope attribute added for accessibility -->
    <asp:table id="Table1" runat="server" CellPadding="4"
      caption="City Postal Codes" CellSpacing="1"
      captionalign="Right" gridlines="Both">
    <asp:TableRow>
      <asp:TableHeaderCell id="CityHeader" Scope="Column">
        City Name
      </asp:TableHeaderCell>
      <asp:TableHeaderCell id="ZipHeader" Scope="Column">
        ZIP Code
      </asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
      <asp:TableCell>
        Redmond
      </asp:TableCell>
      <asp:TableCell>
        98052
      </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
      <asp:TableCell>
        Albany
      </asp:TableCell>
      <asp:TableCell>
        12222
      </asp:TableCell>
    </asp:TableRow>
    </asp:table>

    </div>
    </form>
  </body>
</html>
<!-- </snippet1> -->