<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet4>-->
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Using the Container Keyword to Determine a Naming Container</title>
</head>

<script language="c#" runat="server">
    
string[] list;
    
private void Page_Load(object sender, EventArgs e)
{
   list = new string[] {"One", "Two", "Three"};
   MyRepeater.DataSource = list;
   MyRepeater.DataBind();
}
    
</script>

<body>
<form id="repeaterform" action="repeater.aspx" method="post" runat="server">

  <table id="mytable" style="width:80%; text-align:center; 
      border-width:1; border-color:#00bb00">
  <tr valign="middle" >
    <asp:repeater id="MyRepeater" runat="server">
    <ItemTemplate>
      <tr><td style="width:100%; text-align:center">
      <span id="message" runat="server">
      Container's UniqueID = <%#Container.UniqueID%> (<%#Container.ToString()%>)<br />
      Container's Parent UniqueID = <%#Container.Parent.UniqueID%> 
      (<%#Container.Parent.ToString()%>)<br />
      Container's Grandparent UniqueID = <%#Container.Parent.Parent.UniqueID%> 
      (<%#Container.Parent.Parent.ToString()%>)<br />
       Container's Great-Grandparent = <%#Container.Parent.Parent.Parent.ToString()%><br />
       Data Item = <%#Container.DataItem%>
      </span></td></tr>
    </ItemTemplate>
  </asp:repeater>
  </tr>
</table>

</form>
</body>
</html>
<!--</Snippet4>-->