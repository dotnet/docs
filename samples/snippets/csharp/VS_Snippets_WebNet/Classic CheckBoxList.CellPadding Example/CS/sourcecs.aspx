<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>CheckBoxList Example</title>
<script language="C#" runat="server">

   void Check_Clicked(Object sender, EventArgs e) 
   {
      Message.Text = "Selected Item(s):<br /><br />";
      for (int i = 0; i < CheckBoxList1.Items.Count; i++)
      {
         if (CheckBoxList1.Items[i].Selected)
            Message.Text += CheckBoxList1.Items[i].Text + "<br />";
      }
   }

</script>
 
</head>
<body>
   
   <form id="form1" action="CheckBoxList.aspx" method="post" runat="server">
 
      <h3>CheckBoxList Example</h3>

      <asp:CheckBoxList id="CheckBoxList1" 
           AutoPostBack="True"
           CellPadding="5"
           CellSpacing="5"
           RepeatColumns="2"
           RepeatDirection="Vertical"
           RepeatLayout="Flow"
           TextAlign="Right"
           OnSelectedIndexChanged="Check_Clicked"
           runat="server">
 
         <asp:ListItem>Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>
         <asp:ListItem>Item 5</asp:ListItem>
         <asp:ListItem>Item 6</asp:ListItem>
 
      </asp:CheckBoxList>
 
      <br /><br />

      <asp:label id="Message" runat="server"/>
             
   </form>
          
</body>
</html>
<!--</Snippet1>-->

