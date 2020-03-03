<!--<Snippet1>-->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub HorizontalAlignList_SelectedIndexChanged()
    
    Select Case HorizontalAlignList.SelectedValue
      Case "Left"
        Panel1.HorizontalAlign = HorizontalAlign.Left
      Case "Center"
        Panel1.HorizontalAlign = HorizontalAlign.Center
      Case "Justify"
        Panel1.HorizontalAlign = HorizontalAlign.Justify
      Case Else
        Panel1.HorizontalAlign = HorizontalAlign.Right
    End Select
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>HorizontalAlign Example</title> 
 </head>
 <body>
    <h3>HorizontalAlign Example</h3>
    <form id="form1" runat="server">
 
       <asp:Panel id="Panel1" Height="100" Width="200" BackColor="Gainsboro"
            Wrap="True" HorizontalAlign="Left" runat="server">
         <asp:Label ID="Label1" runat="server" Text="This panel contains a Label control.">
         </asp:Label>
       </asp:Panel>
 
       <br />
 
       <asp:Label ID="Label2" runat="server" Text="Horizontal Alignment:"></asp:Label>
       <asp:DropDownList ID="HorizontalAlignList" runat="server" AutoPostBack="True" 
         onselectedindexchanged="HorizontalAlignList_SelectedIndexChanged">
         <asp:ListItem Selected="True">Left</asp:ListItem>
         <asp:ListItem>Center</asp:ListItem>
         <asp:ListItem>Right</asp:ListItem>
         <asp:ListItem>Justify</asp:ListItem>
       </asp:DropDownList>
 
    </form>
 </body>
 </html>    
<!--</Snippet1>-->
